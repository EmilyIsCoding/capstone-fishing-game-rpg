using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    //get input from player
    // apply movement to sprite

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        // tied to A / D and Up and Down, can be used to move bobber
        float vertical = Input.GetAxisRaw("Vertical");
        // can be used to move fishing rod power

        Vector3 direction = new Vector3(horizontal, vertical);

        transform.position += direction * speed * Time.deltaTime;
    }
}
