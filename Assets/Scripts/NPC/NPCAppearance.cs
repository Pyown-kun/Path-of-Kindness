using UnityEngine;

public class NPCAppearance : MonoBehaviour
{
    [Header("Appearance Data")]
    [SerializeField] private NPCAppearanceData appearanceData;

    [Header("Renderer")]
    [SerializeField] private Renderer hairRenderer;

    [SerializeField] private Renderer shirtRenderer;

    [SerializeField] private Renderer pantsRenderer;

    private MaterialPropertyBlock propertyBlock;

    private static readonly int BaseColor =
    Shader.PropertyToID("_Color");

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();

        ApplyAppearance();
    }

    public void ApplyAppearance()
    {
        if (appearanceData == null)
            return;

        ApplyColor(hairRenderer, appearanceData.hairColor);

        ApplyColor(shirtRenderer, appearanceData.shirtColor);

        ApplyColor(pantsRenderer, appearanceData.pantsColor);
    }

    private void ApplyColor(Renderer target, Color color)
    {
        if (target == null)
            return;

        target.GetPropertyBlock(propertyBlock);

        propertyBlock.SetColor(BaseColor, color);

        target.SetPropertyBlock(propertyBlock);
    }
}