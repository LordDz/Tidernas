using UnityEngine;

public class BtnHireWorkersContainer : MonoBehaviour
{
    [SerializeField]
    private BtnChoice btnStart, btnHireWorker;

    private BtnChoiceContainer btnChoiceContainer;

    private void Start()
    {
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
    }

    public void ShowButtons(int cash, int workerCost)
    {
        btnStart.gameObject.SetActive(true);
        btnHireWorker.gameObject.SetActive(cash > workerCost);
    }

    public void HideButtons()
    {
        btnStart.gameObject.SetActive(false);
        btnHireWorker.gameObject.SetActive(false);
    }

    public void HideButtonWorker()
    {
        btnHireWorker.gameObject.SetActive(false);
    }

    public void StartDay()
    {
        HideButtons();
        btnChoiceContainer.ShowButtons();
    }
}
