using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudManager : MonoBehaviour
{

    public Text interactText;
    public Text countDownText;
    public Text objectiveText;

    public Image screenBlocker;

    public Text controlIllusionText;    

    public Image deadBlocker;
    public Text deadText;

    private Timing tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<Timing>();
    }

    // Update is called once per frame
    void Update()
    {
        float ctd = tm.getTimeLeft();
        if(ctd > 0f){
            if(tm.isCountdownEnabled){
                string seconds = Mathf.Floor( ctd % 60).ToString();
                if(seconds.Length < 2){
                    seconds = "0" + seconds;
                }
                string minutes  = Mathf.Floor(ctd / 60f).ToString();
                if(minutes.Length < 2){
                    minutes = "0" + minutes;
                }
                countDownText.text = minutes + ":" + seconds;
            }else{
                countDownText.text = "";
            }
            
        }else{
            countDownText.enabled = false;
            objectiveText.enabled = false;
            deadBlocker.enabled = true;
            deadText.enabled = true;
        }

    }

    public void canInteract(bool interact){
        this.interactText.enabled = interact;
    }

    public void blockScreen(bool blocking){
        this.screenBlocker.enabled = blocking;
        this.controlIllusionText.enabled = blocking;
    }

}
