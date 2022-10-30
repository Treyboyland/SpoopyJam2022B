using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orphanage : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    Camera orphanCamera;

    private void Start()
    {
        SetCameras(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            SetCameras(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            SetCameras(true);
        }
    }


    void SetCameras(bool playerActive)
    {
        playerCamera.gameObject.SetActive(playerActive);
        orphanCamera.gameObject.SetActive(!playerActive);
    }
}
