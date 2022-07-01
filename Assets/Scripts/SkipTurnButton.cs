using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTurnButton : MonoBehaviour
{
    public GameObject turnManagement;
    public Policy policy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(policy == null)
        {
            turnManagement.GetComponent<TurnManagement>().AddTurn();
        }
    }
}
