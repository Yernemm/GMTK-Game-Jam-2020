using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleButtonInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact(GameObject player){
        Debug.Log("I have been interacted with");
    }
}
