using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialTraverse : MonoBehaviour
{
    public GameObject[] tutorials;
    public GameObject closeButton,previousButton,nextButton;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PreviousTutorial(){
        
        if(index>0){
            tutorials[index].gameObject.SetActive(false);
            index--;
            tutorials[index].gameObject.SetActive(true);
        }
        if(index==0){
            previousButton.SetActive(false);
        }
        else{
            nextButton.SetActive(true);
            closeButton.SetActive(false);
        }

    }
    public void NextTutorial(){
        if(index<2){
        tutorials[index].gameObject.SetActive(false);
        index++;
        tutorials[index].gameObject.SetActive(true);
        }
        if(index==2){
            closeButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else{
            previousButton.SetActive(true);
        }
    }
}
