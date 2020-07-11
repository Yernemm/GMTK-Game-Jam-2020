﻿using System.Collections;
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

    private hudManager hudManager;

    // Start is called before the first frame update
    void Start()
    {
        isInControl = true;
        fadeOut(6f);
        hudManager = GameObject.Find("MainUI").GetComponent<hudManager>();
        fadedTime = 1.5f;
        fadeinTime = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
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
            fadedTimeCount += Time.deltaTime;
            if(fadedTimeCount >= fadedTime){
                isFaded = false;
                isFadingIn = true;
                fadedTimeCount = 0f;
            }
        }
    }

    public void fadeOut(float time){
        fadeoutTime = time;
        isFadingOut = true;
    }
}
