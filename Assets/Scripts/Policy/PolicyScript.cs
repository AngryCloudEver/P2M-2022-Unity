using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyScript : MonoBehaviour
{
    public Policy[] policies = new Policy[]
    {
        new Policy(1, "RobbinFood",
            "RobbinFood,A series of thefts have been reported recently. Curiously, the stolen goods consists exclusively of food. Police investigations report the job was not particularly professional, but enough to stump them. This bill will authorize the hiring of additional personel to aid the theft investigations.",
            "PolicySource1",500,60,-1000,0,0,0,0,5,0,-3,0,0,0,-5
        ),
        new Policy(2, "PetroBigBro",
            "PetroBigBro,The fossil fuel industry is noticing the shift in attitude towards cleaner energy in the populace and is making anticipatory moves. Several of the largest oil companies are requesting an increase of oil price caps, potentially causing oil prices to soar to record high prices as they try to lose their stock while transitioning to the new markets. This bill will increase oil price caps to support companies while they transition.",
           "PolicySource2", 2000,50,5000,0,0,-3,0,8,0,0,0,0,-3,5
        ),
        new Policy(3,"RedGreenBurn",
            "RedGreenBurn,The sun shines in the bright blue sky. Unfortunately, it has spawned a bright red flame among the bright green leaves of the forest, causing massive damage to the environment. The central government is willing to aid, but a major part of the bill will still need to be footed by the local government. This bill will allow the formation of a joint firefighting force to deal with the forest fire.",
           "PolicySource1", 2000,60,-5000,0,0,10,0,5,0,0,0,30,0,-10
        ),
        new Policy(4,"PlantGrant",
            "PlantGrant,Your city has been invited to participate in an international tree planting competition in a bid to promote the dire need of regeneration of forests around the world. A lot of people are excited about the competition. This bill will formally declare the city's participation in the competition.",
           "PolicySource3", 2000,50,-2000,0,0,-8,0,3,0,0,0,-5,3,8
        ),
        new Policy(5,"TreeToFood",
            "TreeToFood,A major player in the food industry is eager to expand operations and is requesting a forest-clearing permit, concluding that the forest was too small to be productive for logging operations despite massive protests by various environmental impact analysis experts. They claim the extra space would allow them to produce food for less money and more efficiently and are threatening to take their business elsewhere if not allowed to grow. This bill will grant the company a forest-clearing permit.",
           "PolicySource3", 500,30,5000,0,0,8,10,-10,-2000,-5,0,0,-10,10
        ),
        new Policy(6,"NoWayHome",
            "NoWayHome,A neighborhood complained that the roads in their neighborhood have fallen into disrepair. A few people have taken the issue to social media and pressing the city's Public Infrastructures Department to take action, however the department advised that the repairs will require a section of a nearby river to be reclaimed, potentially destroying the habitat of various local fishes and reducing the amount of water that flows downstream. This bill will authorize road repairs for the neighborhood.",
           "PolicySource4", 500,50,-1000,0,0,3,0,5,0,0,0,0,-3,3
        ),
    };

    private Policy[] availablePolicies;
    private int numberOfPolicyThisTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
