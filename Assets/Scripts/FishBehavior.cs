using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishBehavior : MonoBehaviour
{   
    public GameObject mediumFish;
    [SerializeField] float moveSpeed = 1f;
    Vector3 fishStartPoint;
    Rigidbody2D myRigidBody;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool bobberBite = false;
    Bobber bobber;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        fishStartPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bobberBite)
        {
            var distanceFromOriginal = transform.position.x - fishStartPoint.x;
            if((isFacingRight && distanceFromOriginal >= 2) || (!isFacingRight&& distanceFromOriginal <= -2))
            {
                TurnFish();
            }
            var newSpeed = isFacingRight ? moveSpeed : -moveSpeed;
            myRigidBody.velocity = new Vector2(newSpeed, 0f);
        }
        else
        {
            bobber.HookedFish();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collidedBobber = collision.GetComponent<Bobber>();

        if(collidedBobber != null)
        {
            bobber = collidedBobber;
            mediumFish.transform.parent = bobber.transform;
            Debug.Log($"The fish's grandparent is now: {mediumFish.transform.parent.name}");
            bobberBite = true;
        }

        // Player player = collision.GetComponent<Player>();

        // if(player)
        // {
        //     player.numFish++;
        //     Debug.Log("Caught a fish!");
        //     Destroy(this.gameObject);
        // }
        // run whenever a fish is successfully reeled in, rather than colliding
        // maybe like if the position is where the player is?



    }

    private void TurnFish()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}



// do these each step by step

// make the fish parent a child of the bobber using Transform.parent when hooked -> DONE
// new state for when the Fish is fighting with the bobber, stop having it move left and right
// add force to Bobber as the Fish fights it, have it stay still for a bit, then move down and right (opposite the direction of the line)
// make the force SLIGHTLY stronger than the line

// when bobber collides with player, reset it's position?