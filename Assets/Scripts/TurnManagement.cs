using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManagement : MonoBehaviour
{
    public int currentTurn;
    protected bool turnActive = true;

    // Start is called before the first frame update
    void Start()
    {
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
    public void addTurn(){
        currentTurn++;
        PlayerPrefs.SetInt("currentTurn", currentTurn);
    }
}
