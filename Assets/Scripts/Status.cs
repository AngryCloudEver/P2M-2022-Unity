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
                        // if(powers[powerToUse].name.Equals("Oil")){
                        //         PlayerPrefs.SetInt("Oil",powers[powerToUse].playerAmount);
                        //     }
                        // if(powers[powerToUse].name.Equals("Tidal")){
                        //         PlayerPrefs.SetInt("Tidal",powers[powerToUse].playerAmount);
                        //     }
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
                        // if(powers[powerToUse].name.Equals("Oil")){
                        //         PlayerPrefs.SetInt("Oil",powers[powerToUse].playerAmount);
                        //     }
                        // if(powers[powerToUse].name.Equals("Tidal")){
                        //         PlayerPrefs.SetInt("Tidal",powers[powerToUse].playerAmount);
                        // }
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
    Money money = new Money(10);
    Industry industry = new Industry(1f);
    Reputation reputation = new Reputation(20);
    Pollution pollution = new Pollution(10);
    public int powerAmount, maxPowerAmount = 20;
    public int minMoneyGainAfterProducingFood = -3;
    public int maxMoneyGainAfterProducingFood = 3;

    private int randomRng;

    public GameObject turn, policyShow, policyStatus;
    public Text moneyText, industryText, reputationText, pollutionText, powerText, turnText, foodText;

    public int gameOverText = -1;

    // Menghitung jumlah total power
    int CalculatePower()
    {
        foreach (var power in powers)
        {
            power.playerAmount = power.playerAmount;
            powerAmount += power.playerAmount;
        }

        return powerAmount;
    }
    void DisplayStats()
    {
        moneyText.text = "" + money.playerAmount;
        powerText.text = "" + powerAmount + "/" + maxPowerAmount;
        industryText.text = "" + Mathf.Round(industry.playerAmount);
        reputationText.text = "" + reputation.playerAmount + "/30";
        pollutionText.text = "" + pollution.playerAmount;
        foodText.text = "" + food.playerAmount + "/20";
        turnText.text = "Month " + turn.GetComponent<TurnManagement>().getTurn();
    }

    public void newTurn()
    {
        // Check Debt Status
        if(money.playerAmount<0 == false){ //As long as the player isn't in debt, power and food will be generated
            // Produce Power
        if(powerAmount < 20)
        {
            for (int i = 0; i < Mathf.RoundToInt(industry.playerAmount); i++)
            {
                Power chosenPower = null;

                do
                {
                    chosenPower = Power.selectPowerToUse(powers, money.playerAmount);

                    if (chosenPower != null)
                    {
                        AddPowerAmount(Mathf.RoundToInt(1 * industry.playerAmount));
                        chosenPower.playerAmount++;
                        PlayerPrefs.SetInt(chosenPower.name, chosenPower.playerAmount);
                        SubtractMoney(chosenPower.cost);
                        AddPollution(chosenPower.pollution);
                        powerAmount++;
                    }
                } while (chosenPower == null);

                if(powerAmount == 20)
                {
                    i = Mathf.RoundToInt(industry.playerAmount);
                }
            }
        }

        // Produce Food
        if (food.playerAmount < 20)
        {
            AddFood(Mathf.RoundToInt(food.foodProduced * industry.playerAmount));
            SubtractMoney(food.moneyCost);

            Power.AddPower(powers, food.powerCost * -1);

            SubtractPowerAmount(food.powerCost);
            AddMoney(Random.Range(minMoneyGainAfterProducingFood, maxMoneyGainAfterProducingFood));

            // Pollution from producing food
            AddPollution(1);
        }
        }
        
        
        

        // Pollution Dissipates Reduction
        AddPollution(-1);

        // Check Money Cap
        if (money.playerAmount > 20)
        {
            money.playerAmount = 20;
        }

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
        if (reputation.playerAmount > 30)
        {
            reputation.playerAmount = 30;
        }

        // Check Power Cap
        while (powerAmount > 20)
        {
            Power.AddPower(powers, -1);
            powerAmount--;
        }

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

    public void FactoryReset(){ //for testing purposes
        // PlayerPrefs.DeleteKey("firstPolicy");
        // PlayerPrefs.DeleteKey("secondPolicy");
        // PlayerPrefs.DeleteKey("thirdPolicy");
        // PlayerPrefs.DeleteKey("Oil");
        // PlayerPrefs.DeleteKey("Tidal");
        // PlayerPrefs.DeleteKey("money");
        // PlayerPrefs.DeleteKey("foodAmount");
        // PlayerPrefs.DeleteKey("pollution");
        // PlayerPrefs.DeleteKey("industry");
        // PlayerPrefs.DeleteKey("reputation");
        money.playerAmount = 10;
        food.playerAmount = 10;
        pollution.playerAmount = 10;
        industry.playerAmount = 1f;
        reputation.playerAmount = 20;
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
