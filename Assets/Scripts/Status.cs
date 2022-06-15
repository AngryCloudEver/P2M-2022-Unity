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


<<<<<<< Updated upstream
=======
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

    // Food
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

    Food food = new Food(2, 600,10, 3);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
    }


=======
        foodText.text = "Food: " + food.playerAmount;
        turnText.text = "Month " + turn.GetComponent<TurnManagement>().currentTurn;
    }

    public void newTurn()
    {
        policyRng = 0;

        // Check Money Cap
        if (money.playerAmount < 0)
        {
            money.playerAmount = 0;
        }

        // Check Pollution Cap
        if (pollution.playerAmount < 0)
        {
            pollution.playerAmount = 0;
        }

        // Produce Power
        while (powerAmount < maxPowerAmount)
        {
            var chosenPower = Power.selectPowerToUse(powers, money.playerAmount);

            if (chosenPower == null)
            {
                break;
            }
            else
            {
                AddPower(1);
                chosenPower.playerAmount++;
                SubtractMoney(chosenPower.cost);
                AddPollution(chosenPower.pollution);
            }
        }

        // Produce Food
        if (powerAmount >= food.powerCost && money.playerAmount >= food.moneyCost)
        {
            AddFood(food.foodProduced);
            SubtractMoney(food.moneyCost);

            Power.AddPower(powers, food.powerCost * -1);

            SubtractPower(food.powerCost);
            AddMoney(Random.Range(minMoneyGainAfterProducingFood, maxMoneyGainAfterProducingFood));
        }

        // Generate Pollution
        randomRng = Random.Range(1, 4);
        AddPollution(randomRng);

        // Adjusting Policy RNG
        if (powerAmount >= 2 && food.playerAmount >= 3)
        {
            policyRng += 5; // 2 from power and 3 from food
        }
        else if (powerAmount >= 2 && food.playerAmount < 3)
        {
            policyRng -= 1; // 2 from power and -3 from food
        }
        else if (powerAmount < 2 && food.playerAmount >= 3)
        {
            policyRng += 1; // -2 from power and 3 from food
        }
        else
        {
            policyRng -= 5; // -2 from power and -3 from food
        }
    }

    public void AddMoney(int addedMoney)
    {
        money.playerAmount += addedMoney;

        if(money.playerAmount < 0)
        {
            money.playerAmount = 0;
        }
        PlayerPrefs.SetInt("money", money.playerAmount);
    }
    public void SubtractMoney(int subtractedMoney){
        money.playerAmount -= subtractedMoney;
        if(money.playerAmount < 0)
        {
            money.playerAmount = 0;
        }
        PlayerPrefs.SetInt("money", money.playerAmount);
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
        PlayerPrefs.SetInt("foodAmount",food.playerAmount);
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
        PlayerPrefs.SetInt("powerAmount", powerAmount + addedPower);
        
    }
    public void SubtractPower(int removedPower){
        powerAmount -= removedPower;
        PlayerPrefs.SetInt("powerAmount", powerAmount);
    }

    public void AddPollution(int addedPollution)
    {
        pollution.playerAmount += addedPollution;

        if (pollution.playerAmount < 0)
        {
            pollution.playerAmount = 0;
        }
        PlayerPrefs.SetInt("pollution", pollution.playerAmount);
        
    }


    public void AddIndustry(int addedIndustry)
    {
        industry.playerAmount += addedIndustry;

        if (industry.playerAmount < 0)
        {
            industry.playerAmount = 0;
        }
        PlayerPrefs.SetInt("industry",industry.playerAmount);
    }

    public void AddReputation(int addedReputation)
    {
        reputation.playerAmount += addedReputation;

        if (reputation.playerAmount < 0)
        {
            reputation.playerAmount = 0;
        }
        PlayerPrefs.SetInt("reputation", reputation.playerAmount);
    }
    

    
    void LoadData(){
        money.playerAmount = PlayerPrefs.GetInt("money");
        food.playerAmount = PlayerPrefs.GetInt("foodAmount");
        pollution.playerAmount = PlayerPrefs.GetInt("pollution");
        industry.playerAmount = PlayerPrefs.GetInt("industry");
        reputation.playerAmount = PlayerPrefs.GetInt("reputation");
    }
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
=======
        CalculatePower();
        LoadData();
>>>>>>> Stashed changes
        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
