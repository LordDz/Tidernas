using UnityEngine;

public class BtnChoice : MonoBehaviour
{
    private ResourceHolder resourceHolder;

    private void Start()
    {
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
        //dayHolder.SelectChoice(3);
    }
}
