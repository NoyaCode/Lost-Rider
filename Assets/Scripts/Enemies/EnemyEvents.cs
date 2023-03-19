using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyEvents : MonoBehaviour
{
    
    public int id;

    public Animator enemyAnimator;
    public BoxCollider[] enemyBoxes;

    public PlayerMovements playerMovements;
    public PlayerManager playerManager;
    public GameObject heartObject;

    private readonly float stunDuratiion = 0.5f;
    private readonly float bumpPower = 8;
    private readonly float damage = -0.5f;

    void Start()
    {
        enemyBoxes = GetComponentsInChildren<BoxCollider>();
        GameEvents.current.OnJumpedOnEnemy += KillEnemy;
    }
    void OnDestroy()
    {
        GameEvents.current.OnJumpedOnEnemy -= KillEnemy;
    }

    #region Hit Player

    private void OnCollisionEnter(Collision other)
    {
        float direction = Mathf.Sign(other.transform.position.x - transform.position.x);
        Vector3 force = new Vector3(direction, 1, 0) * bumpPower;
        GameEvents.current.CollisionPlayerEnemy(force, stunDuratiion);
        GameEvents.current.PlayerHpUpdate(damage, true);
    }

    #endregion

    #region Death

    private void KillEnemy(int id)
    {
        if(id == this.id)
        {
            foreach (BoxCollider box in enemyBoxes)
            {
                box.enabled = false;
            }

            StartCoroutine(DeathAnim());
            playerMovements.Jump();
        }
    }

    public IEnumerator DeathAnim()
    {
        enemyAnimator.SetTrigger("dead");
        yield return new WaitForSecondsRealtime(1f);
        System.Random rnd = new System.Random();
        if (rnd.Next(3) == 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(0, 1, 0));
            Instantiate(heartObject, new Vector3(transform.position.x, transform.position.y + 1, 0), newRotation);
        }
            
        Destroy(gameObject);
    }
    #endregion
}
