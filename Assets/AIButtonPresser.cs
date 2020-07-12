using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIButtonPresser : MonoBehaviour
{
    private GameObject gm;
    private AdversaryAI ai;

    public GameObject[] buttons;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        ai = gm.GetComponent<AdversaryAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if(other.name == "Player" && ai.isAiActive() && buttons.Length > 0){
            
            pressRandomButton(other.gameObject);
        }
    }

    
    private void pressRandomButton(GameObject player){
           buttons[Random.Range(0, buttons.Length)].GetComponent<IInteractable>().interact(player);
    }
}
