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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void canInteract(bool interact){
        this.interactText.enabled = interact;
    }

    public void blockScreen(bool blocking){
        this.screenBlocker.enabled = blocking;
        this.controlIllusionText.enabled = blocking;
    }

}
