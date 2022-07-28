using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHover : MonoBehaviour
{
    private GameObject hoverText;
    private GameObject hoverImage;
    // Start is called before the first frame update
    void Start()
    {
        hoverText = this.gameObject.transform.GetChild(1).gameObject;
        hoverImage = this.gameObject.transform.GetChild(0).gameObject;
        hoverText.SetActive(false);
        hoverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        hoverText.SetActive(true);
        hoverImage.SetActive(true);
    }

    void OnMouseExit()
    {
        hoverText.SetActive(false);
        hoverImage.SetActive(false);
    }
}
