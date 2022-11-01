using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedIncrease : MonoBehaviour
{
    [SerializeField]
    float secondsToSlow;

    [SerializeField]
    Player player;

    [SerializeField]
    PlayerMovement movement;

    float timeNotDigging = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnGroundSpawned.AddListener(() => timeNotDigging = 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeNotDigging += Time.deltaTime;
        if (!player.InGround)
        {
            movement.UseSpeedMultiplier = true;
        }
        else
        {
            movement.UseSpeedMultiplier = timeNotDigging > secondsToSlow;
        }
    }
}
