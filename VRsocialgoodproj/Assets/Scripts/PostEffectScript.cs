using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectScript : MonoBehaviour
{
    [SerializeField]
    public Material postprocessMaterial;
    public bool blur;
    public GameObject player;

    private float blurSize;
    private float blurMax;
private float elapsedTime;

    void Start()
{
elapsedTime = 0.0f;
}
    void Update()
    {
        blurSize = 0;
        blurMax = 0.02f;
	

        if (player.GetComponent<PlayerController>().bloodSugar >= 200)
        {
            blur = true;
        }

        if (blur)
        {
	    elapsedTime += Time.deltaTime;
            blurSize = Mathf.SmoothStep(0, blurMax, Mathf.Log(elapsedTime));
            //blurSize = Mathf.PingPong(Time.time / 100, 0.08f);
        }
        postprocessMaterial.SetFloat("_BlurSize", blurSize);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {


        //draws the pixels from the source texture to the destination texture
        var temporaryTexture = RenderTexture.GetTemporary(source.width, source.height);
        Graphics.Blit(source, temporaryTexture, postprocessMaterial, 0);
        Graphics.Blit(temporaryTexture, destination, postprocessMaterial, 1);
        RenderTexture.ReleaseTemporary(temporaryTexture);
    }
}
