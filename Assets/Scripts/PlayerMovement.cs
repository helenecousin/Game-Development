using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    
    [SerializeField] private float flightForce = 8f;
    [SerializeField] private float flightGravity = 1f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    // stores the Rigidbody2D's normal gravity value so that it can be
    //restored when the booster ends
    private float normalGravity;

    private void Awake()
    {
        // store the original gravity scale when the player is created
        // so that it can be restored when the booster ends
        normalGravity = rb.gravityScale;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        //check whether booster is currently active
        PlayerBooster booster = GetComponent<PlayerBooster>();

        if (booster != null && booster.IsBoosted())
        {
            //while boosted, normal jumping is replaced with flight
            HandleFlight();

            //stops normal jump code from running while booster is active
            return;
        }

        //JUMPING
        #region JUMPING

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpForce;

        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.linearVelocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

        #endregion
    }

    private void HandleFlight()
    {
        rb.gravityScale = flightGravity;

        if (Input.GetButton("Jump"))
        {
            rb.linearVelocity = Vector2.up * flightForce;
        }
        else
        {
            //when space is released, does not apply upward force
            //gravity will gradually pull the player downward
            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            }
        }
    }

    public void EndFlight()
    {
        rb.gravityScale = normalGravity;

        isJumping = false;
        jumpTimer = 0;
    }
}


