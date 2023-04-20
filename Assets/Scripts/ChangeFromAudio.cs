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

    public GameObject Target;

    public Vector3 targetPosition;
    private Vector3 startPosition;

    public bool isPlatform;                     //is a light or platform
    public bool horizontal;                     //which direction the platform moves
    public bool startsLeft;
    public bool startsRight;
    public bool startsUp;
    public bool startsDown;
    public bool change = false;

    public int loudnessSensitivity = 1000;
    public int velocity = 2;

    public float threshold = 0.3f;
    public float lightChangeSpeed = 0.1f;
    private float loudness;
    public float speed = 1.5f;
    public float changeTimer = 0;

    void Start()
    {
        if (!isPlatform)
        {
            light = GetComponent<Light2D>();
        }
        else
        {
            startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            targetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        }
    }

    void Update()
    {
        loudness = detection.GetLoudnessfromMicrophone() * loudnessSensitivity;

        if (loudness < threshold)
        {
            loudness = 0;
            changeTimer += Time.deltaTime;
        }
        else
        {
            change = true;
            changeTimer = 0;
        }

        if(changeTimer >= 0.3f)
        {
            change = false;
            changeTimer = 0;
        }

        HandleChanges(isPlatform);

        //Check if Sensitivity is ok
        /*if (loudness > 0.1)
        {
            print(loudness);
        }*/

        //print(loudness);
    }

    private void HandleChanges(bool isPlatform)
    {
        if (isPlatform)
        {
            if(change)
            {
                if (horizontal)
                {
                    if (startsLeft)
                    {
                        if (Mathf.Abs(transform.position.x - targetPosition.x) > 0.1)
                        {
                            transform.position = new(transform.position.x + velocity * Time.deltaTime * speed, transform.position.y);
                        }
                    }
                    else if (startsRight)
                    {
                        if (Mathf.Abs(transform.position.x - targetPosition.x) > 0.1)
                        {
                            transform.position = new(transform.position.x - velocity * Time.deltaTime * speed, transform.position.y);
                        }
                    }
                }
                else
                {
                    if (startsDown)
                    {
                        if (Mathf.Abs(transform.position.y - targetPosition.y) > 0.1)
                        {
                            transform.position = new(transform.position.x, transform.position.y + velocity * Time.deltaTime * speed);
                        }
                    }
                    else if (startsUp)
                    {
                        if (Mathf.Abs(transform.position.y - targetPosition.y) > 0.1)
                        {
                            transform.position = new(transform.position.x, transform.position.y - velocity * Time.deltaTime * speed);
                        }
                    }
                }
            }
            else
            {
                if (horizontal)
                {
                    if (startsLeft)
                    {
                        if (Mathf.Abs(transform.position.x - startPosition.x) > 0.1)
                        {
                            transform.position = new(transform.position.x - velocity * Time.deltaTime * speed, transform.position.y);
                        }
                    }
                    else if (startsRight)
                    {
                        if (Mathf.Abs(transform.position.x - startPosition.x) > 0.1)
                        {
                            transform.position = new(transform.position.x + velocity * Time.deltaTime * speed, transform.position.y);
                        }
                    }
                }
                else
                {
                    if (startsDown)
                    {
                        if (Mathf.Abs(transform.position.y - startPosition.y) > 0.1)
                        {
                            transform.position = new(transform.position.x, transform.position.y - velocity * Time.deltaTime * speed);
                        }
                    }
                    else if (startsUp)
                    {
                        if (Mathf.Abs(transform.position.y - startPosition.y) > 0.1)
                        {
                            transform.position = new(transform.position.x, transform.position.y + velocity * Time.deltaTime * speed);
                        }
                    }
                }
            }
        }
        else
        {
            if(change)
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
