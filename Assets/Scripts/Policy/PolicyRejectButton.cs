using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyRejectButton : MonoBehaviour
{
    public GameObject stats;
    public GameObject cameraMovement;
    public GameObject turnManagement;

    private Policy policyChosen;

    // Start is called before the first frame update
    void Start()
    {
        policyChosen = gameObject.GetComponentInParent<PolicyDetail>().policy;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (policyChosen != gameObject.GetComponentInParent<PolicyDetail>().policy)
        {
            policyChosen = gameObject.GetComponentInParent<PolicyDetail>().policy;
        }
    }

    void OnMouseDown()
    {
        if (stats.GetComponent<Status>().CheckEnoughMoney(policyChosen.cashCost) == true)
        {
            cameraMovement.GetComponent<CameraMovement>().isActive = true;
            gameObject.transform.parent.gameObject.SetActive(false);

            // Applying Effects
            stats.GetComponent<Status>().AddMoney(policyChosen.cashCost * -1);
            stats.GetComponent<Status>().AddMoney(policyChosen.cashEffectReject);
            stats.GetComponent<Status>().AddFood(policyChosen.foodEffectReject);
            stats.GetComponent<Status>().AddPower(policyChosen.powerEffectReject);
            stats.GetComponent<Status>().AddPollution(policyChosen.pollutionEffectReject);
            stats.GetComponent<Status>().AddIndustry(policyChosen.industryEffectReject);
            stats.GetComponent<Status>().AddReputation(policyChosen.reputationEffectReject);
            policyChosen.cooldown += 2;
            PlayerPrefs.SetInt(policyChosen.title, policyChosen.cooldown);

            turnManagement.GetComponent<TurnManagement>().AddTurn();
        }
    }
}
