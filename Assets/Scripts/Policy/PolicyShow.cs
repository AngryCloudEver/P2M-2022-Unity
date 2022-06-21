using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyShow : MonoBehaviour
{
    public GameObject policyList;
    public GameObject policyHover;
    public GameObject[] policySource;
    public GameObject turnManagement;
    public GameObject stats;

    private Policy[] availablePolicies;
    private GameObject source;
    private GameObject policyLocation;
    private GameObject policyHoverTitle;
    private int turn;
    private int numberOfPolicyThisTurn;
    private int policyCount = 0;
    private int[] sourceUsed;
    private float objectHeight;

    private int sourceUsedChosen;

    // Start is called before the first frame update
    void Start()
    {
        turn = PlayerPrefs.GetInt("currentTurn",1);

        sourceUsed = new int[policySource.Length];

        for(int i = 0; i < policySource.Length; i++)
        {
            sourceUsed[i] = 0;
        }

        //policyHover.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        // Show New Policy while entering new turn
        if (turn == turnManagement.GetComponent<TurnManagement>().getTurn())
        {
            
        
            
            if (policyCount != 0)
            {
                for(int i = 0; i < this.gameObject.transform.childCount; i++)
                {
                    Destroy(this.gameObject.transform.GetChild(i).gameObject);
                }
                // Start Turn Productions
                
            }
           
            if(policyCount == 0 && PlayerPrefs.HasKey("firstPolicy")){ //Game recently launched and has saved data
                availablePolicies = policyList.GetComponent<PolicyScript>().loadPolicies();
            }
            else{
                stats.GetComponent<Status>().newTurn();
                Policy.reduceTurnCooldown(policyList.GetComponent<PolicyScript>().policies);
                availablePolicies = policyList.GetComponent<PolicyScript>().getPolicies();
            }
            policyCount = availablePolicies.Length;

            foreach (var policy in availablePolicies)
            {
                source = getSource(policySource, policy.source);

                objectHeight = source.GetComponent<Collider>().bounds.size.y;

                policyLocation = Instantiate(policyHover, this.gameObject.transform);
                policyLocation.transform.position = new Vector3(source.transform.position.x, objectHeight + 20 + (sourceUsedChosen * 20), source.transform.position.z);

                // Change Text Title
                policyHoverTitle = policyLocation.transform.GetChild(0).GetChild(0).gameObject;
                policyHoverTitle.GetComponent<UnityEngine.UI.Text>().text = policy.title;

                // Access Policy Script
                policyLocation.transform.GetChild(0).gameObject.GetComponent<PolicyHover>().policyId = policy.id;
            }

            turn++;
        }

        resetSourceUsed();
    }

    // Get Source From Policy's Source Name
    private GameObject getSource(GameObject[] sources, string sourceName)
    {
        int i = 0;

        foreach(var source in sources)
        {
            if(source.name == sourceName)
            {
                sourceUsed[i]++;
                sourceUsedChosen = sourceUsed[i];
                return source;
            }

            i++;
        }

        return null;
    }

    // Reset Source Used
    private void resetSourceUsed()
    {
        for (int i = 0; i < policySource.Length; i++)
        {
            sourceUsed[i] = 0;
        }
    }
}
