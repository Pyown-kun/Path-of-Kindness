using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField]
    private LevelButton[] levelButtons;

    private void OnEnable()
    {
        RefreshButtons();
    }

    public void RefreshButtons()
    {
        foreach (LevelButton button in levelButtons)
        {
            if (button != null)
                button.Refresh();
        }
    }
}