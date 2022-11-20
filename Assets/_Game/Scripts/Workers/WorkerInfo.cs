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

        skillFish = Random.Range(0, 4);
        skillFactory = Random.Range(0, 4);
        skillTired = Random.Range(0, 3);
    }
}
