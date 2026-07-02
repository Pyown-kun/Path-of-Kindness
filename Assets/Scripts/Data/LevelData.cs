using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Info")]
    public int levelIndex;

    public string levelName;

    public string sceneName;

    [Header("Gameplay")]
    public int targetScore;

    [Header("UI")]
    public Sprite thumbnail;
}