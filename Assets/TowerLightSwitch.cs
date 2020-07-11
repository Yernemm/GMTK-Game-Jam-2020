using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLightSwitch : MonoBehaviour, Iswitchable
{
    // Start is called before the first frame update

    public int value;

    public Material[] colours;

    private string[] textVals = {"_", "R", "G", "B"};

    public TextMeshPro text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchTrigger(int val){
        this.value = val;
        gameObject.GetComponent<Renderer>().material = colours[val];
        text.text = textVals[val];
    }
}
