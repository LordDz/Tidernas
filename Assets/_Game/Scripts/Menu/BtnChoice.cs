using UnityEngine;
using UnityEngine.UI;

public class BtnChoice : MonoBehaviour
{
    private ResourceHolder resourceHolder;
    Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        resourceHolder = FindObjectOfType<ResourceHolder>();
    }

    public void ChoiceAddWorkerToFishing()
    {
        resourceHolder.AddActiveWorker(JobChoice.fishing);
    }

    public void ChoiceAddWorkerToFactory()
    {
        resourceHolder.AddActiveWorker(JobChoice.factory);
    }

    public void ChoiceWorkerHire()
    {
        resourceHolder.HireWorker();
    }

    public void ChoiceWorkerFindNew()
    {
        resourceHolder.FindNewWorker();
    }

    public void EnableButton()
    {
        btn ??= GetComponent<Button>();
        btn.enabled = true;
        btn.gameObject.SetActive(true);
    }

    public void DisableButton()
    {
        btn.enabled = false;
        btn.gameObject.SetActive(false);
    }
}
