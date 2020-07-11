using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{

    public Camera mainCam;
    public LayerMask interactableMask;

    public float interactDistance = 4f;

    public hudManager hudManager;

    private RaycastHit hit;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        hudManager = GameObject.Find("MainUI").GetComponent<hudManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkInteraction()){
            //Debug.Log(hit.collider.gameObject);
            hudManager.canInteract(true);

            if(Input.GetMouseButtonDown(0) && gm.isInControl){
                hit.collider.gameObject.GetComponent<IInteractable>().interact(gameObject);
            }

        }else{
            hudManager.canInteract(false);
        }
    }

    bool checkInteraction() {
        var ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //canHookBool = Physics.Raycast(ray, out hit, 250f, ~playerMask);
        return Physics.Raycast(ray, out hit, interactDistance, interactableMask);
    }
}
