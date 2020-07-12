using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{

    public bool isInControl;
    public Volume switchVolume;

    private float fadeoutTime;

    private float fadeinTime;

    private float fadedTime;

    private float fadedTimeCount;

    private bool isFadingOut;

    private bool isFadingIn;

    private bool isFaded;

    private float timeUntilNextFade = 10f;

    private float timeFadeCounter = 0f;

    private hudManager hudManager;

    public AdversaryAI adversaryAI;

    public GameObject[] objectives;

    private GameObject exit;

    private bool lastobjmet = false;

    public bool isMenuScreen = false;

    public bool isAiEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        isInControl = !isMenuScreen;
        fadeOut(6f);
        hudManager = GameObject.Find("MainUI").GetComponent<hudManager>();
        fadedTime = 1.5f;
        fadeinTime = 0.6f;
        exit = GameObject.Find("Exit");
        StartCoroutine(LateStart());
    }

    
     IEnumerator LateStart()
     {
        yield return new WaitForSeconds(1f);
         
        if(isMenuScreen && isAiEnabled){
            adversaryAI.getGoinFam();
        }
         
     }

    // Update is called once per frame
    void Update()
    {
        if(!isMenuScreen && isAiEnabled){

            if(isFadingOut){
            Debug.Log("Fading Out");
            float w = switchVolume.weight;
            w += Time.deltaTime / fadeoutTime;
            if(w < 1f){
                switchVolume.weight = w;
            }else{
                switchVolume.weight = 1;
                isFadingOut = false;
                isInControl = false;
                isFaded = true;
                hudManager.blockScreen(true);
            }
        } else if(isFadingIn){
            Debug.Log("Fading In");
            float w = switchVolume.weight;
            if(w >= 1f){
                hudManager.blockScreen(false);
            }
            w -= Time.deltaTime / fadeinTime;
            if(w <= 0){
                switchVolume.weight = 0;
                isFadingIn = false;
                isInControl = true;
            }else{
                switchVolume.weight = w;
            }
            
        } else if(isFaded) {
            Debug.Log("Faded");
            adversaryAI.getGoinFam();
            fadedTimeCount += Time.deltaTime;
            if(fadedTimeCount >= fadedTime){
                adversaryAI.shitTheFedsAreHere();
                isFaded = false;
                isFadingIn = true;
                fadedTimeCount = 0f;
                randomiseTimeUntilNextFade();
            }
        } else {
            timeFadeCounter += Time.deltaTime;
            if(timeFadeCounter >= timeUntilNextFade){
                isFadingOut = true;
                timeFadeCounter = 0;
            }
        }

        }

        



       /* if(this.areObjectivesMet() != lastobjmet){
            Debug.Log("oh snapnuggets");
            exit.GetComponent<ExitMover>().open(this.areObjectivesMet());
        }

        lastobjmet = this.areObjectivesMet();
        */
    }

    public void fadeOut(float time){
        fadeoutTime = time;
        isFadingOut = true;
    }

    public void randomiseTimeUntilNextFade(){
        timeUntilNextFade = Random.Range(5f, 15f);
    }

    public bool areObjectivesMet(){
        bool flag = true;
            foreach (GameObject go in objectives)
            {
                if(!go.GetComponent<IObjective>().isMet()){
                    flag = false;
                }
            }
        return flag;
    }

    public void showExit(bool show){
        exit.GetComponent<ExitMover>().open(show);
    }
}
