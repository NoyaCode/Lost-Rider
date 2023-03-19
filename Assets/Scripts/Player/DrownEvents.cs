using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownEvents : MonoBehaviour
{
    private readonly float damage = -1;
    public Animator playerAnimator;
    public PlayerMovements player;
    public Rigidbody playerRb;
    public CapsuleCollider playerCollider;
    public PlayerManager playerManager;
    private void Start()
    {
        player.GetComponent<PlayerMovements>();
        playerRb.GetComponent<Rigidbody>();
        playerCollider.GetComponent<CapsuleCollider>();

        GameEvents.current.OnFellInWater += DrownAnim;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnFellInWater -= DrownAnim;
    }

    private void DrownAnim()
    {
        playerAnimator.SetTrigger("inWater");
        StartCoroutine(Drowning());
    }
    private IEnumerator Drowning()
    {
        player.canMove = false;
        playerCollider.enabled = false;
        playerRb.velocity = Vector3.zero;                               
        Physics.gravity = Vector3.down;
        yield return new WaitForSecondsRealtime(1.4f);
        GameEvents.current.PlayerHpUpdate(damage, false);
        GameEvents.current.ResetPlatforms();
        transform.position = playerManager.respawnPos;
        Physics.gravity = new Vector3(0, -20, 0);
        playerCollider.enabled = true;
        player.canMove = true;

    }
}
