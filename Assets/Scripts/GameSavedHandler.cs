using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSavedHandler : MonoBehaviour
{
    public GameObject savedCanvas;
    public GameObject SFX;
    // Start is called before the first frame update
    void Start()
    {
        savedCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        savedCanvas.SetActive(false);
        SFX.GetComponent<SoundEffects>().PlayPick();
    }
}
