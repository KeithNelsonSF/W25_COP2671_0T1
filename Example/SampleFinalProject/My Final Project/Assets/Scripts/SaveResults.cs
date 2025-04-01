using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveResults", menuName = "Scriptable Objects/SaveResults")]
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class SaveResults : ScriptableObject
{
    [Serializable]
    public class AchievementData
    {
        public string name;
        public bool achievementMet;
    }
    public List<AchievementData> gameData = new List<AchievementData>();
    private string GetDebuggerDisplay()
    {
        return JsonUtility.ToJson(gameData);
    }
}
