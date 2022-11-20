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
    InfoText personText, skillFishing, skillFactory, skillTired;

    [SerializeField]
    Image personImage;

    public void AddNewWorker(WorkerInfo worker)
    {
        listWorkers.Add(worker);
    }
    public WorkerInfo GetWorker(int index)
    {
        //Debug.Log("GetWorker with index: " + index);
        //Debug.Log("listWorkers.count: " + listWorkers.Count);
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
        ShowWorkerInfo(workerInfo);
        return workerInfo;
    }

    public void ShowWorkerInfo(WorkerInfo workerInfo)
    {
        personText.SetText(workerInfo.personName);
        personImage.sprite = workerInfo.personPicture;

        skillFishing.SetText(workerInfo.skillFish.ToString());
        skillFactory.SetText(workerInfo.skillFactory.ToString());
        skillTired.SetText(workerInfo.skillTired.ToString());

        personImage.gameObject.SetActive(true);
        personText.gameObject.SetActive(true);
        skillFishing.gameObject.SetActive(true);
        skillFactory.gameObject.SetActive(true);
        skillTired.gameObject.SetActive(true);
    }

    public void HideWorkerInfo()
    {
        personImage.gameObject.SetActive(false);
        personText.gameObject.SetActive(false);
        skillFishing.gameObject.SetActive(false);
        skillFactory.gameObject.SetActive(false);
        skillTired.gameObject.SetActive(false);
    }
}
