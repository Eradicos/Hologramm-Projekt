using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class PlayParticleOneAwayke : MonoBehaviour
{
	public GameObject child;

	private void OnEnable()
	{
		Debug.Log("IsAwake!!!!!");
		child.transform.position = gameObject.transform.position;
		for (int z = 0; z < child.transform.childCount; z++)
		{
			child.transform.GetChild(z).GetComponent<ParticleSystem>().Play();
			//glitter.GetComponent<ParticleSystem>().Stop();
		}
		gameObject.GetComponentInParent<BGCcCursor>().enabled = true;
	}
}
