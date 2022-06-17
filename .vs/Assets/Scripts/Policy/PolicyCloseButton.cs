using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyCloseButton : MonoBehaviour
{
    public GameObject cameraMovement;
    public GameObject policyDetail;
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
    }
}
