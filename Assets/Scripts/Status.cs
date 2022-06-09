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
            this.playerAmount = this.defaultPlayerAmount = reputationPlayerAmount;
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

    static void AddPlayerPower(Power[] powers, int powerAmount)
    {
        if (powerAmount > 0)
        {
            for (int i = 0; i < powerAmount; i++)
            {
                bool powerReduced = false;

                while (powerReduced == false)
                {
                    var powerToUse = Random.Range(0, powers.Length);

                    if (powers[powerToUse].playerAmount > 0)
                    {
                        powers[powerToUse].playerAmount += 1;
                        powerReduced = true;
                    }
                }
            }
        }
        else if (powerAmount < 0)
        {
            for (int i = 0; i > powerAmount; i--)
            {
                bool powerReduced = false;

                while (powerReduced == false)
                {
                    var powerToUse = Random.Range(0, powers.Length);

                    if (powers[powerToUse].playerAmount > 0)
                    {
                        powers[powerToUse].playerAmount -= 1;
                        powerReduced = true;
                    }
                }
            }
        }
    }

    class Food
    {
        public int powerCost;
        public int moneyCost;
        public int playerAmount;
        private int defaultPlayerAmount;
        public int foodProduced;

        public Food(int foodPowerCost, int foodMoneyCost, int foodPlayerAmount, int foodProduce)
        {
            powerCost = foodPowerCost;
            moneyCost = foodMoneyCost;
            playerAmount = defaultPlayerAmount = foodPlayerAmount;
            foodProduced = foodProduce;
        }

        static public void resetFood(Food food)
        {
            food.playerAmount = food.defaultPlayerAmount;
        }
    }

    Food food = new Food(2, 600, 10, 3);
    Power[] powers = new Power[]{
        new Power("Oil",250,2,10),
        new Power("Tidal",500,1,3)
    };
    Money money = new Money(5000);
    Industry industry = new Industry(10);
    Reputation reputation = new Reputation(100);
    Pollution pollution = new Pollution(0);
    public int powerAmount, maxPowerAmount = 15;

    public GameObject turn;
    public Text moneyText, industryText, reputationText, pollutionText, powerText, turnText, foodText;
    int CalculatePower()
    {
        foreach (var power in powers)
        {
            powerAmount += power.playerAmount;
        }

        return powerAmount;
    }
    void DisplayStats()
    {
        moneyText.text = "Money: " + money.playerAmount;
        powerText.text = "Power: " + powerAmount + "/" + maxPowerAmount;
        industryText.text = "Industry: " + industry.playerAmount;
        reputationText.text = "Reputation: " + reputation.playerAmount;
        pollutionText.text = "Pollution: " + pollution.playerAmount;
        foodText.text = "Food: " + food.playerAmount;
        turnText.text = "Month " + turn.GetComponent<TurnManagement>().currentTurn;
        Debug.Log(reputationText.text);
    }

    public void AddMoney(int addedMoney)
    {
        money.playerAmount += addedMoney;

        if(money.playerAmount < 0)
        {
            money.playerAmount = 0;
        }
    }

    public bool CheckEnoughMoney(int cost)
    {
        if(money.playerAmount < cost)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void AddFood(int addedFood)
    {
        food.playerAmount += addedFood;
    }

    public void AddPower(int addedPower)
    {
        if(powerAmount + addedPower > maxPowerAmount)
        {
            AddPlayerPower(powers, maxPowerAmount - powerAmount);
        }
        else
        {
            AddPlayerPower(powers, addedPower);
        }
    }

    public void AddPollution(int addedPollution)
    {
        pollution.playerAmount += addedPollution;

        if (pollution.playerAmount < 0)
        {
            pollution.playerAmount = 0;
        }
    }

    public void AddIndustry(int addedIndustry)
    {
        industry.playerAmount += addedIndustry;

        if (industry.playerAmount < 0)
        {
            industry.playerAmount = 0;
        }
    }

    public void AddReputation(int addedReputation)
    {
        reputation.playerAmount += addedReputation;

        if (reputation.playerAmount < 0)
        {
            reputation.playerAmount = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CalculatePower();
        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
    }
}
