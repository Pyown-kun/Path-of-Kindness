using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    [Header("UI")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingPanel;

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        pausePanel.SetActive(false);

        if (settingPanel != null)
            settingPanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (DialogueManager.Instance != null &&
            DialogueManager.Instance.IsDialogueOpen)
            return;

        if (GameManager.Instance.LevelCompleted)
            return;

        if (IsPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {

        Debug.Log("Pause Game");

        IsPaused = true;

        pausePanel.SetActive(true);

        GameManager.Instance.LockGameplay();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        IsPaused = false;

        pausePanel.SetActive(false);

        GameManager.Instance.UnlockGameplay();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenSetting()
    {
        if (settingPanel != null)
            settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        if (settingPanel != null)
            settingPanel.SetActive(false);
    }

    public void MainMenu()
    {
        ResumeGame();

        SceneController.Instance.LoadMainMenu();
    }
}