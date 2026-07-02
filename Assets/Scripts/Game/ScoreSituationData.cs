using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSituation",
    menuName = "Game/Score Situation")]
public class ScoreSituationData : ScriptableObject
{
    public List<ScoreResult> results = new();
}