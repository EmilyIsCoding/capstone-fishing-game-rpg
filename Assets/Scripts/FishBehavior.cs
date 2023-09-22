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
            isFacingRight = true;
            mediumFish.transform.parent = bobber.transform;
            bobberBite = true;
        }

        Player player = collision.GetComponent<Player>();

        if(player)
        {
            player.numFish++;
            Debug.Log("Caught a fish!");
            Destroy(this.gameObject);
        }
    }

    private void TurnFish()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}