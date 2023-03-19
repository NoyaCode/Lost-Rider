using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{
    public Rigidbody playerRb;
    public PlayerMovements player;
    [SerializeField] private float bumpPower;
    [SerializeField] private float stunDuration;
    void Start()
    {
        bumpPower = 20;
        stunDuration = 1.2f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerRb.velocity.y < -0.01 && !player.isStunned)
        {
            Vector3 force = (gameObject.transform.forward + Vector3.up/2f) * bumpPower;
            GameEvents.current.CollisionPlayerEnemy(force, stunDuration);
            GameEvents.current.BossGotHit();
        }
    }
}
