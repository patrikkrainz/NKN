using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeFromAudio : MonoBehaviour
{
    public Light2D light;

    public Vector3 minScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(3, 3, 3);

    public AudioLoudnessDetection detection;

    public bool shouldMove = true;
    public int loudnessSensitivity = 10000;
    public float threshold = 0.1f;
    private float loudness;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

    void Update()
    {
        loudness = detection.GetLoudnessfromMicrophone() * loudnessSensitivity;
        
        if(loudness < threshold)
        {
            loudness = 0;
        }

        HandleChanges(shouldMove);

        //Check if Sensitivity is ok
        /*if(loudness > 0.1)
        {
            print(loudness);
        }*/
    }

    private void HandleChanges(bool shouldMove)
    {
        if (shouldMove)
        {

        }
        else
        {
            //transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
            if(loudness > 0.1)
            {
                if(light.intensity < 1)
                {
                    light.intensity += 0.05f;
                }
                else
                {
                    light.intensity = 1;
                }
            }
            else
            {
                if(light.intensity > 0)
                {
                    light.intensity -= 0.05f;
                }
                else
                {
                    light.intensity = 0;
                }
            }
        }
    }
}
