using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayHolder : MonoBehaviour
{
    [SerializeField]
    private int currentDay, currentWeek = -1;
    public int CurrentDay { get { return currentDay; } }

    private Day selectedDay = null;

    [SerializeField]
    List<Day> listDays;

    [SerializeField]
    ResourceHolder resourceHolder;

    [SerializeField]
    Image bg;

    [SerializeField]
    GameStatus gameStatus;

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

    private void Start()
    {
        NextDay();
    }

    private void NextDay()
    {
        currentDay++;

        if (currentDay > 7)
        {
            currentDay = 1;
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
    }
}
