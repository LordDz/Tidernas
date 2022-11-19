using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoText : MonoBehaviour
{
    [SerializeField]
    Image icon;

    [SerializeField]
    TextMeshProUGUI text;

    public void SetText(string txt)
    {
        text.text = txt;
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}