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
        public float playerAmount;
        private float defaultPlayerAmount;

        public Industry(float industryPlayerAmount)
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
        public bool restricted;

        private int defaultPlayerAmount;

        public Power(string powerName, int powerCost, int powerPollution, int powerPlayerAmount)
        {
            name = powerName;
            cost = powerCost;
            pollution = powerPollution;
            playerAmount = defaultPlayerAmount = powerPlayerAmount;
            restricted = false;
        }

        static public Power selectPowerToUse(Power[] powers, int money)
        {
            Power chosenPower = null;
            int RNG = 0;

            RNG = Random.Range(1, 10);

            if (RNG == 1)
            {
                return powers[0];
            }
            if ((RNG > 1 && RNG < 6))
            {
                return powers[1];
            }
            if (RNG > 6)
            {
                return powers[2];
            }

            return chosenPower;
        }

        static public void resetRestricted(Power[] powers)
        {
            foreach(var power in powers)
            {
                power.restricted = false;
            }
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

    Food food = new Food(1, 2, 10, 2);
    Power[] powers = new Power[]{
        new Power("Coal",1,2,1),
        new Power("Hydro",2,1,3),
        new Power("Solar",3,0,6)
    };
    Money money = new Money(50);
    Industry industry = new Industry(1f);
    Reputation reputation = new Reputation(20);
    Pollution pollution = new Pollution(10);
    public int powerAmount, maxPowerAmount = 20;
    public int maxReputation = 99;
    public int minMoneyGainAfterProducingFood = -3;
    public int maxMoneyGainAfterProducingFood = 9;

    private int randomRng;

    public GameObject turn, policyShow, policyStatus;
    public Text moneyText, industryText, reputationText, pollutionText, powerText, turnText, foodText;

    public int gameOverText = -1;

    // Menghitung jumlah total power
    int CalculatePower()
    {
        powerAmount = 0;

        foreach (var power in powers)
        {
            powerAmount += power.playerAmount;
        }

        return powerAmount;
    }
    void DisplayStats()
    {
        moneyText.text = "" + money.playerAmount;
        powerText.text = "" + CalculatePower() + "/" + maxPowerAmount;
        industryText.text = "" + Mathf.Round(industry.playerAmount);
        reputationText.text = "" + reputation.playerAmount + "/" + maxReputation;
        pollutionText.text = "" + pollution.playerAmount;
        foodText.text = "" + food.playerAmount + "/20";
        turnText.text = "Month " + turn.GetComponent<TurnManagement>().getTurn();
    }

    
    public void newTurn()
    {
        // Check Food Cap
        if (food.playerAmount > 20)
        {
            food.playerAmount = 20;
        }

        // Check Industry Cap
        if (industry.playerAmount > 3f)
        {
            industry.playerAmount = 3f;
        }

        // Check Reputation Cap
        if (reputation.playerAmount > maxReputation)
        {
            reputation.playerAmount = maxReputation;
        }

        // Check Power Cap
        while (powerAmount > 20)
        {
            Power.AddPower(powers, -1);
        }
        Power.resetRestricted(powers);

        // Vibe Check
        if (money.playerAmount < -10)
        {
            gameOverText = 1;
        }
        if (food.playerAmount < -10)
        {
            gameOverText = 2;
        }
        if (reputation.playerAmount < 0)
        {
            gameOverText = 3;
        }
        if (pollution.playerAmount < 1)
        {
            gameOverText = 4;
        }
        if (pollution.playerAmount > 20)
        {
            gameOverText = 5;
        }
    }

    public void industryEffect()
    {
        // Check Debt Status
        if(money.playerAmount > 0){ //As long as the player isn't in debt, power and food will be generated
            
            // Produce Power
            if(CalculatePower() < 20)
            {
                

                for (int i = 0; i < 3; i++)
                {
                    Power chosenPower = null;

                    do
                    {
                        chosenPower = Power.selectPowerToUse(powers, money.playerAmount);

                        if(chosenPower != null && chosenPower.restricted == true)
                        {
                            chosenPower = null;
                        }

                        if (chosenPower != null)
                        {
                            AddPowerAmount(Mathf.RoundToInt(1 * industry.playerAmount));
                            chosenPower.playerAmount++;
                            chosenPower.restricted = true;
                            SubtractMoney(chosenPower.cost);
                            AddPollution(chosenPower.pollution);
                        }
                    } while (chosenPower == null);

                    if(CalculatePower() >= 20 || money.playerAmount <= 0)
                    {
                        i = 3;
                    }
                }
            }
            else{ //Produce Power's Idle Pollution
                AddPollution(Random.Range(1, 3)); //Coal's Idle Pollution
                AddPollution(Random.Range(0, 2)); //Hydro's Idle Pollution
            }

            // Produce Food's Idle Pollution
            if(money.playerAmount < food.moneyCost)
            { 
                AddPollution(Random.Range(0,2));
            }
            else
            {
                // Produce Food
                if (food.playerAmount < 20)
                {
                    AddFood(Mathf.RoundToInt(food.foodProduced * industry.playerAmount));
                    SubtractMoney(food.moneyCost);

                    Power.AddPower(powers, food.powerCost * -1);

                    AddMoney(Random.Range(minMoneyGainAfterProducingFood, maxMoneyGainAfterProducingFood + 1));

                    // Pollution from producing food
                    AddPollution(1);
                }
            }
        }
        else
        {
            // Produce Idle Pollution
            AddPollution(Random.Range(1, 3)); //Coal's Idle Pollution
            AddPollution(Random.Range(0, 2)); //Hydro's Idle Pollution
            AddPollution(Random.Range(0, 2)); //Food's Idle Pollution
        }

        // Pollution Dissipates Reduction
        AddPollution(-1);
        
        
    }

    public void AddMoney(int addedMoney)
    {
        money.playerAmount += addedMoney;
    }

    public void SubtractMoney(int subtractedMoney)
    {
        money.playerAmount -= subtractedMoney;        
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

    public void AddPowerAmount(int addedPower){
        powerAmount += addedPower;
        
    }

    public void SubtractPowerAmount (int removedPower){
        powerAmount -= removedPower;
    }

    public void AddPollution(int addedPollution)
    {
        pollution.playerAmount += addedPollution;
      
    }

    public void AddIndustry(float addedIndustry)
    {
        industry.playerAmount += addedIndustry;
    }
        

    public void AddReputation(int addedReputation)
    {
        reputation.playerAmount += addedReputation;     
    }
    public void SaveData(){

        foreach (var power in powers)
        {
            PlayerPrefs.SetInt(power.name,power.playerAmount);
        }
        PlayerPrefs.SetInt("money",money.playerAmount);
        PlayerPrefs.SetInt("foodAmount", food.playerAmount);
        PlayerPrefs.SetInt("pollution", pollution.playerAmount);
        PlayerPrefs.SetFloat("industry",industry.playerAmount);
        PlayerPrefs.SetInt("reputation", reputation.playerAmount);
        policyShow.GetComponent<PolicyShow>().SaveAvailablePolicies();
        policyStatus.GetComponent<PolicyScript>().SaveCooldownPolicies();
    }
    public void LoadData(){
        int tempPowerAmount = 0;
        foreach (var power in powers)
        {
            power.playerAmount = PlayerPrefs.GetInt(power.name,power.playerAmount);
            tempPowerAmount += power.playerAmount;
        }
        powerAmount = tempPowerAmount;
        money.playerAmount = PlayerPrefs.GetInt("money",10);
        food.playerAmount = PlayerPrefs.GetInt("foodAmount",10);
        pollution.playerAmount = PlayerPrefs.GetInt("pollution",10);
        industry.playerAmount = PlayerPrefs.GetFloat("industry", 1f);
        reputation.playerAmount = PlayerPrefs.GetInt("reputation",20);
    }

    

    // Start is called before the first frame update
    void Start()
    {
        CalculatePower();
        string isNewGame = PlayerPrefs.GetString("isNewGame");
        if(isNewGame == "false"){
            LoadData();
        }

        gameOverText = -1;

        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
    }
}
