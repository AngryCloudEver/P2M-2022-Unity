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

    Money money = new Money(5000);
    Industry industry = new Industry(10);
    Reputation reputation = new Reputation(100);
    Pollution pollution = new Pollution(0);
    public Text moneyText, industryText, reputationText, pollutionText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "Money: " + money.playerAmount.ToString();
        industryText.text = "Industry: " + industry.playerAmount.ToString();
        reputationText.text = "Reputation: " + reputation.playerAmount.ToString();
        pollutionText.text = "Pollution: " + pollution.playerAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
