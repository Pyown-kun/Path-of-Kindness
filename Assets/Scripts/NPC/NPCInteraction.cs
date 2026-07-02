using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField]
    private DialogueData dialogueData;

    private bool interacted;

    public bool HasInteracted => interacted;

    public bool IsPlayerNearby { get; set; }

    public DialogueData Dialogue => dialogueData;

    public void Interact()
    {
        if (interacted)
            return;

        DialogueManager.Instance.OpenDialogue(this);
    }

    public void CompleteInteraction()
    {
        interacted = true;
    }
}