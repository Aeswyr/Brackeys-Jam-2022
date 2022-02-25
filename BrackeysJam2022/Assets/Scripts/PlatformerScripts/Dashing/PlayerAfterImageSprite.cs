using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    private float alpha;
    [SerializeField] private float startAlpha;
    [SerializeField] private float duration;

    private float spawnTime;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color startColor;
    private Color color;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite spr)
    {
        spawnTime = Time.time;

        spriteRenderer.sprite = spr;
        color = startColor;
    }

    private void FixedUpdate()
    {
        if (Time.time >= spawnTime + duration)
        {
            //Bye byeeeeee
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
        else
        {
            float ratio = (Time.time - spawnTime) / duration;

            Debug.Log("ratio: " + ratio);

            alpha = 1 - ratio;
            //Debug.Log("alpha: " + alpha);
            color.a = alpha;
            spriteRenderer.color = color;

        }
    }
}
