using System.Globalization;
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
    WorkersForHire workersForHire;
    DayHolder dayHolder;

    [SerializeField]
    GameObject workerInfoCard;

    private bool isReportStarted = false;

    public Button btnStart;

    [SerializeField]
    private Sprite spriteFisher, spriteFactory;

    [SerializeField]
    InfoText textWorkerJob;

    [SerializeField]
    AudioSource soundShowReportsPage, soundSwitchToNextDaysPage;

    // Use this for initialization
    void Start()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        jobWorkForce = FindObjectOfType<JobWorkForce>();
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
        btnHireWorkersContainer = FindObjectOfType<BtnHireWorkersContainer>();
        dayHolder = FindObjectOfType<DayHolder>();
        workersForHire = FindObjectOfType<WorkersForHire>();
        btnStart.gameObject.SetActive(false);
        textWorkerJob.gameObject.SetActive(false);
    }

    public void ShowReportPage()
    {
        btnStart.gameObject.SetActive(true);
        btnChoiceContainer.HideButtons();
        btnHireWorkersContainer.HideButtons();
        soundShowReportsPage.Play();
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
        textWorkerJob.gameObject.SetActive(false);
        soundSwitchToNextDaysPage.Play();

        dayHolder.NextDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReportStarted)
        {
            if (cooldown < 0)
            {
                if (index < resourceHolder.listActiveWorkers.Count)
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
        JobChoice workerJob = resourceHolder.listActiveWorkers[index];
        WorkerInfo worker = workersForHire.GetWorker(index);
        Sprite workSprite = workerJob == JobChoice.fishing ? spriteFisher : spriteFactory;

        workersForHire.ShowWorkerInfo(worker);
        bool isSuccessful = jobWorkForce.WorkJob(workerJob, worker);
        var jobText = workerJob == JobChoice.fishing ? "Fishing" : "Factory";
        string workText = isSuccessful ? jobText : " DEAD";

        textWorkerJob.SetText(workText);
        textWorkerJob.SetIcon(workSprite);
        workerInfoCard.SetActive(true);
        textWorkerJob.gameObject.SetActive(true);

        cooldown = timePerWorker;
        index++;

        if (index >= resourceHolder.listActiveWorkers.Count)
        {
            cooldown += 1.5f;
        }
    }
}
