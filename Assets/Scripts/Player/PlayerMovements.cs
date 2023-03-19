using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public bool canMove = true;
    private Rigidbody rb;
    public float speed = 8;
    private float acceleration;
    private float deceleration;
    [SerializeField] private float hInput;


    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool canDoubleJump = true;
    public bool isStunned = false;

    public Animator playerAnimator;
    public Transform model;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameEvents.current.OnCollisionPlayerEnemy += BumpPlayer;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnCollisionPlayerEnemy -= BumpPlayer;
    }

    private void Update()
    {
        if(canMove)
        {
            UpdateMovement();
        }
    }

    private void FixedUpdate()
    {
        if (canMove && !isStunned)
        {
            Run();
        }
    }

    #region Movements

    private void UpdateMovement()
    {
        hInput = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("speed", Mathf.Abs(hInput));

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            acceleration = 8;
            deceleration = 15;
            canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            acceleration = 4;
            deceleration = 1;
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                playerAnimator.SetTrigger("doubleJump");
                canDoubleJump = false;
                Jump();
            }
        }

        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }
    }

    private void Run()
    {
        float targetSpeed = hInput * speed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        rb.AddForce(speedDif * accelRate * Vector2.right);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
    }

    private void BumpPlayer(Vector3 force, float stunDuration)
    {
        rb.velocity = force;
        StartCoroutine(StunPlayer(stunDuration));
    }
    private IEnumerator StunPlayer(float stunDuration)
    {
        isStunned = true;
        yield return new WaitForSecondsRealtime(stunDuration);
        isStunned = false;
    }

    #endregion
}
