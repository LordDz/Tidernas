using UnityEngine;

public class BtnChoice : MonoBehaviour
{
    [SerializeField]
    private DayHolder dayHolder;

    public void ChoiceOne() {
        dayHolder.SelectChoice(1);
    }

    public void ChoiceTwo() {
        dayHolder.SelectChoice(2);
    }

    public void ChoiceThree() {
        dayHolder.SelectChoice(3);
    }
}
