using UnityEngine;

[CreateAssetMenu(
    fileName = "NPC Appearance",
    menuName = "NPC/Appearance")]
public class NPCAppearanceData : ScriptableObject
{
    [Header("Hair")]
    public Color hairColor = Color.black;

    [Header("Shirt")]
    public Color shirtColor = Color.white;

    [Header("Pants")]
    public Color pantsColor = Color.blue;
}