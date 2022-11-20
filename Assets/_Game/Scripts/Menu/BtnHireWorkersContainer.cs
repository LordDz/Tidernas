using UnityEngine;

public class BtnHireWorkersContainer : MonoBehaviour
{
    [SerializeField]
    private BtnChoice btnStart, btnHireWorker, btnFindWorker;

    [SerializeField]
    GameObject workerInfoCard;

    private BtnChoiceContainer btnChoiceContainer;

    private void Start()
    {
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
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

    public void HideButtonWorker()
    {
        btnHireWorker.gameObject.SetActive(false);
        btnFindWorker.gameObject.SetActive(false);
        workerInfoCard.SetActive(false);
    }

    public void StartDay()
    {
        HideButtons();
        btnChoiceContainer.ShowButtons();
    }
}
