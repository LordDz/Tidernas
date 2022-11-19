using UnityEngine;

public class BtnChoice : MonoBehaviour
{
    private JobWorkForce jobWorkForce;

    private void Start()
    {
        jobWorkForce = FindObjectOfType<JobWorkForce>();
    }

    public void ChoiceOne()
    {
        jobWorkForce.WorkJob(JobChoice.fishing);
    }

    public void ChoiceTwo()
    {
        jobWorkForce.WorkJob(JobChoice.factory);
    }

    public void ChoiceThree()
    {
        //dayHolder.SelectChoice(3);
    }
}
