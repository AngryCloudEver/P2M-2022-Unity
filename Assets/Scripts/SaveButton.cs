using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public GameObject status;
    public GameObject gameSavedCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        status.GetComponent<Status>().SaveData();
        gameSavedCanvas.SetActive(true);
    }
}
