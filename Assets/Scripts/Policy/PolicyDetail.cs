using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyDetail : MonoBehaviour
{
    public Policy policy = null;
    public GameObject cameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(policy != null)
        {
            cameraMovement.GetComponent<CameraMovement>().isActive = false;
            this.gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = policy.title;
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = policy.description;
        }

        if(cameraMovement.GetComponent<CameraMovement>().isActive == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
