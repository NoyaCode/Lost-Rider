using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime;
    public float damage;
    public Vector3 direction;
    [SerializeField] private float bumpPower;
    [SerializeField] private float stunDuration;

    void Start()
    {
        lifetime = 2.9f;
        damage = -0.5f;
        damage = -0.5f;
        bumpPower = 8;
        stunDuration = 0.5f;
        StartCoroutine(DestroyIn(lifetime));
    }

    private IEnumerator DestroyIn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.PlayerHpUpdate(damage, true);
        Vector3 force = (direction + Vector3.up) * bumpPower;
        GameEvents.current.CollisionPlayerEnemy(force, stunDuration);
        Destroy(gameObject);
    }
}
