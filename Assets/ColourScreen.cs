using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColourScreen : MonoBehaviour
{

    public TextMeshPro tmp;

    public Material[] colours;
    private string[] colourNames = {" ", "R", "G", "B"};

    private int[] sequence = {0, 2, 3 ,1};

    private float showTime = 1f;

    private float timeCounter = 0f; 
    private int currentState = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateSelf();
    }

    // Update is called once per frame
    void Update()
    {
        int max = sequence.Length - 1;
        timeCounter += Time.deltaTime;
        if(timeCounter >= showTime){
            timeCounter = 0;
            currentState = currentState + 1 > max ? 0 : currentState + 1;
            updateSelf();
        }
    }

    void updateSelf(){
        gameObject.GetComponent<Renderer>().material = colours[sequence[currentState]];
        tmp.text = colourNames[sequence[currentState]];
    }
}
