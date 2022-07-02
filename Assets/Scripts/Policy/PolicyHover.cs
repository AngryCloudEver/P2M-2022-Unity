using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyHover : MonoBehaviour
{
    
    public int policyId;
    public GameObject policies;
    public GameObject policyForDetail;
    public GameObject skipTurnButton;
    public GameObject cameraMovement;
    public GameObject SFX;

    private Policy[] allPolicies;
    private Policy chosenPolicy;

    // Start is called before the first frame update
    void Start()
    {
        if(policyId != 0)
        {
            allPolicies = policies.GetComponent<PolicyScript>().policies;
            chosenPolicy = searchPolicy(allPolicies, policyId);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(cameraMovement.GetComponent<CameraMovement>().isActive == true)
        {
            policyForDetail.SetActive(true);
            policyForDetail.GetComponent<PolicyDetail>().policy = chosenPolicy;
            skipTurnButton.GetComponent<SkipTurnButton>().policy = chosenPolicy;
            SFX.GetComponent<SoundEffects>().PlayPick();
        }
    }

    Policy searchPolicy(Policy[] allPolicies, int id)
    {
        foreach(var policy in allPolicies)
        {
            if(policy.id == id)
            {
                return policy;
            }
        }

        return null;
    }
}
