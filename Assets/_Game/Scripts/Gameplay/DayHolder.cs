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

    BtnHireWorkersContainer btnHireWorkersContainer;


    private void Awake()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        gameStatus = FindObjectOfType<GameStatus>();
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
        btnHireWorkersContainer = FindObjectOfType<BtnHireWorkersContainer>();
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
        }

        SwitchToNextDay();
    }

    private void SwitchToNextDay()
    {
        Debug.Log("Current day: " + currentDay);

        selectedDay = listDays[currentDay];
        bg.sprite = selectedDay.imageBackground;
        dayText.SetText(selectedDay.nameOfDay);

        resourceHolder.ResetForNextDay();

        if (resourceHolder.publicOpinion <= 0 || resourceHolder.employeesTotal == 0 && resourceHolder.workerCost > resourceHolder.cash)
        {
            gameStatus.EndGame(resourceHolder.nrOfDeaths, resourceHolder.employeesTotal);
        }
        else
        {
            btnHireWorkersContainer.ShowButtons(resourceHolder.cash, resourceHolder.workerCost);
        }
    }
}
