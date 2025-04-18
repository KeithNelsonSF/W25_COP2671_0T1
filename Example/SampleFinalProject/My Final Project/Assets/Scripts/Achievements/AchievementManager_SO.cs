using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AchievementManager_SO", menuName = "Scriptable Objects/AchievementManager_SO")]
public class AchievementManager_SO : ScriptableObject
{   
    public List<Achievement_SO> AchievementList = new List<Achievement_SO>();
}
