using System.Collections;
using UnityEngine;

public class PlayerBooster : MonoBehaviour
{
    //determines how long the booster remains active
    [SerializeField] private float boosterDuration = 10f;

    //keeps track of whether the booster is currently active
    //which prevents booster from being activated multiple times
    private bool isBoosted = false;

    //stores a reference to the player's Collider2D so that it can
    //temporarily be disabled during the booster
    private Collider2D playerCollider;


    private void Awake()
    {
        //gets the Collider2D attached to the same GameObject as this script.
        //stores the reference once instead of repeatedly searching for
        //the component whenever the booster is activated
        playerCollider = GetComponent<Collider2D>();
    }


    //called by PlayerCollection when the potion meter reaches its maximum amount
    public void ActivateBooster()
    {
        //does nothing if the booster is already active
        if (isBoosted)
        {
            return;
        }

        // starts the booster as a coroutine so that the game can continue
        // running normally while the 10-second timer counts down
        StartCoroutine(BoosterRoutine());
    }


    // controls everything that happens while the booster is active
    private IEnumerator BoosterRoutine()
    {
        // marks the booster as active before changing any gameplay behaviour
        isBoosted = true;


        // disables the player's collider so that the cat can pass through
        // platforms and obstacles without triggering normal collision behaviour
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }


        // keeps the booster active for the specified amount of time
        yield return new WaitForSeconds(boosterDuration);


        // re-enable the player's collider so that normal collisions with
        // platforms and obstacles work again after the booster ends
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        //tells playerMovement that the booster has ended so that normal gravity and jump can be restored
        PlayerMovement movement = GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.EndFlight();
        }

        // the player can activate the booster again after collecting
        //another full set of ingredients
        isBoosted = false;
    }


    // allows other scripts, such as the UI, to check whether the booster is currently active
    public bool IsBoosted()
    {
        return isBoosted;
    }
}