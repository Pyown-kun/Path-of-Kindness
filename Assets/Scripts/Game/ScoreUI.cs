using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [Header("Star Fill")]
    [SerializeField] private Image starFill;

    [Header("Animation")]
    [SerializeField] private float fillSpeed = 2f;

    private float targetFill;

    private void Update()
    {
        if (starFill == null)
            return;

        starFill.fillAmount = Mathf.MoveTowards(
            starFill.fillAmount,
            targetFill,
            fillSpeed * Time.deltaTime);
    }

    public void SetFill(float normalizedValue)
    {
        targetFill = Mathf.Clamp01(normalizedValue);
    }

    public void InstantFill(float normalizedValue)
    {
        targetFill = Mathf.Clamp01(normalizedValue);

        if (starFill != null)
            starFill.fillAmount = targetFill;
    }
}