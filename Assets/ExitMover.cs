using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMover : MonoBehaviour
{

    public float hiddenY = -45;
    public float openY = -1;

    private Vector3 mainPos;

    private bool isOpen = false;

    private float speed;

    private bool isMoving = false;

    private Vector3 initpos;
    private Vector3 endpos;

    private float lerptime =0f;

    // Start is called before the first frame update
    void Start()
    {
        mainPos = transform.position;
        speed = Mathf.Abs(hiddenY - openY);
        initpos = new Vector3(mainPos.x, hiddenY, mainPos.z);
        endpos = new Vector3(mainPos.x, openY, mainPos.z);
        speed = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            if(isOpen){
                transform.position = Vector3.Lerp(initpos, endpos, lerptime);
                lerptime += speed * Time.deltaTime;
                if(transform.position == endpos){
                    isMoving = false;
                    lerptime =0f;

                }
            }else{
                transform.position = Vector3.Lerp(endpos, initpos, lerptime);
                lerptime += speed * Time.deltaTime;
                if(transform.position == initpos){
                    isMoving = false;
                    lerptime =0f;

                }
            }
        }
    }

    public void open(bool open){
        isOpen = open;
        isMoving = true;
    }
}
