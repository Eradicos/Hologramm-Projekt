using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SyncVideoAudio : MonoBehaviour
{

	public VideoPlayer stageVideoPlayer;
	public AudioSource musicanAudioSource;

	private void OnEnable()
	{
		musicanAudioSource.Play();
		musicanAudioSource.time = (float)stageVideoPlayer.time;

		InvokeRepeating("ForceSynchronocity", 1.0f, 1.0f);

	}

	private void ForceSynchronocity()
	{
		float deltaT = Mathf.Abs(musicanAudioSource.time - (float)stageVideoPlayer.time);
		
		if (deltaT > 0.05f)
		{
			Debug.Log("Delta T too big, forced synchronocity:" + deltaT, gameObject);
			musicanAudioSource.time = (float)stageVideoPlayer.time;
		}
	}
}
