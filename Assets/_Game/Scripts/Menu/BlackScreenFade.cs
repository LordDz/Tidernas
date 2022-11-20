using UnityEngine;

public class BlackScreenFade : MonoBehaviour
{
    float cooldown = 0.3f;

    [SerializeField]
    GameObject objToDisable;

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            //objToDisable.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}