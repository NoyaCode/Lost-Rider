using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovements : MonoBehaviour
{
    private Vector3 initialPos;
    public Vector3[] targetPoints;
    private Vector3 direction;
    private int targetId = 0;
    [SerializeField] private float speed = 2;

    void Start()
    {
        speed = 2;
        initialPos = transform.position;
        direction = targetPoints[0] - initialPos;
        direction.Normalize();

        GameEvents.current.OnResetPlatforms += Reset;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnResetPlatforms -= Reset;
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        float targetDistance = (targetPoints[targetId] - transform.position).magnitude;
        if (targetDistance < 0.3)
        {
            targetId++;
            if(targetId == targetPoints.Length)
            {
                Reset();
                return;
            }
            direction = (targetPoints[targetId] - transform.position);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        collision.gameObject.transform.position += direction * Time.deltaTime * speed;
    }

    private void Reset()
    {
        transform.position = initialPos;
        direction = targetPoints[0] - initialPos;
        direction.Normalize();
        targetId = 0;
        enabled = false;
    }
}
