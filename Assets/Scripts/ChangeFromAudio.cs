using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeFromAudio : MonoBehaviour
{
    public AudioSource source;

    public Light2D light;

    public Vector3 minScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(3, 3, 3);

    public AudioLoudnessDetection detection;

    public bool shouldMove = true;
    public int loudnessSensitivity = 100;
    public float threshold = 0.1f;
    private float loudness;

    void Start()
    {
        
    }

    void Update()
    {
        loudness = detection.GetLoudnessfromMicrophone() * loudnessSensitivity;
        
        if(loudness < threshold)
        {
            loudness = 0;
        }
    }

    private void HandleChanges(bool shouldMove)
    {
        if (shouldMove)
        {

        }
        else
        {
            //transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
            
        }
    }
}
