using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DayHolder : MonoBehaviour
{
    const int DAY_NEXT_WEEK = 7;

    [SerializeField]
    private int currentDay, currentWeek = -1;
    public int CurrentDay { get { return currentDay; } }

    private Day selectedDay = null;

    [SerializeField]
    List<Day> listDays;

    ResourceHolder resourceHolder;

    [SerializeField]
    Image bg;

    GameStatus gameStatus;

    [SerializeField]
    TextMeshProUGUI dayText;

    private void Awake()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start()
    {
        NextDay();
    }

    public void SelectChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                break;
            default:
                break;
        }
        NextDay();
    }

    private void NextDay()
    {
        currentDay++;

        if (currentDay > DAY_NEXT_WEEK)
        {
            currentDay = 0;
            currentWeek++;

            if (!resourceHolder.CheckIfStillAlive(currentWeek))
            {
                //YOU ARE DEAD NOW!
                gameStatus.EndGame(resourceHolder.nrOfDeaths);
                return;
            }
        }
        SwitchToNextDay();
    }

    private void SwitchToNextDay()
    {
        selectedDay = listDays[currentDay];
        bg.sprite = selectedDay.imageBackground;
        dayText.text = selectedDay.nameOfDay;
    }
}
