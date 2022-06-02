using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraMovementSpeed = 30f;
    public GameObject camera = null;
    public int maxWallHorizontal;
    public int maxWallVertical;
    public int defaultZoom = 80;
    public int maxZoom = 130;
    public int minZoom = 30;
    public bool isActive = true;

    private CharacterController controller;
    private Camera cameraScroll;
    private Vector3 cameraDefaultPosition;
    private float mouseYDefault;

    // Start is called before the first frame update
    void Start()
    {
        // Camera Configuration
        gameObject.transform.position = new Vector3(-141.2f, 234.3f, -144.4f);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(30, 45, 0));

        controller = gameObject.AddComponent<CharacterController>();

        cameraScroll = camera.GetComponent<Camera>();
        cameraScroll.orthographicSize = defaultZoom;
        cameraDefaultPosition = gameObject.transform.position;
        mouseYDefault = Input.mouseScrollDelta.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive == true)
        {
            // Camera Movement
            if (Input.GetKey(KeyCode.W))
            {
                controller.Move(new Vector3(cameraMovementSpeed, cameraMovementSpeed, cameraMovementSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                controller.Move(new Vector3(cameraMovementSpeed * -1, cameraMovementSpeed * -1, cameraMovementSpeed * -1) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                controller.Move(new Vector3(cameraMovementSpeed * -1, 0, cameraMovementSpeed) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                controller.Move(new Vector3(cameraMovementSpeed, 0, cameraMovementSpeed * -1) * Time.deltaTime);
            }

            // Wall Block Horizontally
            if (camera.transform.position.x + (camera.transform.position.z * -1) > (cameraDefaultPosition.x + (cameraDefaultPosition.z * -1)) + (maxWallHorizontal / 2))
            {
                controller.Move(new Vector3(cameraMovementSpeed * -1, 0, cameraMovementSpeed) * Time.deltaTime);
            }
            else if (camera.transform.position.x + (camera.transform.position.z * -1) < (cameraDefaultPosition.x + (cameraDefaultPosition.z * -1)) - (maxWallHorizontal / 2))
            {
                controller.Move(new Vector3(cameraMovementSpeed, 0, cameraMovementSpeed * -1) * Time.deltaTime);
            }

            // Wall Block Vertically
            if (camera.transform.position.y < cameraDefaultPosition.y - (maxWallVertical / 2))
            {
                controller.Move(new Vector3(cameraMovementSpeed, cameraMovementSpeed, cameraMovementSpeed) * Time.deltaTime);
            }
            else if(camera.transform.position.y > cameraDefaultPosition.y + (maxWallVertical / 2))
            {
                controller.Move(new Vector3(cameraMovementSpeed * -1, cameraMovementSpeed * -1, cameraMovementSpeed * -1) * Time.deltaTime);
            }

            // Zoom Scrolling
            if (Input.mouseScrollDelta.y > mouseYDefault)
            {
                cameraScroll.orthographicSize -= 3;
            }
            else if (Input.mouseScrollDelta.y < mouseYDefault)
            {
                cameraScroll.orthographicSize += 3;
            }

            // Zoom Block
            if(cameraScroll.orthographicSize >= maxZoom)
            {
                cameraScroll.orthographicSize = maxZoom;
            }
            else if(cameraScroll.orthographicSize <= minZoom)
            {
                cameraScroll.orthographicSize = minZoom;
            }
        }
    }
}
