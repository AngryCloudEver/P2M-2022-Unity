using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyScript : MonoBehaviour
{
    public Policy[] policies = new Policy[]
    {
        new Policy(1, "RobbinFood",
            "A series of thefts have been reported recently. Curiously, the stolen goods consists exclusively of food. Police investigations report the job was not particularly professional, but enough to stump them. This bill will authorize the hiring of additional personel to aid the theft investigations.",
            "PolicySource5",1,-2,0,0,0,0,2,0,-3,0,0,0,-2
        ),
        new Policy(2, "PetroBigBro",
            "The fossil fuel industry is noticing the shift in attitude towards cleaner energy in the populace and is making anticipatory moves. Several of the largest oil companies are requesting an increase of oil price caps, potentially causing oil prices to soar to record high prices as they try to lose their stock while transitioning to the new markets. This bill will increase oil price caps to support companies while they transition.",
           "PolicySource1", 3,6,0,0,-1,0,3,0,0,0,0,-0.1f,1
        ),
        new Policy(3,"RedGreenBurn",
            "The sun shines in the bright blue sky. Unfortunately, it has spawned a bright red flame among the bright green leaves of the forest, causing massive damage to the environment. The central government is willing to aid, but a major part of the bill will still need to be footed by the local government. This bill will allow the formation of a joint firefighting force to deal with the forest fire.",
           "PolicySource2", 3,-6,0,0,4,0,2,0,0,0,10,0,-4
        ),
        new Policy(4,"PlantGrant",
            "Your city has been invited to participate in an international tree planting competition in a bid to promote the dire need of regeneration of forests around the world. A lot of people are excited about the competition. This bill will formally declare the city's participation in the competition.",
           "PolicySource5", 3, 0,0,0,0,0,0,0,0,0,-2,0.1f,-2
        ),
        new Policy(5,"TreeToFood",
            "A major player in the food industry is eager to expand operations and is requesting a forest-clearing permit, concluding that the forest was too small to be productive for logging operations despite massive protests by various environmental impact analysis experts. They claim the extra space would allow them to produce food for less money and more efficiently and are threatening to take their business elsewhere if not allowed to grow. This bill will grant the company a forest-clearing permit.",
           "PolicySource1", 1,6,0,0,3,0.4f,-4,-3,-5,0,0,-0.4f,4
        ),
        new Policy(6,"NoWayHome",
            "A neighborhood complained that the roads in their neighborhood have fallen into disrepair. A few people have taken the issue to social media and pressing the city's Public Infrastructures Department to take action, however the department advised that the repairs will require a section of a nearby river to be reclaimed, potentially destroying the habitat of various local fishes and reducing the amount of water that flows downstream. This bill will authorize road repairs for the neighborhood.",
           "PolicySource4", 1,-2,0,0,1,0,5,0,0,0,0,-0.1f,3
        ),
        new Policy(7,"FoodForPower",
            "An unexpected power outage dealt considerable damage to the cityÅfs food supplies. Fortunately, the city has access to an experimental machine that can compress energy back into matter. Unfortunately, it will cost a signigicant amount of energy to replenish the food supplies lost with the machine. This bill will authorize the lab owning the machine to tap into the cityÅfs power supplies to replenish the cityÅfs food supplies.",
           "PolicySource3", 1,0,3, -5,0,0,2,0,-4,0,0,0,-3
        ),
    };

    public Dictionary<int,Policy> policyDictionary = new Dictionary<int,Policy>(); // easier access to data values
    

    private Policy[] availablePolicies;
    private int numberOfPolicyThisTurn;

    
    // Start is called before the first frame update
    void Start()
    {
      AddToDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AddToDictionary(){ 
        for(int i=1; i<=policies.Length; i++){
            policyDictionary.Add(i, policies[i-1]);
        }
    }

    public void reduceCooldown()
    {
        Policy.reduceTurnCooldown(policies);
    }

    public Policy[] getPolicies()
    {
        availablePolicies = Policy.getAvailablePolicies(policies);

        if (availablePolicies.Length >= 3)
        {
            availablePolicies = Policy.getRandomPolicies(availablePolicies, 3);
        }
        else
        {
            availablePolicies = Policy.getRandomPolicies(availablePolicies, availablePolicies.Length);
        }

        return availablePolicies;
    }
    public Policy[] loadPolicies(){
        Policy[] savedPolicies = null;

        if (PlayerPrefs.HasKey("firstPolicy"))
        {
            int firstID = PlayerPrefs.GetInt("firstPolicy");

            if (PlayerPrefs.HasKey("secondPolicy"))
            {
                int secondID = PlayerPrefs.GetInt("secondPolicy");

                if (PlayerPrefs.HasKey("thirdPolicy"))
                {
                    int thirdID = PlayerPrefs.GetInt("thirdPolicy");

                    savedPolicies = new Policy[3];
                    savedPolicies[0] = policyDictionary[firstID];
                    savedPolicies[1] = policyDictionary[secondID];
                    savedPolicies[2] = policyDictionary[thirdID];
                }
                else
                {
                    savedPolicies = new Policy[2];
                    savedPolicies[0] = policyDictionary[firstID];
                    savedPolicies[1] = policyDictionary[secondID];
                }
            }
            else
            {
                savedPolicies = new Policy[1];
                savedPolicies[0] = policyDictionary[firstID];
            }
        }

        foreach(var policy in policies)
        {
            if (PlayerPrefs.HasKey(policy.title))
            {
                policy.cooldown = PlayerPrefs.GetInt(policy.title);
            }
        }

        return savedPolicies;
    }
    
    public void SaveCooldownPolicies()
    {
        foreach (var policy in policies)
        {
            PlayerPrefs.SetInt(policy.title, policy.cooldown);
        }
    }
}
