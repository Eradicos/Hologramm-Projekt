using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour {

    public Transform[] Magnets;
    public float strength = 10f;
    public int findMagNum;
    public int defaultMagNum;


    private void Start()
    {
        defaultMagNum = findMagNum;
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, Magnets[findMagNum].position, strength * Time.deltaTime);
	}
}
