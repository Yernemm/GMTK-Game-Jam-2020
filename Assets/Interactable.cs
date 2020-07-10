using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public IInteractable interactionScript;



    public float what;
    
    public void interact(GameObject player){
        interactionScript.interact(player);
    }
}

public interface IInteractable {

    void interact(GameObject player);

}
