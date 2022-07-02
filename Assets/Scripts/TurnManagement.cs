using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManagement : MonoBehaviour
{
    public GameObject SFX;
    public int currentTurn;
    protected bool turnActive = true;

    // Start is called before the first frame update
    void Start()
    {
        string isNewGame = PlayerPrefs.GetString("isNewGame");
        if(isNewGame == "true"){
        PlayerPrefs.SetInt("currentTurn",1);
        }
        currentTurn = PlayerPrefs.GetInt("currentTurn",1);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getTurn()
    {
        return currentTurn;
    }
    public void AddTurn(){
        currentTurn++;
        PlayerPrefs.SetInt("currentTurn",currentTurn);
        StartCoroutine(PlayNewDay());
        
    }
    IEnumerator PlayNewDay(){
        yield return new WaitForSeconds(1.5f);
        SFX.GetComponent<SoundEffects>().PlayNewDay();
    }
}
