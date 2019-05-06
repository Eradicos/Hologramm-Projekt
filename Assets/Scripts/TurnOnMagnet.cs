using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Leap;


public class TurnOnMagnet : MonoBehaviour {

    public int magnetNumber;
    public GameObject magnet;
    Controller controller;
    private int inCounter;
    private GameObject stage;
    private bool renderTexOn = false;
    private bool waitTimer1 = false;
    private bool waitTimer2 = false;

    //private void Start()
    //{
    //    controller = new Controller();
    //    controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
    //    controller.Config.SetFloat("Gesture.Swipe.MinLength", 50f);
    //    controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 600);
    //    controller.Config.Save();
    //    controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
    //}

    //private void Update()
    //{
    //    if (waitTimer1)
    //    {
    //        StartCoroutine(Timer());
    //    }

    //    if (waitTimer2)
    //    {
    //        StartCoroutine(Timer());
    //    }
    //}

    IEnumerator Timer()
    {
        Debug.Log("Ich werde gewartet");
        yield return new WaitForSeconds(1);
        if (renderTexOn)
        {
            renderTexOn = false;
            waitTimer1 = false;
        }
        if (renderTexOn == false)
        {
            renderTexOn = true;
            waitTimer2 = false;
        }
        Debug.Log("Ich habe gewartet");

    }

    //private void Update()
    //{
    //if (magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].activeSelf)
    //{
    //    Frame frame = controller.Frame();
    //    GestureList gestures = frame.Gestures();

    //    for (int i = 0; i < gestures.Count; i++)
    //    {
    //        Gesture gesture = gestures[i];
    //        //if (gesture.Type == Gesture.GestureType.TYPESWIPE)
    //        //{
    //        //    SwipeGesture swipe = new SwipeGesture(gesture);
    //        //    Vector SwipDirektion = swipe.Direction;
    //        //    if (SwipDirektion.x < 0 && renderTexOn == false)
    //        //    {
    //        //        magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.SetActive(true);

    //        //        Debug.Log(magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.name);

    //        //        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].transform.position = new Vector3(-10f, 3.717072f, 159.35f);
    //        //        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].SetActive(true);
    //        //        //instrumenModel.GetComponent<MagneticField>().enabled = false;
    //        //        //instrumenModel.GetComponent<MagneticField>().findMagNum = instrumenModel.GetComponent<MagneticField>().defaultMagNum;
    //        //        //instrumenModel.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    //        //        Debug.Log("Swipe Left On");
    //        //        //Debug.Log("defaultMagNum: " + instrumenModel.GetComponent<MagneticField>().defaultMagNum);
    //        //        GameObject.Find("Stage").GetComponent<ActivateVideoPlayer>().RenderTexCounter += 1;
    //        //        renderTexOn = true;
    //        //    }

    //        //}
    //        if (gesture.Type == Gesture.GestureType.TYPESCREENTAP)
    //        {
    //            ScreenTapGesture screenTap = new ScreenTapGesture(gesture);
    //            Vector TapDirektion = screenTap.Direction;
    //            if (TapDirektion.z > 0 && renderTexOn == false)
    //            {
    //                magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.SetActive(true);
    //                //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].transform.position = new Vector3(-10f, 3.717072f, 159.35f);
    //                //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].SetActive(true);
    //                ////instrumenModel.GetComponent<MagneticField>().enabled = false;
    //                //instrumenModel.GetComponent<MagneticField>().findMagNum = instrumenModel.GetComponent<MagneticField>().defaultMagNum;
    //                //instrumenModel.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    //                Debug.Log("Swipe Left Off");
    //                //Debug.Log("defaultMagNum: " + instrumenModel.GetComponent<MagneticField>().defaultMagNum);
    //                GameObject.Find("Stage").GetComponent<ActivateVideoPlayer>().RenderTexCounter += 1;
    //                renderTexOn = true;
    //            }
    //        }
    //    }
    //}
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Instrument"))
    //    {
    //        instrumenModel = other.gameObject;
    //        instrumenModel.GetComponent<MagneticField>().enabled = true;
    //        instrumenModel.GetComponent<MagneticField>().findMagNum = magnetNumber;

    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Instrument"))
    //    {
    //        other.gameObject.GetComponent<MagneticField>().enabled = false;
    //    }

    //}

    //private void OnTriggerStay(Collider other)
    //{

    //    if (other.gameObject.CompareTag("Player") && (magnet.GetComponent<TurnOnOffInstrumentModdel>().isSwipe = true))
    //    {
    //        //inCounter = magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumentCounter;

    //        if (magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].activeSelf) {
    //            Frame frame = controller.Frame();
    //            GestureList gestures = frame.Gestures();

    //            for (int i = 0; i < gestures.Count; i++)
    //            {
    //                Gesture gesture = gestures[i];
    //                if (gesture.Type == Gesture.GestureType.TYPESWIPE)
    //                {
    //                    SwipeGesture swipe = new SwipeGesture(gesture);
    //                    Vector SwipDirektion = swipe.Direction;
    //                    if (SwipDirektion.x < 0 && renderTexOn)
    //                    {
    //                        magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.SetActive(false);

    //                        Debug.Log(magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.name);

    //                        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].transform.position = new Vector3(-10f, 3.717072f, 159.35f);
    //                        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].SetActive(true);
    //                        //instrumenModel.GetComponent<MagneticField>().enabled = false;
    //                        //instrumenModel.GetComponent<MagneticField>().findMagNum = instrumenModel.GetComponent<MagneticField>().defaultMagNum;
    //                        //instrumenModel.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    //                        Debug.Log("Swipe Left On");
    //                        //Debug.Log("defaultMagNum: " + instrumenModel.GetComponent<MagneticField>().defaultMagNum);
    //                        GameObject.Find("Stage").GetComponent<ActivateVideoPlayer>().RenderTexCounter -= 1;
    //                        renderTexOn = false;
    //                    }

    //                    if (SwipDirektion.x > 0 && renderTexOn == false)
    //                    {
    //                        magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.SetActive(true);

    //                        Debug.Log(magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.name);

    //                        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].transform.position = new Vector3(-10f, 3.717072f, 159.35f);
    //                        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].SetActive(true);
    //                        //instrumenModel.GetComponent<MagneticField>().enabled = false;
    //                        //instrumenModel.GetComponent<MagneticField>().findMagNum = instrumenModel.GetComponent<MagneticField>().defaultMagNum;
    //                        //instrumenModel.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    //                        Debug.Log("Swipe Left On");
    //                        //Debug.Log("defaultMagNum: " + instrumenModel.GetComponent<MagneticField>().defaultMagNum);
    //                        GameObject.Find("Stage").GetComponent<ActivateVideoPlayer>().RenderTexCounter += 1;
    //                        renderTexOn = true;
    //                    }

    //                }
    //                //if (gesture.Type == Gesture.GestureType.TYPESCREENTAP)
    //                //{
    //                //    ScreenTapGesture screenTap = new ScreenTapGesture(gesture);
    //                //    Vector TapDirektion = screenTap.Direction;
    //                //    if (TapDirektion.z > 0 && renderTexOn == false)
    //                //    {
    //                //        magnet.GetComponent<TurnOnOffInstrumentModdel>().podestArray[magnetNumber].transform.GetChild(2).gameObject.SetActive(true);
    //                //        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].transform.position = new Vector3(-10f, 3.717072f, 159.35f);
    //                //        //magnet.GetComponent<TurnOnOffInstrumentModdel>().instrumenArray[magnetNumber].SetActive(true);
    //                //        ////instrumenModel.GetComponent<MagneticField>().enabled = false;
    //                //        //instrumenModel.GetComponent<MagneticField>().findMagNum = instrumenModel.GetComponent<MagneticField>().defaultMagNum;
    //                //        //instrumenModel.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    //                //        Debug.Log("Swipe Left Off");
    //                //        //Debug.Log("defaultMagNum: " + instrumenModel.GetComponent<MagneticField>().defaultMagNum);
    //                //        GameObject.Find("Stage").GetComponent<ActivateVideoPlayer>().RenderTexCounter += 1;
    //                //        renderTexOn = true;
    //                //    }
    //                //}
    //            }
    //        }
    //    }
    //}
}
