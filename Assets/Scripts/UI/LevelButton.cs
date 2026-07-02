using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private LevelData levelData;

    [Header("UI")]
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text levelNameText;
    [SerializeField] private Image thumbnail;
    [SerializeField] private GameObject lockIcon;

    public void Refresh()
    {
        if (levelData == null)
            return;

        levelNameText.text = levelData.levelName;

        if (thumbnail != null)
            thumbnail.sprite = levelData.thumbnail;

        bool unlocked = SaveManager.IsUnlocked(levelData.levelIndex);

        button.interactable = unlocked;

        if (lockIcon != null)
            lockIcon.SetActive(!unlocked);

        if (thumbnail != null)
            thumbnail.color = unlocked ? Color.white : new Color(1,1,1,0.35f);

        if (levelNameText != null)
            levelNameText.color = unlocked ? Color.white : Color.gray;
    }

    public void LoadLevel()
    {
        if (!SaveManager.IsUnlocked(levelData.levelIndex))
            return;

        SceneController.Instance.LoadScene(levelData.sceneName);
    }
}