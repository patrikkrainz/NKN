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

    public GameObject targetPosition;

    private Transform startPosition;

    public bool isPlatform;              //is a light or platform
    public bool horizontal;                     //which direction the platform moves

    public int loudnessSensitivity = 10000;
    public int velocity = 2;

    public float threshold = 0.1f;
    public float lightChangeSpeed = 0.05f;
    private float loudness;
    public float speed = 1.5f;

    void Start()
    {
        if (!isPlatform)
        {
            light = GetComponent<Light2D>();
        }
        else
        {
            startPosition = transform;
        }
    }

    void Update()
    {
        loudness = detection.GetLoudnessfromMicrophone() * loudnessSensitivity;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        HandleChanges(isPlatform);

        //Check if Sensitivity is ok
        if (loudness > 0.1)
        {
            print(loudness);
        }
    }

    private void HandleChanges(bool isPlatform)
    {
        if (isPlatform)
        {
            if(loudness > 0.1)
            {
                if (horizontal)
                {
                    if (Mathf.Abs(transform.position.x - targetPosition.transform.position.x) > 0.1)
                    {
                        transform.position = new(transform.position.x + velocity * Time.deltaTime * speed, transform.position.y);
                    }
                }
                else
                {
                    if (Mathf.Abs(transform.position.y - targetPosition.transform.position.y) > 0.1)
                    {
                        transform.position = new(transform.position.x, transform.position.y + velocity * Time.deltaTime * speed);
                    }
                }
            }
            else
            {
                if (horizontal)
                {
                    if(Mathf.Abs(transform.position.x - startPosition.transform.position.x) > 0.1)
                    {
                        transform.position = new(transform.position.x - velocity * Time.deltaTime * speed, transform.position.y);
                    }
                }
                else
                {
                    if (Mathf.Abs(transform.position.y - startPosition.transform.position.y) > 0.1)
                    {
                        transform.position = new(transform.position.x, transform.position.y - velocity * Time.deltaTime * speed);
                    }
                }
            }
        }
        else
        {
            if(loudness > 0.1)
            {
                if(light.intensity < 1)
                {
                    light.intensity += lightChangeSpeed;
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
                    light.intensity -= lightChangeSpeed;
                }
                else
                {
                    light.intensity = 0;
                }
            }
        }
    }
}
