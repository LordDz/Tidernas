using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    ResourceHolder resourceHolder;
    DayHolder dayHolder;
    Player player;

    void Start()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        dayHolder = FindObjectOfType<DayHolder>();
        player = FindObjectOfType<Player>();
    }

    public void ApplyScore()
    {
        string key = GetKey();
        int score = GetScore();
        int previousScore = PlayerPrefs.GetInt(key, 0);
        if (score > previousScore)
        {
            PlayerPrefs.SetInt(key, score);
        }
    }

    private int GetScore()
    {
        return resourceHolder.cash * dayHolder.currentWeek;
    }

    private string GetKey()
    {
        return player.name.ToLower().Replace(" ", "-");
        // name = String.Concat(name.Where(c => !Char.IsWhiteSpace(c)));
    }
}
