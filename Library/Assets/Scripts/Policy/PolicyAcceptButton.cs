using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyAcceptButton : MonoBehaviour
{
    public GameObject stats;
    public GameObject cameraMovement;
    public GameObject turnManagement;

    private Policy policyChosen;
    private int popularityRng;

    // Start is called before the first frame update
    void Start()
    {
        policyChosen = gameObject.GetComponentInParent<PolicyDetail>().policy;
    }

    // Update is called once per frame
    void Update()
    {
        if(policyChosen != gameObject.GetComponentInParent<PolicyDetail>().policy)
        {
            policyChosen = gameObject.GetComponentInParent<PolicyDetail>().policy;
        }
    }

    void OnMouseDown()
    {
        if(stats.GetComponent<Status>().CheckEnoughMoney(policyChosen.cashCost) == true)
        {
            cameraMovement.GetComponent<CameraMovement>().isActive = true;
            gameObject.transform.parent.gameObject.SetActive(false);

            // Applying Effects
            stats.GetComponent<Status>().AddMoney(policyChosen.cashCost * -1);
            stats.GetComponent<Status>().AddMoney(policyChosen.cashEffectAccept);
            stats.GetComponent<Status>().AddFood(policyChosen.foodEffectAccept);
            stats.GetComponent<Status>().AddPower(policyChosen.powerEffectAccept);
            stats.GetComponent<Status>().AddPollution(policyChosen.pollutionEffectAccept);
            stats.GetComponent<Status>().AddIndustry(policyChosen.industryEffectAccept);
            stats.GetComponent<Status>().AddReputation(policyChosen.reputationEffectAccept);
            policyChosen.cooldown += 2;
            PlayerPrefs.SetInt(policyChosen.title, policyChosen.cooldown);

            

            // Popularity Effect
            if (policyChosen.popularity >= 50)
            {
                popularityRng = Random.Range(5, 15);
            }
            else if (policyChosen.popularity < 50)
            {
                popularityRng = Random.Range(-15, -5);
            }

            stats.GetComponent<Status>().AddReputation(popularityRng);

            turnManagement.GetComponent<TurnManagement>().AddTurn();
        }
    }
}
