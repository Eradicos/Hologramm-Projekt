using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRaycastHit : MonoBehaviour
{

	public GameObject stage;

	private void OnEnable()
	{
		stage.GetComponent<ActivateVideoPlayer>().RenderTexCounter += 1;

	}

	private void OnDisable()
	{
		stage.GetComponent<ActivateVideoPlayer>().RenderTexCounter -= 1;

	}
}
