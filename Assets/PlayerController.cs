using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController cc;
    public float speed = 10f;

    public float gravity = -90f;

    public Vector3 velocity;
    private bool isGrounded = false;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    public float jumpVelocity = 50f;

    //public const float VELOCITY_DAMPENING_ADD = -1f;
    public const float FIXED_VELOCITY_DAMPEN_MULTIPLIER = 0.8f;

    public const float FIXED_VELOCITY_DAMPEN_MULTIPLIER_AIR = 0.999f;

    public const float VELOCITY_MOVE_MULTIPLIER = 2f;

    private const float FIXED_VELOCITY_DAMPEN_MULTIPLIER_MINIMUM_VELOCITY = 0.1f;

    public float velocityMult;
    private Animator anim;
    private bool isGroundedLast = false;

    public LayerMask playerMask;

    private GameManager gm;

    

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3();
        velocityMult = FIXED_VELOCITY_DAMPEN_MULTIPLIER;
        anim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void FixedUpdate() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -10f;
        }


        if(!isGrounded){
            velocity.y += gravity * Time.deltaTime;
            velocityMult = FIXED_VELOCITY_DAMPEN_MULTIPLIER_AIR;
        }else{
            if(Input.GetKey("space") && gm.isInControl){
                velocity.y = jumpVelocity;
            }
            velocityMult = FIXED_VELOCITY_DAMPEN_MULTIPLIER;
            if(!isGroundedLast){
                anim.Play("Base Layer.Landed");
            }
        }
        
        float x = gm.isInControl ? Input.GetAxis("Horizontal") : 0f;
        float z = gm.isInControl ? Input.GetAxis("Vertical") : 0f;

        Vector3 move = transform.right * x * speed+ transform.forward * z * speed;

        velocity.x = dampenVelocities(velocity.x);
        velocity.z = dampenVelocities(velocity.z);

        Vector3 finalMove = (velocity + move) * Time.deltaTime;
        RaycastHit hit;
        bool cast = Physics.Raycast(transform.position, finalMove, out hit, finalMove.magnitude, ~playerMask);
        if(cast){
            velocity = Vector3.ClampMagnitude(velocity, Vector3.Magnitude(hit.point - transform.position));
        }

        cc.Move(finalMove);

        velocity += move * VELOCITY_MOVE_MULTIPLIER * Time.deltaTime;

        isGroundedLast = isGrounded;
        
    }

/*
//old version using additive constant
    float dampenVelocities(float velocity){
        float velAfter = velocity + VELOCITY_DAMPENING_ADD * Time.deltaTime;
        return  (velAfter < 0 ^ velocity < 0) ? 0 : velAfter;
    }
*/

    float dampenVelocities(float velocity){
        float velAfter = velocity * velocityMult;
        return  Math.Abs(velAfter) < FIXED_VELOCITY_DAMPEN_MULTIPLIER_MINIMUM_VELOCITY ? 0 : velAfter;
    }


}
