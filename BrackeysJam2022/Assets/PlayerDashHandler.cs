using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashHandler : MonoBehaviour
{
    enum dashStateEnum
    {
        charged,
        dashing,
        recharging
    }
    [SerializeField] private dashStateEnum dashState;

    [SerializeField] private float dashDurationSecs;
    private float dashEndTime;

    [SerializeField] private float dashSpeed;

    [SerializeField] private float secondsPerAfterimage;
    private float nextAfterimageTime;

    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    Vector2 dir;

    private float gravScale;

    private void FixedUpdate()
    {
        switch(dashState)
        {
            case dashStateEnum.charged:
                {

                    if (InputHandler.Instance.special.pressed)
                    {
                        StartDash();
                    }
                    break;
                }
            case dashStateEnum.dashing:
                {
                    //Check if dash should end
                    if(Time.time >= dashEndTime)
                    {
                        EndDash();
                        break;
                    }

                    //Set velocity
                    rb.velocity = dir * dashSpeed;

                    //Check if afterimage should be spawned
                    if (Time.time >= nextAfterimageTime)
                    {
                        SpawnAfterImage();
                    }

                    break;
                }
            case dashStateEnum.recharging:
                {
                    if(playerController.Grounded)
                    {
                        dashState = dashStateEnum.charged;
                    }

                    break;
                }
        }
    }

    private void StartDash()
    {
        //Get input
        Vector2 directionHeld = InputHandler.Instance.dir;
        directionHeld = directionHeld.normalized;

        if (directionHeld.magnitude <= 0.05f)
            return; //cancel dash

        dir = directionHeld;

        //No movin
        playerController.SetInputLock(true);

        //No gravy
        gravScale = rb.gravityScale;
        rb.gravityScale = 0;

        //Set timer and state
        dashState = dashStateEnum.dashing;
        dashEndTime = Time.time + dashDurationSecs;

        //Set velocity
        rb.velocity = directionHeld * dashSpeed;

        //Spawn first afterimage + afterimage timer
        SpawnAfterImage();
    }

    private void EndDash()
    {
        //Can move again
        playerController.SetInputLock(false);

        //Make gravy normal
        rb.gravityScale = gravScale;

        //Set state
        dashState = dashStateEnum.recharging;
    }

    private void SpawnAfterImage()
    {
        GameObject newAfterImage = PlayerAfterImagePool.Instance.GetFromPool();
        newAfterImage.transform.position = transform.position;

        newAfterImage.GetComponent<PlayerAfterImageSprite>().SetSprite(spriteRenderer.sprite);

        nextAfterimageTime = Time.time + secondsPerAfterimage;
    }
}
