using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSens = 100f;
    public Transform playerBody;
    public Transform cam;
    float xRotation = 0f;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
         gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = gm.isInControl ? Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime : 0f;
        float mouseY = gm.isInControl ? Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime : 0f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
        playerBody.Rotate(Vector3.up * mouseX);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
