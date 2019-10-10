using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrive : MonoBehaviour
{
    public Text scoreText;
    public CharacterMovement characterMovement;
    public Button backToMenu;
    public AudioSource audioSource;
    public Text countDownText;

    private float m_timmer;
    private bool m_isOver;
    private bool m_isStarted;
    private float m_timmerStart;
    void Start()
    {
        this.m_timmer = 0f;
        this.m_isOver = false;
        this.backToMenu.gameObject.SetActive(false);
        this.m_isStarted = false;
        this.m_timmerStart = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        this.m_timmerStart -= 1f * Time.deltaTime;
        //Count down de départ
        if (this.m_timmerStart > 1f)
        {
            this.countDownText.text = this.m_timmerStart.ToString("0");
        }
        //On lance le jeu
        else if(!this.m_isStarted)
        {
            this.countDownText.gameObject.SetActive(false);
            this.characterMovement.EnabledMovement();
            this.m_isStarted = true;
        }

        //Le jeu est terminé
        if (!this.m_isOver && this.m_isStarted)
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
            this.audioSource.Stop();
        }
    }


}
