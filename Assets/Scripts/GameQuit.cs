using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
#endif
    }
}
