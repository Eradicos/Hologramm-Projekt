using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class StopTrail : MonoBehaviour {

    private Transform musicianStage;
    private GameObject musicianParticleTrail;
    private BGCcCursor musicianCursor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private GameObject GetActiveMusician()
    {
        GameObject[] musicians = new GameObject[4];
        musicians =GameObject.FindGameObjectsWithTag("MusicianRenderTex");
        if (musicians[0] != null)
        {
            return musicians[0];
        }
        return null;
    }
}
