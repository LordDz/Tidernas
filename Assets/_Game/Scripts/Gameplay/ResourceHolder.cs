using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    [SerializeField]
    public int cash;

    [SerializeField]
    public int employees;

    [SerializeField]
    public int publicOpinion;

    private int nrOfDeaths = 0;
}
