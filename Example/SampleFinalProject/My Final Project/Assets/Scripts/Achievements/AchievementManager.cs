using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AchievementManager : SingletonMonoBehaviour<AchievementManager>
{
    public UnityEvent<string, string> OnAchievementMet;
    public List<Achievement_SO> AchievementList = new List<Achievement_SO>();

    [SerializeField] private Image _panel;    
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SaveResults _saveResults;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        OnAchievementMet.AddListener((text, name) => AchievementMet(text, name));
        //_panel.gameObject.SetActive(false);

        foreach (var achievement in AchievementList) 
        {
        //    if (_saveResults.gameData.Contains(new SaveResults.AchievementData { 
        //        name = achievement.name, achievementMet = true }))
        //    {
        //        achievement.hasAchievementMet = true;
        //    }
        //    else
        //    {
                achievement.Start();
            //}
        }
    }
    private void Update()
    {
        if (GameManager.Instance == null ) return;

        var drivenDirection = GameManager.Instance.driveDirections.y;
        foreach (var achievement in AchievementList) 
        {
            if (! achievement.hasAchievementMet)
                achievement.UpdateLoop(drivenDirection);
        }
    }
    private void AchievementMet(string achievementText, string name)
    {
        _saveResults.gameData.Add(new SaveResults.AchievementData { name = name, achievementMet = true });

        _text.text = achievementText;
        _panel.gameObject.SetActive(true);
        _audioSource.Play();
        StartCoroutine(DisableAchievement(_audioSource.clip.length));
    }
    private IEnumerator DisableAchievement(float length)
    {
        yield return new WaitForSeconds(length + 0.5f);

        _text.text = "";
        _panel.gameObject.SetActive(false);
        yield return null;
    }
}
