using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public bool isReeled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine(ReelIn());
        }
    }

    IEnumerator ReelIn()
    {
        isReeled = true;
        yield return new WaitForSeconds(.1f);
        isReeled = false;
    }
}
