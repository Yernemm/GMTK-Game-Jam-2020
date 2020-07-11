﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITarget : MonoBehaviour
{

    private GameObject gm;
    private AdversaryAI ai;

    public int id;

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
        if(other.name == "Player"){
            
            ai.enteredTarget(id);
        }
    }


}
