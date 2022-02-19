using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectSoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip soundTouch;
    public AudioClip soundLvUP;
    public AudioClip soundBuy;
    public AudioClip soundAlert;
    public AudioClip soundRandom;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "Touch":
                audioSource.clip = soundTouch;
                break;
            case "LvUP":
                audioSource.clip = soundLvUP;
                break;
            case "Buy":
                audioSource.clip = soundBuy;
                break;
            case "Alert":
                audioSource.clip = soundAlert;
                break;
            case "Random":
                audioSource.clip = soundRandom;
                break;
        }
        audioSource.Play();
    }
}
