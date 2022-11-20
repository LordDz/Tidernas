using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkersForHire : MonoBehaviour
{
    public List<string> ListNames;
    public List<Sprite> ListSprites;

    [SerializeField]
    private string defaultName;

    [SerializeField]
    private Sprite defaultSprite;

    List<WorkerInfo> listWorkers = new List<WorkerInfo>();

    [SerializeField]
    InfoText personText;

    [SerializeField]
    Image personImage;

    public void AddNewWorker(WorkerInfo worker)
    {
        listWorkers.Add(worker);
    }

    public WorkerInfo GetWorker(int index)
    {
        Debug.Log("GetWorker with index: " + index);
        Debug.Log("listWorkers.count: " + listWorkers.Count);
        return listWorkers[index];
    }

    public void KillWorker(int index)
    {
        if (listWorkers[index] != null)
        {
            listWorkers.RemoveAt(index);
        }
    }

    public WorkerInfo GetWorkerInfo()
    {
        int randName = Random.Range(0, ListNames.Count - 1);
        int randSprite = Random.Range(0, ListSprites.Count - 1);

        string personName = randName < ListNames.Count ? ListNames[randName] : defaultName;
        Sprite personSprite = randSprite < ListSprites.Count ? ListSprites[randSprite] : defaultSprite;

        if (ListNames[randName] != null)
        {
            ListNames.RemoveAt(randName);
        }

        WorkerInfo workerInfo = new(personName, personSprite);
        personText.SetText(personName);
        personImage.sprite = personSprite;
        return workerInfo;
    }
}
