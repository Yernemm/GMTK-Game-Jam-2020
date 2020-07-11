using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    public GameObject bar;

    private float progress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateProgress(float newProgress){
        progress = newProgress;
        bar.transform.localScale = new Vector3(progress, 1f, 1f);
        bar.transform.localPosition = new Vector3(-0.5f + (progress / 2), 0f, -1f);
    }

    public float getProgress(){
        return this.progress;
    }
}
