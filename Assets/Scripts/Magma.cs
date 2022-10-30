using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{

    private void OnEnable()
    {
        if(gameObject.activeInHierarchy)
        {
            GameManager.Manager.OnMagmaSpawn.Invoke(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            GameManager.Manager.OnMagmaPickup.Invoke();
            gameObject.SetActive(false);
        }
    }
}
