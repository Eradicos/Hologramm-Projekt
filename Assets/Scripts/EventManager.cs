using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EventManager : MonoBehaviour {

    public InputManager inputManager;
    public TriggerParticleSys setSpline;
    public int instrumentCounter;
    private VideoPlayer videoPLayerBuehne;
    private long frameNumber;
    Texture2D videoFrame;
    private Color targetColor;
    public Light lSource;
    private GameObject plane;
    public GameObject[] Artists;
    public bool checkFinishRotation;
    private Transform PauseTexturePlane;
    private Transform ParticleTrail;
    public bool bGCurveactivater = false;
    public AudioClip[] instrumentSound;
    // public GameObject vid;


    private void Start()
    {
        videoFrame = new Texture2D(2, 2);
        instrumentCounter = 0;
        videoPLayerBuehne = inputManager.buehne.gameObject.GetComponent<VideoPlayer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        ActiveInstrument(other);
        bGCurveactivater = true;
        ParticleTrail = other.gameObject.transform.GetChild(0);
        ParticleTrail.gameObject.SetActive(true);
        ParticleTrail.gameObject.GetComponent<FadeInOut>().enabled = true;

        Transform InstrumentVideo = other.gameObject.transform.GetChild(2);
        InstrumentVideo.gameObject.SetActive(true);

        if (FindObjectOfType<TriggerParticleSys>() != null)
        {
            Debug.Log("Yea wir sind drinnen");
            FindObjectOfType<TriggerParticleSys>().setBGCursor(true);
        }

        PauseTexturePlane = Artists[instrumentCounter].gameObject.transform.GetChild(4);
        plane = PauseTexturePlane.gameObject;
        plane.SetActive(false);

        inputManager.Mute();
        inputManager.vp.frame = 0;
        inputManager.vp.Play();
        gameObject.GetComponent<AudioSource>().clip = instrumentSound[instrumentCounter];
        gameObject.GetComponent<AudioSource>().Play();


        //videoPLayerBuehne = inputManager.buehne.gameObject.GetComponent<VideoPlayer>();
        //frameNumber = videoPLayerBuehne.frame;
        //OnNewFrame(inputManager.vp, frameNumber);
        //for (int i = 0; i < Artists.Length; i++)
        //{
        //    PauseTexturePlane = Artists[i].gameObject.transform.GetChild(4);
        //    plane = PauseTexturePlane.gameObject;
        //    plane.SetActive(true);

        //    ApplyTexture(videoFrame);

        //}
        checkFinishRotation = true;
    }

    public void OnTriggerExit(Collider other)
    {
        //videoPLayerBuehne = inputManager.buehne.gameObject.GetComponent<VideoPlayer>();
        //frameNumber = videoPLayerBuehne.frame;
        //OnNewFrame(inputManager.vp, frameNumber);
        ParticleTrail = other.gameObject.transform.GetChild(0);
        ParticleTrail.gameObject.SetActive(false);
        ParticleTrail.gameObject.GetComponent<FadeInOut>().enabled = false;

        PauseTexturePlane = other.gameObject.transform.GetChild(4);
        plane = PauseTexturePlane.gameObject;
        plane.SetActive(true);
        //ApplyTexture(videoFrame);

        inputManager.vp.Stop();
        gameObject.GetComponent<AudioSource>().Stop();

        Transform InstrumentVideo = other.gameObject.transform.GetChild(2);
        InstrumentVideo.gameObject.SetActive(false);
        checkFinishRotation = false;
    }

    void OnNewFrame(VideoPlayer source, long frameIdx)
    {
        RenderTexture renderTexture = source.texture as RenderTexture;


        if (videoFrame.width != renderTexture.width || videoFrame.height != renderTexture.height)
        {
            videoFrame.Resize(renderTexture.width, renderTexture.height);
        }
        RenderTexture.active = renderTexture;
        videoFrame.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        videoFrame.Apply();
        RenderTexture.active = null;

        targetColor = CalculateAverageColorFromTexture(videoFrame);
        lSource.color = targetColor;
    }

    Color32 CalculateAverageColorFromTexture(Texture2D tex)
    {
        Color32[] texColors = tex.GetPixels32();
        int total = texColors.Length;
        float r = 0;
        float g = 0;
        float b = 0;

        for (int i = 0; i < total; i++)
        {
            r += texColors[i].r;
            g += texColors[i].g;
            b += texColors[i].b;
        }
        return new Color32((byte)(r / total), (byte)(g / total), (byte)(b / total), 0);
    }

    void ApplyTexture(Texture texture)
    {
        plane.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        plane.GetComponent<Renderer>().material.SetTexture("_MaskTex", texture);
    }

    public Collider ActiveInstrument(Collider col)
    {
        if(col.gameObject.name == "PodestSayako")
        {
            instrumentCounter = 0;
        }else if (col.gameObject.name == "PodestJohannes")
        {
            instrumentCounter = 1;
        }else if(col.gameObject.name == "PodestFelix")
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


