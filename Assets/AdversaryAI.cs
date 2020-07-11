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

    void Start()
    {
        player = GameObject.Find("Player");
        agent = player.GetComponent<NavMeshAgent>();
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getGoinFam(){
        agent.enabled = true;
        controller.enabled = false;
        agent.SetDestination(new Vector3(0,0,0));
    }

    public void shitTheFedsAreHere(){
        agent.enabled = false;
        controller.enabled = true;
    }
}
