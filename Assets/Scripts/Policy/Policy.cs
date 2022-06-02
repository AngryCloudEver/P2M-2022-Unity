using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policy
{
    // Must Have
    public int id;
    public string title;
    public string description;
    public string source;
    public int cashCost;
    public int popularity;

    // Stats Affected
    public int cashEffectAccept, foodEffectAccept, powerEffectAccept, pollutionEffectAccept, industryEffectAccept, reputationEffectAccept;
    public int cashEffectReject, foodEffectReject, powerEffectReject, pollutionEffectReject, industryEffectReject, reputationEffectReject;

    public int cooldown;

    // Constructor
    public Policy(int id, string title, string description, string source, int cashCost, int popularity, int cashEffectAccept, int foodEffectAccept, int powerEffectAccept, int pollutionEffectAccept, int industryEffectAccept, int reputationEffectAccept, int cashEffectReject, int foodEffectReject, int powerEffectReject, int pollutionEffectReject, int industryEffectReject, int reputationEffectReject)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.source = source;
        this.cashCost = cashCost;
        this.popularity = popularity;

        this.cashEffectAccept = cashEffectAccept;
        this.foodEffectAccept = foodEffectAccept;
        this.powerEffectAccept = powerEffectAccept;
        this.pollutionEffectAccept = pollutionEffectAccept;
        this.industryEffectAccept = industryEffectAccept;
        this.reputationEffectAccept = reputationEffectAccept;

        this.cashEffectReject = cashEffectReject;
        this.foodEffectReject = foodEffectReject;
        this.powerEffectReject = powerEffectReject;
        this.pollutionEffectReject = pollutionEffectReject;
        this.industryEffectReject = industryEffectReject;
        this.reputationEffectReject = reputationEffectReject;

        this.cooldown = 0;
    }

    static public Policy[] getAvailablePolicies(Policy[] policies)
    {
        Policy[] availablePolicies = new Policy[policies.Length];
        int index = 0;

        foreach (var policy in policies)
        {
            if (policy.cooldown == 0)
            {
                availablePolicies[index++] = policy;
            }
        }

        Policy[] policiesToUse = new Policy[index];

        for (int i = 0; i < index; i++)
        {
            policiesToUse[i] = availablePolicies[i];
        }

        return policiesToUse;
    }

    static public Policy[] getRandomPolicies(Policy[] policies, int numberOfPolicies)
    {
        Policy[] chosenPolicies = new Policy[numberOfPolicies];
        int number = 0;

        for (int i = 0; i < numberOfPolicies; i++)
        {
            bool policyChosen = false;

            while (policyChosen == false)
            {
                number = Random.Range(0, policies.Length);

                if (policies[number].cooldown == 0)
                {
                    chosenPolicies[i] = policies[number];
                    policyChosen = true;
                    policies[number].cooldown = 2;
                }
            }
        }

        return chosenPolicies;
    }

    static public void reduceTurnCooldown(Policy[] policies)
    {
        foreach (var policy in policies)
        {
            if (policy.cooldown > 0)
            {
                policy.cooldown--;
            }
        }
    }
}
