using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    public InfoText textCash, textEmployees, textPublicOpinion, textDeathCount;

    private void Start()
    {
        ResourceHolder resourceHolder = FindObjectOfType<ResourceHolder>();
        textCash.SetText(resourceHolder.cash.ToString());
        textEmployees.SetText(resourceHolder.employeesUnEmployeed.ToString() + " / " + resourceHolder.employeesTotal.ToString());
        textPublicOpinion.SetText(resourceHolder.publicOpinion.ToString());
        textDeathCount.SetText(resourceHolder.nrOfDeaths.ToString());
    }
}
