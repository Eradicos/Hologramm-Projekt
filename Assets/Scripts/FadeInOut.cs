using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FadeInOut : MonoBehaviour
{

    public GameObject RenderTex1;
    public GameObject RenderTex2;
    private float alpha;
    public float speed;
    private float t;
    private bool startFade;
    private bool startFadeOut;
    private Texture tex;

    private void OnEnable()
    {
        Debug.Log("Wach");
        startFade = true;
        alpha = 0;
        t = 0;
    }

    private void FixedUpdate()
    {

        if (startFade && alpha <= 255)
        {
            alpha = Mathf.Lerp(0, 255, t);
            SetMaterialTransparent();
        }
        else if (Input.GetKey("left") && alpha <= 255)
        {
            Debug.Log("blaaaaa");
            alpha = Mathf.Lerp(255, 130, t);
            SetMaterialTransparent();
        }else
        {
            startFade = false;
            startFadeOut = false;
        }

        if (t <= 1.0f)
        {
            t += Time.fixedDeltaTime/5;
        }

    }



    private void SetMaterialTransparent()

    {

        foreach (Material m in RenderTex1.GetComponent<Renderer>().materials)
        {

            m.SetFloat("_Alpha", alpha/255);
            //Color32 col = m.color;
            //col.a = (byte)alpha;
            //m.SetColor("_Color", col);

            m.SetFloat("_Mode", 2);

            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            m.SetInt("_ZWrite", 0);

            m.DisableKeyword("_ALPHATEST_ON");

            m.EnableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = 3000;

        }

    }

    private void SetMaterialOpaque()

    {

        foreach (Material m in RenderTex2.GetComponent<Renderer>().materials)

        {
            m.SetFloat("_Alpha", alpha / 255);

            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);

            m.SetInt("_ZWrite", 1);

            m.DisableKeyword("_ALPHATEST_ON");

            m.DisableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = -1;

        }

    }
}