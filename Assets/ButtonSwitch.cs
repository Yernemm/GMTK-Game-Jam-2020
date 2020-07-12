using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour, IInteractable
{

    public int switchValue;

    public GameObject switchableObject;

    private Iswitchable sw;

    public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        sw = switchableObject.GetComponent<Iswitchable>();
    }

    public void interact(GameObject obj){
        sw.switchTrigger(switchValue);
        soundEffect.Play();
    }
}

public interface Iswitchable {
    void switchTrigger(int value);
}