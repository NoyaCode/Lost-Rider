using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEvents : MonoBehaviour
{
    public int id;
    public float speed;
    public Animator animator;
    public GameObject target;
    public Transform model;
    private CharacterController controller;

    void Start()
    {
        speed = 4;
        controller = GetComponent<CharacterController>();
        GameEvents.current.OnEnterSpiderRange += ActivateChaseAnimation;
        GameEvents.current.OnInSpiderRange += ChaseTarget;
        GameEvents.current.OnExitSpiderRange += ActivateStaticAnimation;
    }

    private void ActivateChaseAnimation(int id)
    {
        if(id == this.id)
        {
            animator.SetTrigger("chase");
        }
    }

    private void ChaseTarget(int id)
    {
        if (id == this.id)
        {
            float direction = Mathf.Sign(target.transform.position.x - transform.position.x);
            Vector3 step = new Vector3(direction * speed, 0, 0);

            Quaternion newRotation = Quaternion.LookRotation(new Vector3(direction, 0, 0));
            model.rotation = newRotation;

            controller.Move(step * Time.deltaTime);
        }
    }

    private void ActivateStaticAnimation(int id)
    {
        if (id == this.id)
        {
            animator.SetTrigger("static");
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.OnEnterSpiderRange -= ActivateChaseAnimation;
        GameEvents.current.OnInSpiderRange -= ChaseTarget;
        GameEvents.current.OnExitSpiderRange -= ActivateStaticAnimation;
    }
}
