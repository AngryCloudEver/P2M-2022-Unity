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
    private string isNewGame;
   
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("isNewGame") != null)
        {
            isNewGame = PlayerPrefs.GetString("isNewGame");
        }
        else
        {
            isNewGame = "true";
        }

        if(isNewGame == "true")
        {
            turn = 1;
        }
        else
        {
            turn = PlayerPrefs.GetInt("currentTurn",1);
        }

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
        if (turn == turnManagement.GetComponent<TurnManagement>().getTurn() || turn == -1)
        {
            if (policyCount != 0)
            {
                for(int i = 0; i < this.gameObject.transform.childCount; i++)
                {
                    Destroy(this.gameObject.transform.GetChild(i).gameObject);
                }
            }
            
            if(isNewGame == "false"){ //Game recently launched and has saved data
                availablePolicies = policyList.GetComponent<PolicyScript>().loadPolicies();
                isNewGame = "true";
            }
            else{
                if(turn != 1)
                {
                    stats.GetComponent<Status>().newTurn();
                }
                Policy.reduceTurnCooldown(policyList.GetComponent<PolicyScript>().policies);
                availablePolicies = policyList.GetComponent<PolicyScript>().getPolicies();
            }
            policyCount = availablePolicies.Length;

            foreach (var policy in availablePolicies)
            {
                source = getSource(policySource, policy.source);

                objectHeight = source.GetComponent<Collider>().bounds.size.y;

                policyLocation = Instantiate(policyHover, this.gameObject.transform);
                policyLocation.transform.position = new Vector3(source.transform.position.x + 50, objectHeight + 10 + (sourceUsedChosen * 20), source.transform.position.z);

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

    public void SaveAvailablePolicies()
    {
        PlayerPrefs.DeleteKey("firstPolicy");
        PlayerPrefs.DeleteKey("secondPolicy");
        PlayerPrefs.DeleteKey("thirdPolicy");
        if (availablePolicies.Length >= 1) { PlayerPrefs.SetInt("firstPolicy", availablePolicies[0].id); }
        if (availablePolicies.Length >= 2) { PlayerPrefs.SetInt("secondPolicy", availablePolicies[1].id); }
        if (availablePolicies.Length == 3) { PlayerPrefs.SetInt("thirdPolicy", availablePolicies[2].id); }
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
