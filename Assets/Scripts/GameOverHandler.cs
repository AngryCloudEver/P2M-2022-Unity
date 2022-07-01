using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public GameObject cameraMovement;
    public GameObject statusCanvas;
    public GameObject pauseCanvas;

    public Text winTitle, winDescription;

    public int gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameOverText = -1;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverText = statusCanvas.GetComponent<Status>().gameOverText;
        if (gameOverText != -1)
        {
            SetGameOver(false, gameOverText);
        }
    }

    void SetGameOver(bool isWin, int gameOverContent)
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        cameraMovement.GetComponent<CameraMovement>().isActive = false;
        statusCanvas.SetActive(false);
        pauseCanvas.SetActive(false);

        if(isWin == false)
        {
            winTitle.text = "YOU LOSE!";
        }
        else
        {
            winTitle.text = "YOU WIN!";
        }

        if(gameOverContent == 1)
        {
            winDescription.text = "You have no money left, your city went into bankruptcy!";
        }
        else if(gameOverContent == 2)
        {
            winDescription.text = "You have no food left, your people are starving!";
        }
        else if(gameOverContent == 3)
        {
            winDescription.text = "Your people don't trust you anymore, your authority is overthrown!";
        }
        else if(gameOverContent == 5)
        {
            winDescription.text = "The city is too polluted, your city is not an Eco City anymore!";
        }
        else if(gameOverContent == 4)
        {
            winDescription.text = "You successfully cleaned the city, your city is free from pollution!";
        }
    }
}
