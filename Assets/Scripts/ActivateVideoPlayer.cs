using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateVideoPlayer : MonoBehaviour {

    public int RenderTexCounter = 0;

    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
       // Debug.Log("RenderCounter: " + RenderTexCounter);

        if (RenderTexCounter > 0)
        {
            GameObject.Find("Stage").GetComponent<VideoPlayer>().enabled = true;
        }
        else
        {
            GameObject.Find("Stage").GetComponent<VideoPlayer>().enabled = false;

        }
    }
}
