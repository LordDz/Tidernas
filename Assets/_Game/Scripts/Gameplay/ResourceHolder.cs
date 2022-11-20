using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    public int workerCost = 3;
    public int workerFindCost = 1;

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
    public List<JobChoice> listActiveWorkers = new List<JobChoice>();

    [SerializeField]
    ResourceDisplay resourceDisplay;
    ReportsPage reportsPage;

    BtnHireWorkersContainer btnHireWorkersContainer;

    WorkersForHire workersForHire;
    WorkerInfo nextWorker;
    JobWorkForce jobWorkForce;

    [SerializeField]
    GameObject workerInfoCard;

    [SerializeField]
    TextMeshProUGUI textAssignFishing, textAssignFactory;

    private void Start()
    {
        reportsPage = FindObjectOfType<ReportsPage>();
        btnHireWorkersContainer = FindObjectOfType<BtnHireWorkersContainer>();
        workersForHire = FindObjectOfType<WorkersForHire>();
        jobWorkForce = FindObjectOfType<JobWorkForce>();

        employeesUnEmployed = employeesTotal;
        nextWorker = workersForHire.GetWorkerInfo();
    }

    public void AddActiveWorker(JobChoice jobChoice)
    {
        listActiveWorkers.Add(jobChoice);
        employeesUnEmployed -= 1;
        resourceDisplay.textEmployees.SetText(employeesUnEmployed.ToString() + " / " + employeesTotal.ToString());

        WorkerInfo workerToShow = workersForHire.GetWorker(employeesUnEmployed);
        workersForHire.ShowWorkerInfo(workerToShow);
        float maxChanceFishing = jobWorkForce.GetMaxChance(JobChoice.fishing, workerToShow) * 100;
        float maxChanceFactory = jobWorkForce.GetMaxChance(JobChoice.factory, workerToShow) * 100;

        textAssignFishing.text = (maxChanceFishing + "%");
        textAssignFactory.text = (maxChanceFactory + "%");

        workerInfoCard.SetActive(true);

        if (employeesUnEmployed <= 0)
        {
            reportsPage.ShowReportPage();
        }
    }

    public void ResetForNextDay()
    {
        listActiveWorkers.Clear();
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
            btnHireWorkersContainer.HideButtonHireWorker();

            if (cash < workerCost)
            {
                btnHireWorkersContainer.HideButtonFindWorker();
            }
        }
    }

    public void FindNewWorker()
    {
        if (cash >= workerFindCost)
        {
            cash -= workerFindCost;
            resourceDisplay.textCash.SetText(cash.ToString());

            //workersForHire.AddNewWorker(nextWorker);
            nextWorker = workersForHire.GetWorkerInfo();
            workerInfoCard.SetActive(true);

            if (cash < workerCost)
            {
                btnHireWorkersContainer.HideButtonFindWorker();
                btnHireWorkersContainer.HideButtonHireWorker();
            }
            else
            {
                btnHireWorkersContainer.ShowButtons(cash, workerCost);
            }
        }
    }
}
