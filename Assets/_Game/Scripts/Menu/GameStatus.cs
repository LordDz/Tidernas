using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    Image bg;

    [SerializeField]
    Sprite kills10, kills20, kills30, kills40, kills50;

    [SerializeField]
    TextMeshProUGUI textEndScreen;

    BtnChoiceContainer btnChoiceContainer;

    private void Awake()
    {
        btnChoiceContainer = FindObjectOfType<BtnChoiceContainer>();
    }

    public void EndGame(int nrOfDeaths)
    {
        btnChoiceContainer.HideButtons();
        if (textEndScreen != null)
        {
            textEndScreen.text = "You lost " + nrOfDeaths + " employees, but it was totally worth it!";
        }
        bg.sprite = kills10;
    }
}