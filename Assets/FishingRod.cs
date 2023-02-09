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

    IEnumerator ReelIn()
    {
        isReeled = true;
        yield return new WaitForSeconds(.1f);
        isReeled = false;
    }}
