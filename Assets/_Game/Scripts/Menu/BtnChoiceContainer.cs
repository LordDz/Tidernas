using UnityEngine;

public class BtnChoiceContainer : MonoBehaviour
{
    public void HideButtons()
    {
        var btns = GetComponentsInChildren<BtnChoice>();
        foreach (BtnChoice btn in btns)
        {
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }
}
