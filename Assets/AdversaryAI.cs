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
        agent.enabled = true;
        controller.enabled = false;
        agent.SetDestination(nextTarget.transform.position);
    }

    public void shitTheFedsAreHere(){
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
           nextTarget = targets[Random.Range(0, targets.Length)];
    }
}
