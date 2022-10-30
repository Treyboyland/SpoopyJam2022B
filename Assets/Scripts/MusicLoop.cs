using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    [SerializeField]
    AudioClip startClip;

    [SerializeField]
    AudioClip loopingClip;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    float maxVolume;

    public float MaxVolume { get { return maxVolume; } }

    public float Volume { get { return source.volume; } set { source.volume = value; } }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenSetLoopingClip());
    }

    IEnumerator WaitThenSetLoopingClip()
    {
        source.clip = startClip;
        source.loop = false;
        source.Play();

        while (source.isPlaying)
        {
            yield return null;
        }

        source.clip = loopingClip;
        source.loop = true;
        source.Play();
    }
}