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
    InfoText textWorker;

    private bool isReportStarted = false;

    public Button btnStart;

    [SerializeField]
    private Sprite spriteFisher, spriteFactory;

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
        var worker = workersForHire.GetWorker(index);
        string workType = workerJob == JobChoice.fishing ? "fisher" : "factorian";
        Sprite workSprite = workerJob == JobChoice.fishing ? spriteFisher : spriteFactory;
        textWorker.SetText(worker.personName + " " + workType);
        textWorker.SetIcon(workSprite);
        jobWorkForce.WorkJob(workerJob);

        cooldown = timePerWorker;
        index++;
    }
}
