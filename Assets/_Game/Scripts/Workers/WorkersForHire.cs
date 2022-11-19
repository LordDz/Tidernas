using System.Collections.Generic;
using UnityEngine;


public class WorkersForHire : MonoBehaviour
{
    public List<string> ListNames;
    public List<Sprite> ListSprites;

    [SerializeField]
    private string defaultName;

    [SerializeField]
    private Sprite defaultSprite;

    public WorkerInfo GetWorkerInfo()
    {
        int randName = Random.Range(0, ListNames.Count - 1);
        int randSprite = Random.Range(0, ListNames.Count - 1);

        string personName = randName > ListNames.Count ? ListNames[randName] : defaultName;
        Sprite personSprite = randSprite > ListSprites.Count ? ListSprites[randSprite] : defaultSprite;

        if (ListNames[randName] != null)
        {
            ListNames.RemoveAt(randName);
        }

        WorkerInfo workerInfo = new(personName, personSprite);
        return workerInfo;
    }
}
