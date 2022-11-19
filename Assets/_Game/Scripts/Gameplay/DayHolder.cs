using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayHolder : MonoBehaviour
{
    [SerializeField]
    private int currentDay = 1;
    public int CurrentDay { get {return currentDay; }}

    private Day selectedDay = null;

    [SerializeField]
    List<Day> listDays;


    public void SelectChoice(int choice) {
        switch (choice)
        {
            case 1:
                break;
            default:
                break;
        }
        NextDay();
    }

    private void NextDay ()
    {
        currentDay++;
        selectedDay = listDays[currentDay];

    }
}
