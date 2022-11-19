using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    Image bg;

    [SerializeField]
    Sprite kills10, kills20, kills30, kills40, kills50;

    public void EndGame(int nrOfDeaths)
    {
        bg.sprite = kills10;
    }
}