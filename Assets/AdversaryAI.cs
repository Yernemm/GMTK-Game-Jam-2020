using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdversaryAI : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private NavMeshAgent agent;
    private CharacterController controller;

    public GameObject[] targets;

    GameObject nextTarget;

    private int lastTarget = -1;

    public bool isEnabledThisLevel = true;

    public bool isAiActive(){
        return agent.enabled;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        agent = player.GetComponent<NavMeshAgent>();
        controller = player.GetComponent<CharacterController>();
        chooseRandomTarget();
     }
 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getGoinFam(){
        if(!isEnabledThisLevel)
            return;
        agent.enabled = true;
        controller.enabled = false;
        agent.SetDestination(nextTarget.transform.position);
    }

    public void shitTheFedsAreHere(){
        if(!isEnabledThisLevel)
            return;
        agent.enabled = false;
        controller.enabled = true;
    }

    public void enteredTarget(int id){
        Debug.Log("owo");
        chooseRandomTarget();
        if(agent.enabled){
             agent.SetDestination(nextTarget.transform.position);
            Debug.Log("ohohohoho");
        }
           
       
    }

    
    private void chooseRandomTarget(){
        int nextTargetId = Random.Range(0, targets.Length);
        if(nextTargetId == lastTarget){
            nextTargetId = (nextTargetId + 1) % targets.Length;
        }

        nextTarget = targets[nextTargetId];
        lastTarget = nextTargetId;
    }
}
