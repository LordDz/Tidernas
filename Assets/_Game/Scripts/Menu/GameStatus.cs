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

    private void Awake()
    {
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
        textEndScreen.gameObject.SetActive(false);
    }

    public void EndGame(int nrOfDeaths)
    {
        btnChoiceContainer.HideButtons();
        bg.sprite = kills10;

        if (resourceDisplay != null)
        {
            resourceDisplay.gameObject.SetActive(false);
        }

        if (textEndScreen != null)
        {
            textEndScreen.gameObject.SetActive(true);
            textEndScreen.SetText("You lost " + nrOfDeaths + " employees, but it was totally worth it!");
        }
    }
}