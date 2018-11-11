using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSounds : MonoBehaviour
{

    public List<AudioSource> screams;

    public AudioSource GetRandomScream()
    {
        return screams[Random.Range(0, screams.Count)];
    }
}
