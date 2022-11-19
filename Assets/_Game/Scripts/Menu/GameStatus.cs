using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    Image bg;

    [SerializeField]
    Sprite kills10, kills20, kills30, kills40, kills50;

    [SerializeField]
    InfoText textEndScreen;

    BtnChoiceContainer btnChoiceContainer;

    ResourceDisplay resourceDisplay;

    [SerializeField]
    AudioSource musicMain, musicEnd;
    HighScoreHandler highScoreHandler;

    private void Awake()
    {
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
        textEndScreen.gameObject.SetActive(false);
    }

    public void EndGame(int nrOfDeaths, int employeesTotal)
    {
        btnChoiceContainer.HideButtons();
        bg.sprite = kills10;

        if (resourceDisplay != null)
        {
            resourceDisplay.gameObject.SetActive(false);
        }

        if (textEndScreen != null)
        {
            // You're dead, Jim
            highScoreHandler.ApplyScore();
            int highScore = highScoreHandler.GetScore();

            textEndScreen.gameObject.SetActive(true);
            string message = "";
            int possibleDeaths = nrOfDeaths + employeesTotal;
            float deathRatio = (nrOfDeaths / (nrOfDeaths + employeesTotal)) * 100;
            Debug.Log("nrOfDeaths: " + nrOfDeaths);
            Debug.Log("possibleDeaths: " + possibleDeaths);
            Debug.Log("employeesTotal: " + employeesTotal);
            Debug.Log("deathRatio: " + deathRatio);

            musicMain.Stop();
            musicEnd.Play();
            if (nrOfDeaths == 0)
            {
                message = "You lost and all workers lived. What were you thinking?!";
            }
            else if (deathRatio >= 1 && deathRatio < 25)
            {
                message = "You lost, no wonder. Poor use of resources.";
            }
            else if (deathRatio >= 75 && deathRatio < 100)
            {
                message = "You lost but at least you could use your resources.";
            }
            else
            {
                message = "Sure, you lost, but at least you spent every last resource.";
            }
            textEndScreen.SetText(message);
        }

    }
}