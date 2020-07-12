using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLightSwitch : MonoBehaviour, Iswitchable, IObjective
{
    // Start is called before the first frame update

    public int value;

    public Material[] colours;

    private string[] textVals = {"_", "R", "G", "B", "C", "Y", "M"};

    public TextMeshPro text;

    public int correctValue;



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

    public bool isMet(){
        return correctValue == value;
    }
}

public interface IObjective{
    bool isMet();
}
