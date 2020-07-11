using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTiming : MonoBehaviour
{

    public ProgressBar progress;

    private GameManager gameManager;

    public float chargeRate = 5f;
    public float decayRate = 1f;

    public bool isCharging = false;

    private float prog = 0;

    private bool lastCharged = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        isCharging = gameManager.areObjectivesMet();

        if(isCharging){
            prog+= chargeRate * Time.deltaTime / 100f;
        }else{
            prog -= decayRate * Time.deltaTime / 100f;
        }

        prog = Mathf.Clamp(prog, 0f, 1f);
        progress.updateProgress(prog);

        if(this.isCharged() != lastCharged){
            gameManager.showExit(this.isCharged());
        }

        lastCharged = this.isCharged();
    }

    public bool isCharged(){
        return prog >= 1f;
    }
}
