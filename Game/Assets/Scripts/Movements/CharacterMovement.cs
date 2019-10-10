using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public int m_CharacterId; //ID of the current character            
    public float m_TurnSpeed = 0.0001f; 
    public float m_speed = 0.01f;
    public Camera m_camera;
    public bool m_isDemo = true;
    public Text speedometer; 

    private CharacterController m_Rigidbody;
    private Transform m_transform;
    private float m_speedController;
    private float m_speedValue;
    private bool m_isOver;
    private bool m_isEnabled;

    void Awake()
    {
        this.m_Rigidbody = GetComponent<CharacterController>();
        this.m_transform = GetComponent<Transform>();
        this.m_isOver = false;
        this.m_isEnabled = false;
        this.m_speedController = 0f;
        this.m_speedValue = 0f;
    }

    private void Update()
    {
        if (this.m_isEnabled && !this.m_isOver)
        {
            //Du fait de l'utilisation d'un CharacterController et de la fonction Move(), on recréer un semblant de gravité
            Vector3 gravity = new Vector3(0f, 0f, 0f);
            if (!this.m_Rigidbody.isGrounded)
                gravity = new Vector3(0f, -1f, 0f);

            //Mouvement avec accélération et freinage
            if (!this.m_isDemo)
            {
                float acceleration = (this.m_speedController - 0.25f);
                //Si le joueur accélère ou fait marche arrière
                if (acceleration > 0 || this.m_speedValue < 0)
                    acceleration = acceleration / 100f;
                //Si le joueur freine
                else
                {
                    acceleration = acceleration / 35f;
                }
                this.m_speedValue += acceleration;
                if(this.m_speedValue < -0.5f)
                {
                    this.m_speedValue = -0.5f;
                }
                if(this.m_speedValue > 8f)
                {
                    this.m_speedValue = 8f;
                }
                this.speedometer.text = Mathf.Round(this.m_Rigidbody.velocity.magnitude*3.6f) + "Km/H";

                Vector3 movement = this.m_transform.forward * this.m_speedValue + gravity;
                this.m_Rigidbody.Move(movement);
            }
            //Mouvement simple
            else
            {
                Vector3 movement = this.m_transform.forward * this.m_speed * this.m_speedValue + gravity;
                this.m_Rigidbody.Move(movement);
            }
            
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Si le joueur touche un mur
        if(!this.m_isDemo && hit.transform.tag != "Road")
        {
            //Si le joueur se retrouve à l'arrêt
            if (Mathf.Round(this.m_Rigidbody.velocity.magnitude * 3.6f) == 0)
                this.m_speedValue = 0f;
            //Si le joueur touche légèrement un mur
            else if (this.m_speedValue > 0f)
                this.m_speedValue -= 0.01f;
        }
    }

    public void Move(float angle)
    {
        if (this.m_isEnabled && !this.m_isOver)
        {
            if (angle > 60)
                angle = 60;
            else if (angle < -60)
                angle = -60;
            this.transform.Rotate(0f, angle * this.m_TurnSpeed, 0f);
        }
    }

    public void ControlSpeed(float speed)
    {
        if(this.m_isDemo)
            this.m_speedValue = speed;
        else
        {
            this.m_speedController = speed;
        }
    }

    public void SetOver()
    {
        this.m_isOver = true;
    }

    public void EnabledMovement()
    {
        this.m_isEnabled = true;
    }
}
