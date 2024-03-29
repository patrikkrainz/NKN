using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 32;
    private AudioClip microphoneClip;

    void Start()
    {
        MicrophoneToAudioClip();
    }

    void Update()
    {
        //Mic check
        //print(Microphone.devices.Length);
        //print(Microphone.devices[0]);

        //print(AudioSettings.outputSampleRate);
    }

    public void MicrophoneToAudioClip()
    {
        if(Microphone.devices.Length > 0)
        {
            string microphoneName = Microphone.devices[0];
            microphoneClip = Microphone.Start(microphoneName, true, 10, 10000);
        }
        else
        {
            print("No Mic");
        }
    }

    public float GetLoudnessfromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0)
        {
            return 0;
        }

        float[] wavedata = new float[sampleWindow];
        clip.GetData(wavedata, startPosition);

        float totalLoudness = 0;

        for(int i = 0; i < sampleWindow; i++)
        {
            totalLoudness = Mathf.Abs(wavedata[i]);
        }

        return totalLoudness / sampleWindow;
    }
}
