using UnityEngine;
using UnityEngine.UI;

public class ReportsPage : MonoBehaviour
{
    const float timePerWorker = 0.9f;
    private float cooldown = 0;
    int index = 0;

    ResourceHolder resourceHolder;
    JobWorkForce jobWorkForce;
    BtnChoiceContainer btnChoiceContainer;
    BtnHireWorkersContainer btnHireWorkersContainer;
    DayHolder dayHolder;

    private bool isReportStarted = false;

    public Button btnStart;

    // Use this for initialization
    void Start()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        jobWorkForce = FindObjectOfType<JobWorkForce>();
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
        btnHireWorkersContainer = FindObjectOfType<BtnHireWorkersContainer>();
        dayHolder = FindObjectOfType<DayHolder>();
        btnStart.gameObject.SetActive(false);
    }

    public void ShowReportPage()
    {
        btnChoiceContainer.HideButtons();
        btnHireWorkersContainer.HideButtons();
        btnStart.gameObject.SetActive(true);
    }

    public void StartReport()
    {
        btnStart.gameObject.SetActive(false);
        cooldown = 1.0f;
        index = 0;
        isReportStarted = true;
    }

    private void StopReport()
    {
        isReportStarted = false;
        dayHolder.NextDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReportStarted)
        {
            if (cooldown < 0)
            {
                if (index < resourceHolder.listWorkers.Count)
                {
                    DoWork();
                }
                else
                {
                    StopReport();
                }
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }

    private void DoWork()
    {
        JobChoice workerJob = resourceHolder.listWorkers[index];
        jobWorkForce.WorkJob(workerJob);

        cooldown = timePerWorker;
        index++;
    }
}
