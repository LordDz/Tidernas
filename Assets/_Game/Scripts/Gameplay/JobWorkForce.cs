using UnityEngine;

public class JobWorkForce : MonoBehaviour
{
    ResourceHolder resourceHolder;
    ResourceDisplay resourceDisplay;
    DayHolder dayholder;

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
        dayholder = FindObjectOfType<DayHolder>();
    }

    public void WorkJob(JobChoice jobChoice)
    {
        switch (jobChoice)
        {
            case JobChoice.fishing:
                DoWork(0.12f, cashFishing, soundFishDeath, SoundFishWin);
                break;
            case JobChoice.factory:
                DoWork(0.18f, cashFishing, soundFishDeath, SoundFishWin);
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
        resourceHolder.employeesUnEmployeed -= 1;

        resourceDisplay.textEmployees.SetText(resourceHolder.employeesUnEmployeed.ToString() + " / " + resourceHolder.employeesTotal.ToString());
        resourceDisplay.textDeathCount.SetText(resourceHolder.nrOfDeaths.ToString());
        resourceDisplay.textCash.SetText(resourceHolder.cash.ToString());
        audioSource.Play();

        if (resourceHolder.employeesUnEmployeed <= 0)
        {
            dayholder.NextDay();
        }
    }
}
