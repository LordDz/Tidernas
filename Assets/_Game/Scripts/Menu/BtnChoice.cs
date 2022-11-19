using UnityEngine;

public class BtnChoice : MonoBehaviour
{
    private DayHolder dayHolder;

    private void Start()
    {
        dayHolder = FindObjectOfType<DayHolder>();
    }

    public void ChoiceOne()
    {
        dayHolder.SelectChoice(1);
    }

    public void ChoiceTwo()
    {
        dayHolder.SelectChoice(2);
    }

    public void ChoiceThree()
    {
        dayHolder.SelectChoice(3);
    }
}
