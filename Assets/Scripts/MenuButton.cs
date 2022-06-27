using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour
{
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
    public void OpenCredit(){
        SceneManager.LoadScene("CreditScene");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void OpenMain(){
        SceneManager.LoadScene("MainScene");
    }
}
