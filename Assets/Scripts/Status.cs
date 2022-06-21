using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Status : MonoBehaviour
{
    // Money
    class Money

    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Money(int moneyPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = moneyPlayerAmount;
        }
    }

    // Industry
    class Industry
    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Industry(int industryPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = industryPlayerAmount;
        }
    }

    // Reputation
    class Reputation
    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Reputation(int reputationPlayerAmount)
        {
            this.playerAmount = this.defaultPlayerAmount = reputationPlayerAmount;
        }


    }

    // Pollution
    class Pollution
    {
        public int playerAmount;
        private int defaultPlayerAmount;

        public Pollution(int pollutionPlayerAmount)
        {
            playerAmount = defaultPlayerAmount = pollutionPlayerAmount;
        }
    }

    // Power
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

        static public Power selectPowerToUse(Power[] powers, int money)
        {
            Power chosenPower = null;
            int minPollution = -1;
            int RNG = 0;

            foreach (var power in powers)
            {
                if (minPollution == -1)
                {
                    if (money >= power.cost)
                    {
                        minPollution = power.pollution;
                        chosenPower = power;
                    }
                }
                else
                {
                    if (minPollution > power.pollution && money >= power.cost)
                    {
                        minPollution = power.pollution;
                        chosenPower = power;
                    }
                }
            }

            RNG = Random.Range(0, powers.Length + 2);

            if (RNG < powers.Length && powers[RNG] != chosenPower && money >= powers[RNG].cost)
            {
                return powers[RNG];
            }

            return chosenPower;
        }

        static public void AddPower(Power[] powers, int powerAmount)
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
                            if(powers[powerToUse].name.Equals("Oil")){
                                PlayerPrefs.SetInt("Oil",powers[powerToUse].playerAmount);
                            }
                            if(powers[powerToUse].name.Equals("Tidal")){
                                PlayerPrefs.SetInt("Tidal",powers[powerToUse].playerAmount);
                            }
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
                         if(powers[powerToUse].name.Equals("Oil")){
                                PlayerPrefs.SetInt("Oil",powers[powerToUse].playerAmount);
                            }
                         if(powers[powerToUse].name.Equals("Tidal")){
                                PlayerPrefs.SetInt("Tidal",powers[powerToUse].playerAmount);
                            }
                            powerReduced = true;
                        }
                    }
                }
            }
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
                        if(powers[powerToUse].name.Equals("Oil")){
                                PlayerPrefs.SetInt("Oil",powers[powerToUse].playerAmount);
                            }
                        if(powers[powerToUse].name.Equals("Tidal")){
                                PlayerPrefs.SetInt("Tidal",powers[powerToUse].playerAmount);
                            }
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
                        if(powers[powerToUse].name.Equals("Oil")){
                                PlayerPrefs.SetInt("Oil",powers[powerToUse].playerAmount);
                            }
                        if(powers[powerToUse].name.Equals("Tidal")){
                                PlayerPrefs.SetInt("Tidal",powers[powerToUse].playerAmount);
                        }
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

    Food food = new Food(2, 600, 10, 3);
    Power[] powers = new Power[]{
        new Power("Oil",250,2,10),
        new Power("Tidal",500,1,3)
    };
    Money money = new Money(5000);
    Industry industry = new Industry(10);
    Reputation reputation = new Reputation(100);
    Pollution pollution = new Pollution(0);
    public int powerAmount, maxPowerAmount = 15, policyRng = 0;
    public int minMoneyGainAfterProducingFood = 1000;
    public int maxMoneyGainAfterProducingFood = 2000;

    private int randomRng;

    public GameObject turn;
    public Text moneyText, industryText, reputationText, pollutionText, powerText, turnText, foodText;

    // Menghitung jumlah total power
    int CalculatePower()
    {
        foreach (var power in powers)
        {
            power.playerAmount = PlayerPrefs.GetInt(power.name,power.playerAmount);
            powerAmount += power.playerAmount;
        }

        return powerAmount;
    }
    void DisplayStats()
    {
        moneyText.text = "" + money.playerAmount;
        powerText.text = "" + powerAmount + "/" + maxPowerAmount;
        industryText.text = "" + industry.playerAmount;
        reputationText.text = "" + reputation.playerAmount;
        pollutionText.text = "" + pollution.playerAmount;
        foodText.text = "" + food.playerAmount;
        turnText.text = "Month " + turn.GetComponent<TurnManagement>().getTurn();
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
                AddPowerAmount(1);
                chosenPower.playerAmount++;
                PlayerPrefs.SetInt(chosenPower.name,chosenPower.playerAmount);
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

            SubtractPowerAmount(food.powerCost);
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
        PlayerPrefs.SetInt("money",money.playerAmount);
    }

    public void SubtractMoney(int subtractedMoney)
    {
        money.playerAmount -= subtractedMoney;

        if(money.playerAmount < 0)
        {
            money.playerAmount = 0;
        }
        PlayerPrefs.SetInt("money",money.playerAmount);
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
        PlayerPrefs.SetInt("foodAmount", food.playerAmount);
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

    public void AddPowerAmount(int addedPower){
        powerAmount += addedPower;
        
    }

    public void SubtractPowerAmount (int removedPower){
        powerAmount -= removedPower;
        
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
        money.playerAmount = PlayerPrefs.GetInt("money",5000);
        food.playerAmount = PlayerPrefs.GetInt("foodAmount",60);
        pollution.playerAmount = PlayerPrefs.GetInt("pollution",0);
        industry.playerAmount = PlayerPrefs.GetInt("industry", 10);
        reputation.playerAmount = PlayerPrefs.GetInt("reputation",100);
    }

    public void FactoryReset(){ //for testing purposes
        money.playerAmount = 5000;
        food.playerAmount = 60;
        pollution.playerAmount = 0;
        industry.playerAmount = 10;
        reputation.playerAmount = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        CalculatePower();
        LoadData();
        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
    }
}
