using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timing : MonoBehaviour
{

    float countdown;

    public float initialCtd = 120f;

    public float noControlMultiplier = 4f;

    public AdversaryAI ai;

    public bool isCountdownEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        countdown = initialCtd;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountdownEnabled){
                countdown -= ai.isAiActive() ? Time.deltaTime * noControlMultiplier : Time.deltaTime;
                if(countdown <= -2f){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
        }


    }

    public float getTimeLeft(){
        return countdown;
    }
}
