using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public Animator animator;
    public BoxCollider box;
    void Start()
    {
        GameEvents.current.OnEnterBossArea += CloseDoor;
        animator = GetComponent<Animator>();
        animator.SetTrigger("open");
    }

    private void OnDestroy()
    {
        GameEvents.current.OnEnterBossArea -= CloseDoor;
    }

    public void CloseDoor()
    {
        animator.SetTrigger("close");
        box.isTrigger = false;
    }
}
