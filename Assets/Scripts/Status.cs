using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Status : MonoBehaviour
{
    class Money

    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Money(int moneyPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = moneyPlayerAmount;
        }
    }
    class Industry
    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Industry(int industryPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = industryPlayerAmount;
        }
    }
    class Reputation
    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Reputation(int reputationPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = reputationPlayerAmount;
        }


    }
    class Pollution
    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Pollution(int pollutionPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = pollutionPlayerAmount;
        }
    }
    class Power
    {
        public string name;
        public int cost;
        public int pollution;
        public int playerAmount;

        private int defaultPlayerAmount;

        public Power(string powerName, int powerCost, int powerPollution, int powerPlayerAmount)
        {
            name = powerName;
            cost = powerCost;
            pollution = powerPollution;
            playerAmount = defaultPlayerAmount = powerPlayerAmount;
        }
    }


    Power[] powers = new Power[]{
        new Power("Oil",250,2,10),
        new Power("Tidal",500,1,3)
};
    Money money = new Money(5000);
    Industry industry = new Industry(10);
    Reputation reputation = new Reputation(100);
    Pollution pollution = new Pollution(0);
    int powerAmount, maxPowerAmount = 15;


    public Text moneyText, industryText, reputationText, pollutionText, powerText;
    void CalculatePower()
    {
        foreach (var power in powers)
        {
            powerAmount += power.playerAmount;
        }
        powerText.text = "Power: " + powerAmount + "/" + maxPowerAmount;
    }
    void DisplayStats()
    {
        CalculatePower();
        moneyText.text = "Money: " + money.playerAmount;
        industryText.text = "Industry: " + industry.playerAmount;
        reputationText.text = "Reputation: " + reputation.playerAmount;
        pollutionText.text = "Pollution: " + pollution.playerAmount;
    }



    // Start is called before the first frame update
    void Start()
    {
        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
