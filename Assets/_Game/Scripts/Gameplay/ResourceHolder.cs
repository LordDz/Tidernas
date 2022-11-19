using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    [SerializeField]
    public int cash;

    [SerializeField]
    public int employeesUnEmployed, employeesTotal;

    [SerializeField]
    public int publicOpinion;

    [HideInInspector]
    public int nrOfDeaths = 0;

    public bool CheckIfStillAlive(int week)
    {
        switch (week)
        {
            case 1:
                return cash >= 25;
            case 2:
                return cash >= 50;
            case 3:
                return cash >= 75;
            case 4:
                return cash >= 100;
            case 5:
                return cash >= 125;
        }
        return false;
    }
}
