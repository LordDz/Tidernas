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

    public void ChoiceOne()
    {
        resourceHolder.AddActiveWorker(JobChoice.fishing);
    }

    public void ChoiceTwo()
    {
        resourceHolder.AddActiveWorker(JobChoice.factory);
    }

    public void ChoiceThree()
    {
        resourceHolder.HireWorker();
    }

    public void ChoiceFindNewWorker()
    {
        Debug.Log("FIND NEW WORKER CLICKED ON!?");
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
