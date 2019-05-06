using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartRendertexture : MonoBehaviour {

    public RenderTexture renderTex;
    private bool videoIsPrepared;
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.isLooping = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTex;

        videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.None;

        //make sure that videoPlayer has been prepared correctly
        //not correctly prepared/loaded videoPlayer will lead to 
        //app crash on device right after start
        videoPlayer.prepareCompleted += VideoPreparationCompleted;
        videoPlayer.Prepare();

        //videoPlayer.Pause();
        videoPlayer.time = 0.0f;
    }


/* A function used to record the videoPlayer's prepareCompleted event */
private void VideoPreparationCompleted(VideoPlayer videoPlayer)
{
    videoIsPrepared = true;
}
    private void Update()
    {

        if (videoIsPrepared == false)
        {
            //Debug.Log("IstFalse");
        }

        if (videoIsPrepared == true){
           // Debug.Log("IstTrue");
            videoPlayer.Stop();
        }
        
    }
}
