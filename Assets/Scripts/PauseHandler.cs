using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public GameObject cameraMovement;
    public GameObject statusCanvas;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                cameraMovement.GetComponent<CameraMovement>().isActive = false;
                statusCanvas.SetActive(false);
                StartCoroutine(PauseGame(true));
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                cameraMovement.GetComponent<CameraMovement>().isActive = true;
                statusCanvas.SetActive(true);
                StartCoroutine(PauseGame(false));
            }
        }
    }

    private IEnumerator PauseGame(bool pauseState)
    {
        yield return new WaitForSeconds(1);
        isPaused = pauseState;
    }
}
