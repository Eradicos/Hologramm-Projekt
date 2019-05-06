using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InputManager : MonoBehaviour {

    private GameObject triggerCol;
    public GameObject buehne;
    public VideoPlayer vp;
    private Collider triggerBoxCol;
    Animator anim;
    public EventManager eventManager;

    private void Awake()
    {
        anim = buehne.GetComponent<Animator>();
       // Mute();
    }

    private void Start()
    {
        triggerCol = FindObjectOfType<EventManager>().gameObject;
        triggerBoxCol = triggerCol.GetComponent<BoxCollider>();
        vp = buehne.GetComponent<VideoPlayer>();
    }

    void Update()
    {

        AnimatorStateInfo statInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Jetzt gehts");
            triggerBoxCol.enabled = true;
        }

        if (Input.GetKeyDown("up"))
        {
            eventManager.GetComponent<VideoPlayer>().Stop();
            vp.Stop();
        }

        if (Input.GetKeyDown("left") && (triggerBoxCol.enabled == true) && (eventManager.checkFinishRotation))
        {
           
           // Unmute();
            switch(eventManager.instrumentCounter)
            {
                case 0: 
                    anim.Play("SwitchInstrument");
                    break;
                case 1: 
                    anim.Play("SwitchInstrument2");
                    break;
                case 2:
                    break;
                case 3:
                    anim.Play("SwitchInstrumentReverse3");
                    break;
            }
        }

        if (Input.GetKeyDown("right") && (triggerBoxCol.enabled == true) && (eventManager.checkFinishRotation))
        {
            Unmute();
            switch (eventManager.instrumentCounter)
            {
                case 0:
                    anim.Play("SwitchInstrument3");
                    break;
                case 1:
                    anim.Play("SwitchInstrumentReverse");
                    break;
                case 2:
                    anim.Play("SwitchInstrumentReverse2");
                    break;
                case 3:
                    break;
            }
        }
    }

    public void Mute()
    {
        if (anim != null)
        {
            anim.enabled = false;
        }
    }

    public void Unmute()
    {
        anim.enabled = true;

        //anim.Play("SwitchInstrument", -1, 0.0f);
        //StartCoroutine(TriggerStandeeAnimation(quickly));
        //Invoke("AnimationFinished", 1.5f);
    }
}
