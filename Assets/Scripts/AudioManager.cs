using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backAudio;
    public static bool isMusic = true;

    private void Start()
    {
        if (isMusic)
        {
            backAudio.Play();
        }
        else if (!isMusic)
        {
            backAudio.Stop();
        }
    }

    public void MusicOn()
    {
        backAudio.volume = 0.05f;
        isMusic = true;
    }

    public void MusicOff()
    {
        backAudio.volume = 0;
        isMusic = false;
    }
}
