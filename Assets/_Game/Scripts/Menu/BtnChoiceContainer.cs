using UnityEngine;

public class BtnChoiceContainer : MonoBehaviour
{
    private BtnChoice[] btns;

    private void Start()
    {
        btns = GetComponentsInChildren<BtnChoice>();

    }
    public void ShowButtons()
    {
        btns ??= GetComponentsInChildren<BtnChoice>();

        foreach (BtnChoice btn in btns)
        {
            if (btn != null)
            {
                btn.gameObject.SetActive(true);
            }
        }
    }

    public void HideButtons()
    {
        foreach (BtnChoice btn in btns)
        {
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }
}
