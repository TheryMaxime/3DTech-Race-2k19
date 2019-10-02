using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int m_CharacterId; //ID of the current character            
    public float m_TurnSpeed = 0.0001f;

    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        this.m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }

    /*private void Turn(float angle)
    {

    }*/

    public void Move(float angle)
    {
        float computeAngle = 1 - ((45 - angle) / 45);
        if (computeAngle > 1)
            computeAngle = 1;
        else if (computeAngle < -1)
            computeAngle = -1;
        Vector3 movement = new Vector3(angle*this.m_TurnSpeed, 0, 0);   
        this.m_Rigidbody.MovePosition(this.m_Rigidbody.position + movement);
    }
}
