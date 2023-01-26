using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught_Fish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();

        if (player) 
        {
            player.numFish++;
            Destroy(this.gameObject);
        }
    }
}

// Maybe for the bobber stuff just create an empty circle for now
// Then do the calcs for power * time = distance

// Then maybe collisions