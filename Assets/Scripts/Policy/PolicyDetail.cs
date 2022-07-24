using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolicyDetail : MonoBehaviour
{
    public Policy policy = null;
    public GameObject cameraMovement;
    public Image[] icons;

    public int effectCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        foreach(var icon in icons)
        {
            icon.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(policy != null)
        {
            cameraMovement.GetComponent<CameraMovement>().isActive = false;
            this.gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = policy.title;
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = policy.description;
            this.gameObject.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Cost: " + policy.cashCost + " Money";

            if(effectCount == 0)
            {
                icons[0].gameObject.SetActive(false);
                icons[1].gameObject.SetActive(false);
                icons[2].gameObject.SetActive(false);
                icons[3].gameObject.SetActive(false);
                icons[4].gameObject.SetActive(false);
                icons[5].gameObject.SetActive(false);
            }

            if (effectCount == 0)
            {
                if (policy.foodEffectAccept != 0 || policy.foodEffectReject != 0)
                {
                    icons[0].gameObject.SetActive(true);
                    effectCount++;
                }
                if (policy.cashEffectAccept != 0 || policy.cashEffectReject != 0)
                {
                    icons[1].gameObject.SetActive(true);
                    effectCount++;
                }
                if (policy.powerEffectAccept != 0 || policy.powerEffectReject != 0)
                {
                    icons[2].gameObject.SetActive(true);
                    effectCount++;
                }
                if (policy.industryEffectAccept != 0 || policy.industryEffectReject != 0)
                {
                    icons[3].gameObject.SetActive(true);
                    effectCount++;
                }
                if (policy.reputationEffectAccept != 0 || policy.reputationEffectReject != 0)
                {
                    icons[4].gameObject.SetActive(true);
                    effectCount++;
                }
                if (policy.pollutionEffectAccept != 0 || policy.pollutionEffectReject != 0)
                {
                    icons[5].gameObject.SetActive(true);
                    effectCount++;
                }
            }
        }

        if(cameraMovement.GetComponent<CameraMovement>().isActive == true)
        {
            effectCount = 0;
            foreach (var icon in icons)
            {
                icon.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }
}
