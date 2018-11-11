using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    [SerializeField]
    List<AudioSource> audioToGet;
    [SerializeField]
    List<AudioSource> smallMonstersRandom;
    [SerializeField]
    List<AudioSource> bigMonsterRandom;

    public AudioSource GetRandomBlood()
    {
        return audioToGet[Random.Range(0, 2)];
    }

    public AudioSource GetRandomMonsterAudio()
    {
        return bigMonsterRandom[Random.Range(0, bigMonsterRandom.Count)];
    }

}
