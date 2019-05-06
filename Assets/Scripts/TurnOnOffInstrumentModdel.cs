using System.Collections;
using System.Collections.Generic;
using Leap;
using UnityEngine;
using UnityEngine.Video;

public class TurnOnOffInstrumentModdel : MonoBehaviour {

    //private GameObject podest;
    public GameObject[] podestArray;
    public GameObject[] instrumenArray;
    public GameObject videoPlayer;
    public int instrumentCounter;
    //public int magNum;
    Controller controller;
    public bool isSwipe = false;




    private void OnTriggerEnter(Collider other)
    {
        ActiveInstrument(other);
        isSwipe = true;
        //magNum = gameObject.GetComponentInParent<TurnOnMagnet>().magnetNumber;
        if (other.gameObject.CompareTag("Instrument"))
        {
            other.gameObject.SetActive(false);
            podestArray[instrumentCounter].SetActive(true);

            podestArray[instrumentCounter].transform.position = 
            new Vector3(transform.position.x, podestArray[instrumentCounter].transform.position.y, 
                podestArray[instrumentCounter].transform.position.z);

            videoPlayer.GetComponent<VideoPlayer>().enabled = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Instrument"))
        {

            isSwipe = false;
        }
    }

    public Collider ActiveInstrument(Collider col)
    {
        if (col.gameObject.name == "Violin Sayako")
        {
            instrumentCounter = 0;
        }
        else if (col.gameObject.name == "Cello Felix")
        {
            instrumentCounter = 1;
        }
        else if (col.gameObject.name == "PodestFelix")
        {
            instrumentCounter = 2;
        }
        else if (col.gameObject.name == "PodestAmalia")
        {
            instrumentCounter = 3;
        }
        return col;
    }
}
