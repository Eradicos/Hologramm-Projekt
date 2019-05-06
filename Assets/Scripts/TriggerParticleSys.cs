using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class TriggerParticleSys : MonoBehaviour {

    private Transform musicianStage;
    private GameObject musicianParticleTrail;
    private BGCcCursor musicianCursor;
    GameObject[] musicians;

    private void Awake()
    {
        musicians = new GameObject[4];
        //musicianParticleTrail = 
        //bGCursor = other.GetComponentInParent<BGCcCursor>();
    }

    private void InitializeValues()
    {
        musicianStage = GetActiveMusician().transform.parent.transform.parent;
        musicianParticleTrail = musicianStage.GetChild(0).GetChild(0).GetComponentInParent<ParticleTrail>().gameObject;
        musicianCursor = musicianStage.GetChild(0).GetComponentInParent<BGCcCursor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Note"))
        { 
        GetActiveMusician();

            for (int i = 0; i < musicians.Length; i++)
            {
                if (musicians[i] != null)
                {
                    musicianStage = musicians[i].transform.parent.transform.parent;
                    musicianParticleTrail = musicianStage.GetChild(0).GetChild(0).GetComponentInParent<ParticleTrail>().gameObject;
                    musicianCursor = musicianStage.GetChild(0).GetComponentInParent<BGCcCursor>();
                    //InitializeValues();
                    Debug.Log("StageName: " + musicianStage.name);


                    for (int z = 0; z < musicianParticleTrail.transform.childCount; z++)
                    {
                        musicianParticleTrail.transform.GetChild(z).GetComponent<ParticleSystem>().Stop();
                        //glitter.GetComponent<ParticleSystem>().Stop();
                    }
                    musicianCursor.DistanceRatio = 0;
                    musicianCursor.enabled = false;
                }
            }
        }
    }

    public void setBGCursor(bool setCursor)
    {
        InitializeValues();
        musicianCursor.enabled = setCursor;
        musicianCursor.DistanceRatio = 0;
    }

    private GameObject GetActiveMusician() {
        //GameObject[] musicians = new GameObject[4];
        musicians = GameObject.FindGameObjectsWithTag("MusicianRenderTex");
        for(int i = 0; i < musicians.Length; i++)
        {
            //if(musicians[i] != null)
            Debug.Log("Musiker: " + musicians[i].name);
        }
        //if (musicians[0] != null) {
        //   return musicians[0];
        //}
        return null;
    }
}
