using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    [SerializeField]
    public int cash;

    [SerializeField]
    public int employeesUnEmployeed, employeesTotal;

    [SerializeField]
    public int publicOpinion;

    [HideInInspector]
    public int nrOfDeaths = 0;

    [HideInInspector]
    public List<JobChoice> listWorkers = new List<JobChoice>();

    ResourceDisplay resourceDisplay;
    ReportsPage reportsPage;

    private void Start()
    {
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
        reportsPage = FindObjectOfType<ReportsPage>();
    }

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

    public void AddActiveWorker(JobChoice jobChoice)
    {
        listWorkers.Add(jobChoice);
        employeesUnEmployeed -= 1;
        resourceDisplay.textEmployees.SetText(employeesUnEmployeed.ToString() + " / " + employeesTotal.ToString());

        if (employeesUnEmployeed <= 0)
        {
            reportsPage.ShowReportPage();
        }
    }

    public void ResetForNextDay()
    {
        listWorkers.Clear();
        employeesUnEmployeed = employeesTotal;
        resourceDisplay.textEmployees.SetText(employeesUnEmployeed.ToString() + " / " + employeesTotal.ToString());
    }
}
