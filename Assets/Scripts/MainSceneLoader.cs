using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneLoader : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        DisplayHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayHighscore(){
        int highscore = PlayerPrefs.GetInt("Highscore",0);
        if(highscore!=0){
            scoreText.text = highscore + " Months";
        }
        else{
            scoreText.text = "N/A";
        }
    }
}
