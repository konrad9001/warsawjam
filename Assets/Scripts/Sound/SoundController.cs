using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public List<AudioSource> audios;
    public ScreamSounds screams;


    public void playSoundEffect(string name)
    {
        if (name.Equals(Keys.Sounds.SCREAM))
        {
            screams.GetRandomScream().Play();
        }
        else
            foreach (AudioSource audio in audios)
            {
                if (audio.name.Equals(name))
                {
                    audio.Play();
                    break;
                }
            }
    }

    public void stopSoundEffect(string name)
    {
        foreach (AudioSource audio in audios)
        {
            if (audio.name.Equals(name))
            {
                audio.Stop();
                break;
            }
        }
    }
}
