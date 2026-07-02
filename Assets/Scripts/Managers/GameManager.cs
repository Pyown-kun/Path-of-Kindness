using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Level")]
    [SerializeField] private int currentLevel = 1;

    [Header("Objective")]
    [SerializeField]
    private int totalNPC;

    [SerializeField]
    private int interactedNPC;

    [Header("Score")]
    [SerializeField]
    private int goodnessScore;

    [Header("Finish Point")]
    [SerializeField]
    private GameObject finishPoint;

    [Header("Ending")]
    [SerializeField]
    private ScoreSituationData scoreSituation;

    [Header("UI")]
    [SerializeField] private ScoreUI scoreUI;

    [SerializeField]
    private int targetScore = 100;

    [Header("Result UI")]
    [SerializeField]
    private GameResultUI resultUI;

    public int TargetScore => targetScore;

    public int GoodnessScore => goodnessScore;
    public int TotalNPC => totalNPC;
    public int InteractedNPC => interactedNPC;

    public bool CanFinishLevel { get; private set; }

    public bool LevelCompleted { get; private set; }

    public ScoreResult CurrentSituation { get; private set; }

    public bool IsGameplayLocked { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        ResetGame();
    }

    private void Start()
    {
        SetGameplayCursor(true);

        CountNPCInScene();

        ValidateScoreSituation();

        UpdateSituation();

        if (scoreUI != null)
        {
            scoreUI.InstantFill(
                (float)goodnessScore / targetScore);
        }
    }

    #region INITIALIZE

    private void ResetGame()
    {
        interactedNPC = 0;
        goodnessScore = 0;

        CanFinishLevel = false;
        LevelCompleted = false;

        if (finishPoint != null)
            finishPoint.SetActive(false);
    }

    private void CountNPCInScene()
    {
        totalNPC = FindObjectsByType<NPCInteraction>(
            FindObjectsSortMode.None).Length;

        Debug.Log($"Total NPC ditemukan : {totalNPC}");
    }

    #endregion

    #region SCORE

    public void AddScore(int amount)
    {
        goodnessScore += amount;

        if (goodnessScore < 0)
            goodnessScore = 0;

        UpdateSituation();

        if (scoreUI != null)
        {
            scoreUI.SetFill((float)goodnessScore / targetScore);
        }

        Debug.Log($"Goodness Score : {goodnessScore}");
    }

   private void UpdateSituation()
    {
        if (scoreSituation == null)
            return;

        CurrentSituation = null;

        foreach (ScoreResult result in scoreSituation.results)
        {
            if (goodnessScore >= result.minScore &&
                goodnessScore <= result.maxScore)
            {
                CurrentSituation = result;
                break;
            }
        }

        if (CurrentSituation != null)
        {
            Debug.Log("================================");
            Debug.Log($"Kategori Saat Ini : {CurrentSituation.situationName}");
            Debug.Log(CurrentSituation.description);
            Debug.Log("================================");
        }
        else
        {
            Debug.LogWarning("Belum ada ScoreResult yang sesuai dengan skor saat ini.");
        }
    }

    #endregion

    #region OBJECTIVE

    public void NPCCompleted()
    {
        interactedNPC++;

        Debug.Log($"Progress NPC : {interactedNPC}/{totalNPC}");

        CheckObjective();
    }

    private void CheckObjective()
    {
        if (interactedNPC < totalNPC)
            return;

        CanFinishLevel = true;

        if (finishPoint != null)
            finishPoint.SetActive(true);
    }

    #endregion

    #region FINISH

    public void FinishLevel()
    {
        if (LevelCompleted)
            return;

        if (!CanFinishLevel)
        {
            Debug.Log("Masih ada NPC yang belum diinteraksi.");
            return;
        }

        LevelCompleted = true;

        if (goodnessScore >= targetScore)
        {
            Debug.Log("PLAYER MENANG");

            SaveManager.UnlockNextLevel(currentLevel);

            resultUI.ShowWin();
        }
        else
        {

            resultUI.ShowGameOver();
        }
    }

    #endregion

    private void ValidateScoreSituation()
    {
        if (scoreSituation == null)
        {
            Debug.LogWarning("ScoreSituationData belum di-assign pada GameManager.");
            return;
        }

        if (scoreSituation.results == null || scoreSituation.results.Count == 0)
        {
            Debug.LogWarning("ScoreSituationData tidak memiliki data.");
            return;
        }

        foreach (ScoreResult result in scoreSituation.results)
        {
            if (result.minScore > result.maxScore)
            {
                Debug.LogError(
                    $"ScoreResult '{result.situationName}' memiliki Min Score ({result.minScore}) lebih besar dari Max Score ({result.maxScore}).");
            }
        }
    }

    public void LockGameplay()
    {
        IsGameplayLocked = true;
        Time.timeScale = 0f;
    }

    public void UnlockGameplay()
    {
        IsGameplayLocked = false;
        Time.timeScale = 1f;
    }

    public void SetGameplayCursor(bool gameplay)
    {
        if (gameplay)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}