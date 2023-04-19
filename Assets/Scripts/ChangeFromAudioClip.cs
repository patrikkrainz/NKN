using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource source;

    public Light light;

    public Vector3 minScale;
    public Vector3 maxScale;

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
            //light = GetComponent<Light>(); not implemented yet
            //light.range = 10;
        }
    }
}
