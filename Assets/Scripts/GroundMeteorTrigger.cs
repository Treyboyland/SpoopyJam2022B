using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMeteorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var meteor = collision.gameObject.GetComponent<Meteor>();

        if (meteor != null)
        {
            if (!meteor.InstaKill)
            {
                GameManager.Manager.OnGroundHit.Invoke();
            }
            else
            {
                GameManager.Manager.OnInstantDie.Invoke();
            }

            var pos = meteor.transform.position;
            meteor.gameObject.SetActive(false);
            GameManager.Manager.OnMeteorDestroy.Invoke(pos);
        }
    }
}
