using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{
    ResourceHolder resourceHolder;
    DayHolder dayHolder;

    [SerializeField]
    Player player;

    [SerializeField]
    InfoText scoreValueText, scoreMessage;

    [SerializeField]
    TextMeshProUGUI fameText;

    void Start()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        dayHolder = FindObjectOfType<DayHolder>();
        player = FindObjectOfType<Player>();
        fameText.gameObject.SetActive(false);
        scoreValueText.gameObject.SetActive(false);
        scoreMessage.gameObject.SetActive(false);
    }

    public void ApplyScore()
    {
        string key = GetKey();
        int score = GetScore();
        int previousScore = PlayerPrefs.GetInt(key, 0);
        bool isNew = false;
        if (score > previousScore)
        {
            PlayerPrefs.SetInt(key, score);
            isNew = true;
        }
        ShowHighScore(key, score, isNew);
    }

    public int GetScore()
    {
        return resourceHolder.cash * dayHolder.currentWeek;
    }

    private string GetKey()
    {
        return player.name.ToLower().Replace(" ", "-");
    }

    public void ShowHighScore(string key, int score, bool isNew)
    {
        string message;
        if (isNew)
        {
            message = "You did it! " + score.ToString() + " is your new personal best, well done!";
        }
        else
        {
            message = "Good job, but not as good as your best score. You can do better!";
        }
        scoreValueText.SetText(score.ToString());
        scoreMessage.SetText(message);
        fameText.gameObject.SetActive(true);
        scoreValueText.gameObject.SetActive(true);
        scoreMessage.gameObject.SetActive(true);
    }
}
