using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [Header("Special Case stuff (can leave blank)")]
    [SerializeField] private bool playOnStart;
    [SerializeField] private DialogueUI dialogueUI;

    [Header("Objects + Options")]
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private bool playWithoutInput;
    [SerializeField] private PlayOptions playOption;

    private enum PlayOptions
    {
        playOnce,
        playAgainWithInput
    }

    private bool played = false;
    private bool playOnce = false;

    private void Start()
    {
        if (playOnStart)
            TryInteract();
    }

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out HeroDialogueInteract player))
        {
            player.Interactable = this;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out HeroDialogueInteract player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void TryInteract()
    {
        if (played && playOnce)
            return;

        dialogueUI.ShowDialogue(dialogueObject, gameObject);
    }

    public void TryInteract(HeroDialogueInteract player)
    {
        if (played && playOnce)
            return;

        if (playWithoutInput || DialogueInputHandler.Instance.InteractPressedDown())
        {
            played = true;
            player.DialogueUI.ShowDialogue(dialogueObject, gameObject);

            switch (playOption)
            {
                case PlayOptions.playOnce:
                    {
                        playOnce = true;
                        break;
                    }

                case PlayOptions.playAgainWithInput:
                    {
                        playWithoutInput = false;
                        break;
                    }
            }
        }
    }

    public void SetPlayWithoutInput(bool playWithNoInput)
    {
        playWithoutInput = playWithNoInput;
    }
}
