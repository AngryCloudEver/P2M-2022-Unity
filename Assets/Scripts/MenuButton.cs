using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    public GameObject cameraMovement;
    public Text pauseButtonText;

    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame(){
        PlayerPrefs.SetString("isNewGame", "true");
        SceneManager.LoadScene("DevScene");
    }
    async public void LoadGame(){
        if(PlayerPrefs.HasKey("firstPolicy")){
          PlayerPrefs.SetString("isNewGame", "false");
          SceneManager.LoadScene("DevScene");
        }
        
    }
    public void PauseGame(){
        isPaused = !isPaused;
        if(isPaused){
            pauseButtonText.text = "RESUME";
            cameraMovement.GetComponent<CameraMovement>().isActive = false;
        }
        else{
            pauseButtonText.text = "PAUSE";
            cameraMovement.GetComponent<CameraMovement>().isActive = true;
        }
        
    }
    public void OpenCredit(){
        SceneManager.LoadScene("CreditScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void OpenMain(){
        SceneManager.LoadScene("MainScene");
    }
    public void OpenTutorial(){
        SceneManager.LoadScene("TutorialScene");
    }
    public void OpenSettings(){
        SceneManager.LoadScene("SettingsScene");
    }
}
