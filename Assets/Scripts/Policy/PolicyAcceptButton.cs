using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyAcceptButton : MonoBehaviour
{
    public GameObject stats;
    public GameObject cameraMovement;
    public GameObject turnManagement;

    private Policy policyChosen;
    private int RNG;

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
            if(policyChosen.id == 4)
            {
                RNG = Random.Range(1, 4);

                // Lose
                if(RNG == 1)
                {
                    stats.GetComponent<Status>().AddMoney(-3);

                }
                // Rank 1
                else if(RNG == 2)
                {
                    stats.GetComponent<Status>().AddMoney(7);
                }
                // Rank 2
                else if(RNG == 3)
                {
                    stats.GetComponent<Status>().AddMoney(5);
                }
                else if (RNG == 4)
                {
                    stats.GetComponent<Status>().AddMoney(3);
                }

                stats.GetComponent<Status>().AddFood(0);
                stats.GetComponent<Status>().AddPower(0);
                stats.GetComponent<Status>().AddPollution(-3);
                stats.GetComponent<Status>().AddIndustry(0);
                stats.GetComponent<Status>().AddReputation(1);
            }
            else
            {
                stats.GetComponent<Status>().AddMoney(policyChosen.cashCost * -1);
                stats.GetComponent<Status>().AddMoney(policyChosen.cashEffectAccept);
                stats.GetComponent<Status>().AddFood(policyChosen.foodEffectAccept);
                stats.GetComponent<Status>().AddPower(policyChosen.powerEffectAccept);
                stats.GetComponent<Status>().AddPollution(policyChosen.pollutionEffectAccept);
                stats.GetComponent<Status>().AddIndustry(policyChosen.industryEffectAccept);
                stats.GetComponent<Status>().AddReputation(policyChosen.reputationEffectAccept);
            }
            policyChosen.cooldown += 2;
            /*PlayerPrefs.SetInt(policyChosen.title, policyChosen.cooldown);*/

            turnManagement.GetComponent<TurnManagement>().AddTurn();
        }
    }
}
