using UnityEngine;

public class BtnHireWorkersContainer : MonoBehaviour
{
    [SerializeField]
    private BtnChoice btnStart, btnHireWorker, btnFindWorker;

    [SerializeField]
    GameObject workerInfoCard;

    private BtnChoiceContainer btnChoiceContainer;

    ResourceHolder resourceHolder;
    WorkersForHire workersForHire;



    private void Start()
    {
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
        resourceHolder = FindObjectOfType<ResourceHolder>();
        workersForHire = FindObjectOfType<WorkersForHire>();
    }

    public void ShowButtons(int cash, int workerCost)
    {
        btnStart.gameObject.SetActive(true);
        bool canShowWorker = cash > workerCost;

        if (canShowWorker)
        {
            btnHireWorker.gameObject.SetActive(true);
            btnFindWorker.gameObject.SetActive(true);
            workerInfoCard.SetActive(true);
        }
    }

    public void HideButtons()
    {
        btnStart.gameObject.SetActive(false);
        btnHireWorker.gameObject.SetActive(false);
        btnFindWorker.gameObject.SetActive(false);
        workerInfoCard.SetActive(false);
    }

    public void HideButtonHireWorker()
    {
        btnHireWorker.gameObject.SetActive(false);
        workerInfoCard.SetActive(false);
    }

    public void HideButtonFindWorker()
    {
        btnHireWorker.gameObject.SetActive(false);
        btnFindWorker.gameObject.SetActive(false);
        workerInfoCard.SetActive(false);
    }

    public void StartDay()
    {
        HideButtons();
        btnChoiceContainer.ShowButtons();

        if (workersForHire.ListNames.Count > 0)
        {
            WorkerInfo workerToShow = workersForHire.GetWorker(0);
            workersForHire.ShowWorkerInfo(workerToShow);
            workerInfoCard.SetActive(true);
        }
    }
}
