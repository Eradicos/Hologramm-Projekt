using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRenderTexture : MonoBehaviour
{

	public GameObject stage;
	public GameObject finger;
	public GameObject palm;
	private bool detectorOn = false;
	public bool checkHit = false;
	public RaycastHit hit;

	private void Update()
	{

		if (detectorOn)
		{
		
			Debug.DrawRay(finger.transform.position, finger.transform.forward * 100, Color.red, 5);
			if (Physics.Raycast(finger.transform.position, finger.transform.forward, out hit))
			{
				
				if (hit.transform.gameObject.name == "Magnet")
				{
					checkHit = true;
					hit.transform.GetChild(0).gameObject.SetActive(true);
					hit.transform.parent.GetChild(0).gameObject.SetActive(true);
					hit.transform.parent.GetChild(0).gameObject.GetComponent<PlayParticleOneAwayke>().enabled = true;


				}
			}
		}

		if(detectorOn == false)
		{

			Debug.Log("ist false");
			Debug.DrawRay(palm.transform.position, -palm.transform.up * 100, Color.red, 1);
			if (Physics.Raycast(palm.transform.position, -palm.transform.up, out hit))
			{
				
				if (hit.transform.gameObject.name == "Magnet")
				{
					hit.transform.GetChild(0).gameObject.SetActive(false);
					hit.transform.parent.GetChild(0).gameObject.SetActive(false);
					hit.transform.parent.GetChild(0).gameObject.GetComponent<PlayParticleOneAwayke>().enabled = false;
				}
			}

		}

	}

	public void HitRender()
	{
		detectorOn = true;
		

	}

	public void HitFalse()
	{
		detectorOn = false;
		//stage.GetComponent<ActivateVideoPlayer>().RenderTexCounter -= 1;

	}

}
