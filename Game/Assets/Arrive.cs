using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrive : MonoBehaviour
{
    public Text scoreText;
    public CharacterMovement characterMovement;
    public Button backToMenu;
    // Start is called before the first frame update
    private float m_timmer;
    private bool m_isOver;
    void Start()
    {
        this.m_timmer = 0f;
        this.m_isOver = false;
        this.backToMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.m_isOver)
        {
            this.m_timmer += Time.deltaTime;
            float minutes = Mathf.Floor(this.m_timmer / 60);
            float seconds = this.m_timmer % 60;
            scoreText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
            

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            this.m_isOver = true;
            this.characterMovement.SetOver();
            this.backToMenu.gameObject.SetActive(true);
        }
        //print(this.m_timmer);
    }


}
