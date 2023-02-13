using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Fishing_Line_Button : MonoBehaviour
{
    public Bobber bobber;
    public FishingRod fishingRod;
    public FishBehavior mediumFish;
    Vector3 bobberOriginalPos;

    // Start is called before the first frame update
    void Start()
    {
        bobberOriginalPos = bobber.transform.position;
    }

    public void resetFishingLine()
    {
        {   
            mediumFish.transform.SetParent(null, true);
            fishingRod.isCast = false;
            fishingRod.isCasting = false;
            fishingRod.isReeled = false;
            fishingRod.castPower = 0f;
            bobber.underwater = false;
            bobber.transform.position = new Vector3(bobberOriginalPos.x, bobberOriginalPos.y, bobberOriginalPos.z);
        }
    }
}
