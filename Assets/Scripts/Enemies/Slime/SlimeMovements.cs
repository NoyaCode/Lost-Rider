using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovements : MonoBehaviour
{
    public int id;
    public float[] targetPoints;
    public float speed;
    private int targetId;
    public Transform model;

    void Start()
    {
        speed = 2;
        GameEvents.current.OnJumpedOnEnemy += StopSlimeMovement;
    }

    void Update()
    {
        Vector3 direction = Vector3.right * speed;
        transform.Translate(direction * Time.deltaTime);

        float targetDistance = Mathf.Abs(targetPoints[targetId] - transform.position.x);
        if(targetDistance<0.3)
        {
            speed *= -1;
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(Mathf.Sign(speed), 0, 0));
            model.rotation = newRotation;
            targetId = (targetId + 1) % targetPoints.Length;
        }
    }

    private void StopSlimeMovement(int id)
    {
        if (id == this.id)
        {
            speed = 0;
        }
    }

    void OnDestroy()
    {
        GameEvents.current.OnJumpedOnEnemy -= StopSlimeMovement;
    }
}
