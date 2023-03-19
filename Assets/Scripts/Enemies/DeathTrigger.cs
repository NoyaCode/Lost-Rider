using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public int id;
    public Rigidbody PlayerRb;
    private void OnTriggerEnter(Collider other)
    {
        if(PlayerRb.velocity.y < -0.01)
        {
            GameEvents.current.JumpedOnEnemy(id);
        }
    }
}
