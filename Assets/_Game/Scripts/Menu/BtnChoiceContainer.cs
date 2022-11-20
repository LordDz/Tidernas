using UnityEngine;

public class BtnChoiceContainer : MonoBehaviour
{
    private BtnChoice[] btns;

    [SerializeField]
    private BtnChoice endButton;

    private ResourceHolder resourceHolder;
    private DayHolder dayHolder;

    private void Start()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        dayHolder = FindObjectOfType<DayHolder>();
        btns = GetComponentsInChildren<BtnChoice>();
        HideButtons();

    }
    public void ShowButtons()
    {
        btns ??= GetComponentsInChildren<BtnChoice>();

        foreach (BtnChoice btn in btns)
        {
            if (btn != null)
            {
                if (btn == endButton)
                {
                    if (dayHolder.CurrentDay > 3 && resourceHolder)
                }
                else
                {
                    btn.gameObject.SetActive(true);
                }
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
