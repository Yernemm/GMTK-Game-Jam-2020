using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{

    public Camera mainCam;
    public LayerMask interactableMask;

    public float interactDistance = 4f;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkInteraction()){
            Debug.Log(hit.collider.gameObject);
        }
    }

    bool checkInteraction() {
        var ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //canHookBool = Physics.Raycast(ray, out hit, 250f, ~playerMask);
        return Physics.Raycast(ray, out hit, interactDistance, interactableMask);
    }
}
