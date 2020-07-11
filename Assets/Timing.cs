using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{

    float countdown;

    public float initialCtd = 120f;

    public float noControlMultiplier = 4f;

    public AdversaryAI ai;

    // Start is called before the first frame update
    void Start()
    {
        countdown = initialCtd;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= ai.isAiActive() ? Time.deltaTime * noControlMultiplier : Time.deltaTime;

    }

    public float getTimeLeft(){
        return countdown;
    }
}
