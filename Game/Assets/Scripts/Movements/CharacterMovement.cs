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
    private float m_speedController = 0f;
    private bool m_isOver;

    // Start is called before the first frame update
    void Awake()
    {
        //this.m_Rigidbody = GetComponent<Rigidbody>();
        this.m_Rigidbody = GetComponent<CharacterController>();
        this.m_transform = GetComponent<Transform>();
        this.m_isOver = false;
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
        if (!this.m_isOver)
        {
            Vector3 gravity = new Vector3(0f, 0f, 0f);
            if (!this.m_Rigidbody.isGrounded)
                gravity = new Vector3(0f, -1f, 0f);
            Vector3 movement = this.m_transform.forward * this.m_speed * this.m_speedController + gravity;
            //this.m_Rigidbody.MovePosition(this.m_Rigidbody.position + movement);
            this.m_Rigidbody.Move(movement);
        }
    }
    
    public void Move(float angle)
    {
        if (angle > 60)
            angle = 60;
        else if (angle < -60)
            angle = -60;
        //Vector3 movement = new Vector3(angle*this.m_TurnSpeed, 0, 0);
        //this.m_Rigidbody.MovePosition(this.m_Rigidbody.position + movement);
        //this.m_Rigidbody.velocity = this.m_Rigidbody.position + movement;
        //this.m_transform.rotation = Quaternion.Euler(0, angle, -angle);

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, angle*this.m_TurnSpeed, 0f);

        // Apply this rotation to the rigidbody's rotation.
        //this.m_Rigidbody.MoveRotation(this.m_Rigidbody.rotation * turnRotation);
        //this.m_Rigidbody.attachedRigidbody.MoveRotation(this.m_camera.transform.rotation * turnRotation);
        if (!this.m_isOver)
            this.transform.Rotate(0f, angle * this.m_TurnSpeed, 0f);
        //this.m_camera.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
    }

    public void ControlSpeed(float speed)
    {
        this.m_speedController = speed;
    }

    public void SetOver()
    {
        this.m_isOver = true;
    }
}
