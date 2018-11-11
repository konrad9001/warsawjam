using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    [SerializeField]
    List<AudioSource> audioToGet;


    public AudioSource GetAudioByName(string name)
    {
        foreach(AudioSource a in audioToGet)
        {
            if (a.name.Equals(name))
                return a;
        }
        return null;
    }
}
