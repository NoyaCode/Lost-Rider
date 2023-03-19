using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperEvents : MonoBehaviour
{
    [SerializeField] private float bumpForce = 10;
    public Rigidbody playerRb;
    public PlayerMovements player;
    private Transform bumper;
    private Animator animator;
    private void Start()
    {
        bumper = GetComponent<Transform>().transform;
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 playerPos = new Vector3(collision.transform.position.x, collision.transform.position.y - 0.2f, 0);
        Vector3 direction = playerPos - bumper.position;
        direction.Normalize();
        animator.SetTrigger("wigle");
        playerRb.AddForce(direction * bumpForce, ForceMode.Impulse);
        player.canDoubleJump = true;
    }
}
