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

    public InfoText dayText;

    BtnChoiceContainer btnChoiceContainer;



    private void Awake()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        gameStatus = FindObjectOfType<GameStatus>();
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
    }

    private void Start()
    {
        NextDay();
    }

    public void NextDay()
    {
        currentDay++;

        if (currentDay >= DAY_NEXT_WEEK)
        {
            currentDay = 0;
            currentWeek++;

            if (!resourceHolder.CheckIfStillAlive(currentWeek))
            {
                //YOU ARE DEAD NOW!
                gameStatus.EndGame(resourceHolder.nrOfDeaths, resourceHolder.employeesTotal);
                return;
            }
        }
        SwitchToNextDay();
    }

    private void SwitchToNextDay()
    {
        Debug.Log("Current day: " + currentDay);


        resourceHolder.ResetForNextDay();
        btnChoiceContainer.ShowButtons();

        selectedDay = listDays[currentDay];
        bg.sprite = selectedDay.imageBackground;
        dayText.SetText(selectedDay.nameOfDay);
    }
}
