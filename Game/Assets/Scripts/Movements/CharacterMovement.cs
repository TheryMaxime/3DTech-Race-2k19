using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int m_CharacterId; //ID of the current character            
    public float m_TurnSpeed = 0.0001f;
    public float m_speed = 0.01f;
    public Camera m_camera;

    //private Rigidbody m_Rigidbody;
    private CharacterController m_Rigidbody;
    private Transform m_transform;

    // Start is called before the first frame update
    void Awake()
    {
        //this.m_Rigidbody = GetComponent<Rigidbody>();
        this.m_Rigidbody = GetComponent<CharacterController>();
        this.m_transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        //m_Rigidbody.isKinematic = false;
        //this.m_Rigidbody.velocity = (new Vector3(0, 0, this.m_speed));
    }

    private void Update()
    {
        //this.m_Rigidbody.MovePosition(new Vector3(0, 0, this.m_speed));
        //this.m_Rigidbody.velocity = (new Vector3(0, 0, this.m_speed));
        Vector3 movement = this.m_transform.forward * this.m_speed;
        //this.m_Rigidbody.MovePosition(this.m_Rigidbody.position + movement);
        this.m_Rigidbody.Move(movement);
    }

    /*private void Turn(float angle)
    {

    }*/

    public void Move(float angle)
    {
        if (angle > 45)
            angle = 45;
        else if (angle < -45)
            angle = -45;
        //Vector3 movement = new Vector3(angle*this.m_TurnSpeed, 0, 0);
        //this.m_Rigidbody.MovePosition(this.m_Rigidbody.position + movement);
        //this.m_Rigidbody.velocity = this.m_Rigidbody.position + movement;
        //this.m_transform.rotation = Quaternion.Euler(0, angle, -angle);

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, angle*this.m_TurnSpeed, 0f);

        // Apply this rotation to the rigidbody's rotation.
        //this.m_Rigidbody.MoveRotation(this.m_Rigidbody.rotation * turnRotation);
        //this.m_Rigidbody.attachedRigidbody.MoveRotation(this.m_camera.transform.rotation * turnRotation);
        this.transform.Rotate(0f, angle * this.m_TurnSpeed, 0f);
        //this.m_camera.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
