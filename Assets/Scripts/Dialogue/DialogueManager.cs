using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private NPCInteraction currentNPC;

    [SerializeField]
    private DialogueUI dialogueUI;
    
    public bool IsDialogueOpen { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void OpenDialogue(NPCInteraction npc)
    {


        currentNPC = npc;

        IsDialogueOpen = true;

        dialogueUI.Show(npc.Dialogue);

        GameManager.Instance.SetGameplayCursor(false);

    }

    private void CloseDialogue()
    {
        dialogueUI.Hide();

        IsDialogueOpen = false;

        currentNPC = null;

        GameManager.Instance.SetGameplayCursor(true);
    }

    public void SelectChoice(int index)
    {
        if (currentNPC == null)
            return;

        DialogueChoice choice = null;

        switch (index)
        {
            case 0:
                choice = currentNPC.Dialogue.optionA;
                break;

            case 1:
                choice = currentNPC.Dialogue.optionB;
                break;

            case 2:
                choice = currentNPC.Dialogue.optionC;
                break;
        }

        if (choice == null)
            return;

        GameManager.Instance.AddScore(choice.score);

        currentNPC.CompleteInteraction();

        GameManager.Instance.NPCCompleted();

        CloseDialogue();
    }
}