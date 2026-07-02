using UnityEngine;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);

        Debug.Log("Win");

        GameManager.Instance.LockGameplay();
        GameManager.Instance.SetGameplayCursor(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over");

        GameManager.Instance.LockGameplay();
        GameManager.Instance.SetGameplayCursor(false);
    }

    public void ContinueGame()
    {
        GameManager.Instance.UnlockGameplay();

        SceneController.Instance.LoadNextLevel();
    }

    public void Retry()
    {

        GameManager.Instance.UnlockGameplay();

        SceneController.Instance.RestartLevel();
    }

    public void MainMenu()
    {
        GameManager.Instance.UnlockGameplay();

        SceneController.Instance.LoadMainMenu();
    }
}