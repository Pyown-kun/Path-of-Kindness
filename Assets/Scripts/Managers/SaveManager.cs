using UnityEngine;

public static class SaveManager
{
    private const string HighestLevelKey = "HighestUnlockedLevel";

    public static int HighestUnlockedLevel
    {
        get
        {
            return PlayerPrefs.GetInt(HighestLevelKey, 1);
        }
    }

    public static bool IsUnlocked(int levelIndex)
    {
        return levelIndex <= HighestUnlockedLevel;
    }

    public static void UnlockNextLevel(int currentLevel)
    {
        int highest = HighestUnlockedLevel;

        // Hanya unlock jika pemain menyelesaikan level tertinggi saat ini
        if (currentLevel == highest)
        {
            PlayerPrefs.SetInt(HighestLevelKey, highest + 1);
            PlayerPrefs.Save();

            Debug.Log($"Level {highest + 1} berhasil dibuka.");
        }
    }

    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(HighestLevelKey);
        PlayerPrefs.Save();

        Debug.Log("Progress berhasil direset.");
    }
}