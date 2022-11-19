using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    public int workerCost = 3;

    [SerializeField]
    public int cash;

    [SerializeField]
    public int employeesTotal;

    [HideInInspector]
    public int employeesUnEmployed;

    [SerializeField]
    public int publicOpinion;

    [HideInInspector]
    public int nrOfDeaths = 0;

    [HideInInspector]
    public List<JobChoice> listWorkers = new List<JobChoice>();

    ResourceDisplay resourceDisplay;
    ReportsPage reportsPage;

    BtnHireWorkersContainer btnHireWorkersContainer;

    WorkersForHire workersForHire;
    WorkerInfo nextWorker;

    private void Start()
    {
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
        reportsPage = FindObjectOfType<ReportsPage>();
        btnHireWorkersContainer = FindObjectOfType<BtnHireWorkersContainer>();
        workersForHire = FindObjectOfType<WorkersForHire>();

        employeesUnEmployed = employeesTotal;
        nextWorker = workersForHire.GetWorkerInfo();
    }

    public void AddActiveWorker(JobChoice jobChoice)
    {
        listWorkers.Add(jobChoice);
        employeesUnEmployed -= 1;
        resourceDisplay.textEmployees.SetText(employeesUnEmployed.ToString() + " / " + employeesTotal.ToString());

        if (employeesUnEmployed <= 0)
        {
            reportsPage.ShowReportPage();
        }
    }

    public void ResetForNextDay()
    {
        listWorkers.Clear();
        employeesUnEmployed = employeesTotal;
        resourceDisplay.textEmployees.SetText(employeesUnEmployed.ToString() + " / " + employeesTotal.ToString());
    }

    public void HireWorker()
    {
        if (cash >= workerCost)
        {
            cash -= workerCost;
            employeesUnEmployed += 1;
            employeesTotal += 1;
            resourceDisplay.textEmployees.SetText(employeesUnEmployed.ToString() + " / " + employeesTotal.ToString());
            resourceDisplay.textCash.SetText(cash.ToString());

            workersForHire.AddNewWorker(nextWorker);
            nextWorker = workersForHire.GetWorkerInfo();

            if (cash < workerCost)
            {
                btnHireWorkersContainer.HideButtonWorker();
            }
        }
    }
}
