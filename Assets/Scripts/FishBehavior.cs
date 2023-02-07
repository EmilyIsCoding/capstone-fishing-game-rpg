using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishBehavior : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 1f;
    Vector3 fishStartPoint;
    Rigidbody2D myRigidBody;
    [SerializeField] bool isFacingRight = true;
    public bool bobberBite = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        fishStartPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var distanceFromOriginal = transform.position.x - fishStartPoint.x;

        if((isFacingRight && distanceFromOriginal >= 2) || (!isFacingRight&& distanceFromOriginal <= -2))
        {
            TurnFish();
        }
        var newSpeed = isFacingRight ? moveSpeed : -moveSpeed;
        myRigidBody.velocity = new Vector2(newSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // var newSign = -(Mathf.Sign(myRigidBody.velocity.x));
        // transform.localScale = new Vector(newSign * transform.localScale.x, transform.localScale.y, transform.localScale.z);

        // TurnFish();

        Player player = collision.GetComponent<Player>();

        if(player)
        {
            player.numFish++;
            Destroy(this.gameObject);
        }
        // run whenever a fish is successfully reeled in, rather than colliding



        // grab the Bobber component and if there's a collision with the fish, transform the fish
    }

    private void TurnFish()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}



// do these each step by step

// make the fish parent a child of the bobber using Transform.parent when hooked
// new state for when the Fish is fighting with the bobber, stop having it move left and right
// add force to Bobber as the Fish fights it, have it stay still for a bit, then move down and right (opposite the direction of the line)
// make the force SLIGHTLY stronger than the line