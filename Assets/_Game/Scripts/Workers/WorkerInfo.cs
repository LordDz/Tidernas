using System.Collections;
using UnityEngine;


public class WorkerInfo
{
    // Use this for initialization
    public string personName;
    public int personCost;
    public Sprite personPicture;

    public int skillFish, skillFactory, skillTired;

    public WorkerInfo(string name, Sprite picture)
    {
        personName = name;
        personPicture = picture;
        personCost = Random.Range(2, 6);

        skillFish = Random.Range(1, 3);
        skillFactory = Random.Range(1, 3);
        skillTired = Random.Range(0, 10);
    }
}
