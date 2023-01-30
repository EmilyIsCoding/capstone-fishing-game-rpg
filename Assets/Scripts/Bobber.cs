using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bobber : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 2f;

    public float waterHeight = -2.5f;
    
    // public float lineStrength = 1f;

    Rigidbody2D m_Rigidbody;

    bool underwater;
    

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;
        
        if (difference < 0)
        {
            m_Rigidbody.AddForceAtPosition(Vector2.up * floatingPower * Mathf.Abs(difference), transform.position);
            // calculate the vector direction from the fishing line, subtract the NORMALIZED line position from the bobber position
            // lineVector = transform.position - lineConnectionTransform.position;
            // lineVector.normalize();
            // Rigidbody2D.AddForce(lineStrength * lineVector);

            
            // multiple that by the line effect
            Debug.Log($"DEBUG applying upward force at {difference}");

            if(!underwater)
            {
                underwater = true;
                SwitchState(true);
            }
        }
        else if (underwater)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        }
        else 
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}
