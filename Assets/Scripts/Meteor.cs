using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    Vector2Int maxHealthRange;

    int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealthRange.Random();
    }

    private void OnMouseDown()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            GameManager.Manager.OnMeteorDestroy.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }
}
