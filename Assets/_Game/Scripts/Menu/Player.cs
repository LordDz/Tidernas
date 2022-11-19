using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    string name;

    [SerializeField]
    TMP_InputField input;

    public void SubmitName()
    {
        name = input.text;
    }
}
