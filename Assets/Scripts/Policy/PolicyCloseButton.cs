using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyCloseButton : MonoBehaviour
{
    public GameObject SFX;
    public GameObject cameraMovement;
    public GameObject policyDetail;
    public GameObject skipTurnButton;

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
        cameraMovement.GetComponent<CameraMovement>().isActive = true;
        policyDetail.SetActive(false);
        skipTurnButton.GetComponent<SkipTurnButton>().policy = null;
        SFX.GetComponent<SoundEffects>().PlayPick();
    }
}
