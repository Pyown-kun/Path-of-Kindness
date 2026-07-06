using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField]
    private DialogueData dialogueData;

    [SerializeField]
    private NPCSituationController situationController;

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

    public void ProcessChoice(DialogueChoice choice)
    {
        if (choice == null)
            return;

        // Jika jawaban benar, ubah situasi
        if (choice.isCorrect)
        {
            situationController?.SolveSituation();
        }

        CompleteInteraction();

        GameManager.Instance.NPCCompleted();
    }
}