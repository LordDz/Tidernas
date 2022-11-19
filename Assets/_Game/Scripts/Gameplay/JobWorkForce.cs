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
    AudioClip soundFishDeath, SoundFishWin, soundFactoryDeath, soundFactoryWin;

    private void Awake()
    {
        resourceHolder = FindObjectOfType<ResourceHolder>();
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
    }

    public void WorkJob(JobChoice jobChoice)
    {
        switch (jobChoice)
        {
            case JobChoice.fishing:
                DoWork(0.25f, cashFishing, soundFishDeath, SoundFishWin);
                break;
            case JobChoice.factory:
                DoWork(0.5f, cashFactory, soundFactoryDeath, soundFactoryWin);
                break;
        }
    }

    private void DoWork(float maxChance, int money, AudioClip soundDeath, AudioClip soundWin)
    {
        if (Random.value > maxChance)
        {
            audioSource.clip = soundWin;
        }
        else
        {
            audioSource.clip = soundDeath;
            resourceHolder.nrOfDeaths += 1;
            resourceHolder.employeesTotal -= 1;
            resourceHolder.publicOpinion -= 1;
            resourceDisplay.textPublicOpinion.SetText(resourceHolder.publicOpinion.ToString());
        }

        resourceHolder.cash += money;
        resourceDisplay.textEmployees.SetText(resourceHolder.employeesUnEmployed.ToString() + " / " + resourceHolder.employeesTotal.ToString());
        resourceDisplay.textDeathCount.SetText(resourceHolder.nrOfDeaths.ToString());
        resourceDisplay.textCash.SetText(resourceHolder.cash.ToString());
        audioSource.Play();
    }
}
