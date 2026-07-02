using UnityEngine;

[CreateAssetMenu(
    fileName = "Dialogue",
    menuName = "Game/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [Header("Situation")]

    public string name;

    [TextArea(5,10)]
    public string situation;

    [Header("Choices")]

    public DialogueChoice optionA;

    public DialogueChoice optionB;

    public DialogueChoice optionC;
}