using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    public string playerName;

    [SerializeField]
    TMP_InputField playerInput;

    public void SubmitName()
    {
        playerName = playerInput.text;
        Debug.Log("Company name: " + playerName);
        gameObject.SetActive(false);
    }
}
