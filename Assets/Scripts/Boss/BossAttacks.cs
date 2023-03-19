using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject fireball;
    public Transform fireBallPoint;
    public float speed = 600;
    public void Fireball()
    {
        GameObject ball = Instantiate(fireball, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Projectile>().direction = fireBallPoint.forward;
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * speed);
    }
}
