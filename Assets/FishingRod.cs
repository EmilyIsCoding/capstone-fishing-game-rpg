using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public bool isReeled = false;
    public Bobber bobber = null;
    public bool isCasting = false;
    public bool isCast = false;
    public float castPower = 0f;
    public Player player = null;

    // put a collider on the fishing rod, and when the fish collides with it, the player grabs the fish
    // make the collider bigger than the square

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCasting && !isCast && Input.GetKeyDown("z"))
        {
            castPower = 0f;
            isCasting = true;
        }
        else if (!isCast && Input.GetKeyUp("z"))
        {
            bobber.PerformCast(castPower);
            isCasting = false;
            isCast = true;
        }
        else if (!isCast)
        {
            castPower += 0.005f;
            Mathf.Clamp(castPower, 0f, 1f);
        }

        else if (isCast && bobber.underwater && (Input.GetKeyDown("z")))
        {
            StartCoroutine(ReelIn());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var fish = collision.GetComponent<FishBehavior>();

        if(fish != null)
        {
            // looks a bit janky with the movement, maybe animate to trophy box
            fish.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);

            player.numFish++;
            Debug.Log("Caught a fish!");
            Destroy(fish);
        }
    }

    IEnumerator ReelIn()
    {
        isReeled = true;
        yield return new WaitForSeconds(.1f);
        isReeled = false;
    }}
