using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyShow : MonoBehaviour
{
    public GameObject policyList;
    public GameObject policyHover;
    public GameObject[] policySource;
    public GameObject turnManagement;

    private Policy[] availablePolicies;
    private GameObject source;
    private GameObject policyLocation;
    private GameObject policyHoverTitle;
    private int turn;
    private int numberOfPolicyThisTurn;
    private int[] sourceUsed;

    private int sourceUsedChosen;

    // Start is called before the first frame update
    void Start()
    {
        turn = 1;

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
            availablePolicies = policyList.GetComponent<PolicyScript>().getPolicies();

            foreach (var policy in availablePolicies)
            {
                source = getSource(policySource, policy.source);
                policyLocation = Instantiate(policyHover, this.gameObject.transform);
                policyLocation.transform.position = new Vector3(source.transform.position.x, source.transform.position.y + (sourceUsedChosen * 25), source.transform.position.z);

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

    private void resetSourceUsed()
    {
        for (int i = 0; i < policySource.Length; i++)
        {
            sourceUsed[i] = 0;
        }
    }
}
