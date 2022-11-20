using UnityEngine;

public class JobWorkForce : MonoBehaviour
{
    ResourceHolder resourceHolder;
    ResourceDisplay resourceDisplay;

    [SerializeField]
    private int cashFishing, cashFactory;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip soundFishDeath01, soundFishDeath02, soundFishDeath03, soundFishDeath04;

    [SerializeField]
    AudioClip soundFishWin01, soundFishWin02, soundFishWin03, soundFishWin04;

    [SerializeField]
    AudioClip soundFactoryDeath01, soundFactoryDeath02, soundFactoryDeath03, soundFactoryDeath04;

    [SerializeField]
    AudioClip soundFactoryWin01, soundFactoryWin02, soundFactoryWin03, soundFactoryWin04;

    private void Awake()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
    }

    public bool WorkJob(JobChoice jobChoice, WorkerInfo workerInfo)
    {
        bool isSuccessful = false;
        float maxChance = GetMaxChance(jobChoice, workerInfo);
        switch (jobChoice)
        {
            case JobChoice.fishing:
                isSuccessful = DoWork(maxChance, cashFishing, soundFishDeath01, soundFishDeath02, soundFishDeath03, soundFishDeath04, soundFishWin01, soundFishWin02, soundFishWin03, soundFishWin04);
                break;
            case JobChoice.factory:
                isSuccessful = DoWork(maxChance, cashFactory, soundFactoryDeath01, soundFactoryDeath02, soundFactoryDeath03, soundFactoryDeath04, soundFactoryWin01, soundFactoryWin02, soundFactoryWin03, soundFactoryWin04);
                break;
        }
        return isSuccessful;
    }

    public float GetMaxChance(JobChoice jobChoice, WorkerInfo workerInfo)
    {
        float highest = jobChoice == JobChoice.fishing ? 0.4f : 0.75f;
        float skill = jobChoice == JobChoice.fishing ? workerInfo.skillFish : workerInfo.skillFactory;
        float tired = workerInfo.skillTired;

        skill /= 10;
        tired /= 10;

        highest -= skill;
        highest += tired;
        Debug.Log("MaxChance - highest: " + highest);

        return highest;
    }

    private bool DoWork(float maxChance, int money, AudioClip death01, AudioClip death02, AudioClip death03, AudioClip death04, AudioClip win01, AudioClip win02, AudioClip win03, AudioClip win04)
    {

        bool isSuccessful = true;
        if (Random.value > maxChance)
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    audioSource.clip = win01;
                    break;
                case 2:
                    audioSource.clip = win02;
                    break;
                case 3:
                    audioSource.clip = win03;
                    break;
                case 4:
                    audioSource.clip = win04;
                    break;
            }
        }
        else
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    audioSource.clip = death01;
                    break;
                case 2:
                    audioSource.clip = death02;
                    break;
                case 3:
                    audioSource.clip = death03;
                    break;
                case 4:
                    audioSource.clip = death04;
                    break;
            }
            resourceHolder.nrOfDeaths += 1;
            resourceHolder.employeesTotal -= 1;
            resourceHolder.publicOpinion -= 1;
            resourceDisplay.textPublicOpinion.SetText(resourceHolder.publicOpinion.ToString());
            isSuccessful = false;
        }

        resourceHolder.cash += money;
        resourceDisplay.textEmployees.SetText(resourceHolder.employeesUnEmployed.ToString() + " / " + resourceHolder.employeesTotal.ToString());
        resourceDisplay.textDeathCount.SetText(resourceHolder.nrOfDeaths.ToString());
        resourceDisplay.textCash.SetText(resourceHolder.cash.ToString());
        audioSource.Play();
        return isSuccessful;
    }

}
