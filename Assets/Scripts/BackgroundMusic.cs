using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    MusicLoop normalAudio;

    static BackgroundMusic _instance = null;

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Debug.LogWarning("Destroy: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


}