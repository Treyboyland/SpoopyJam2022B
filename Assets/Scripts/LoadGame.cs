using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetButtonDown("Quit") && !Input.GetButtonDown("Screenshot"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
