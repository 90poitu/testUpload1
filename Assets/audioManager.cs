using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource ErrorSound;
    public AudioSource RewardSound;
    public AudioSource ClickingSound;

    /// <summary>
    /// ErrorSound to play an error. RewardSound to play reward. ClickingSound to play mouse click.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    public void PlayAudio(string name, int volume)
    {
        switch (name)
        {
            case "ErrorSound":
                if (!ErrorSound.isPlaying)
                {
                    ErrorSound.volume = volume;
                    ErrorSound.Play();
                }
                break;
            case "RewardSound":
                if (!RewardSound.isPlaying)
                {
                    RewardSound.volume = volume;
                    RewardSound.Play();
                }
                break;
            case "ClickingSound":
                if (!ClickingSound.isPlaying)
                {
                    ClickingSound.volume = volume;
                    ClickingSound.Play();
                }

                break;
        }
    }
}
