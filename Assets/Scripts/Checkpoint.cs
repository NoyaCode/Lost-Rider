using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool reached = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!reached)
        {
            reached = true;
            animator.SetTrigger("reached");
            GameEvents.current.CheckpointReached(new Vector3(transform.position.x, transform.position.y + 2, 0));
        }
    }
}
