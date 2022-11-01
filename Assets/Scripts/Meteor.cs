using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    Vector2Int maxHealthRange;

    [SerializeField]
    bool instaKill;

    public bool InstaKill { get => instaKill; }

    int currentHealth;

    static Orphanage orphanage;

    private void OnEnable()
    {
        currentHealth = maxHealthRange.Random();
        if (orphanage == null)
        {
            orphanage = GameObject.FindObjectOfType<Orphanage>();
        }
    }

    private void OnMouseDown()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            if (instaKill)
            {
                GameManager.Manager.OnMeteorDestroyLarge.Invoke(transform.position);
            }
            else
            {
                GameManager.Manager.OnMeteorDestroy.Invoke(transform.position);
            }
            GameManager.Manager.OnMeteorDeathSound.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.Manager.OnHitSound.Invoke();
            if (orphanage != null)
            {
                var point = orphanage.CurrentCamera.ScreenToWorldPoint(Input.mousePosition);
                point.z = 10;
                GameManager.Manager.OnHitParticle.Invoke(point);
            }
        }
    }
}
