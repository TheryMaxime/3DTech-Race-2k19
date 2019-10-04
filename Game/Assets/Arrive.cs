using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_timmer;
    private bool m_isOver;
    void Start()
    {
        this.m_timmer = 0f;
        this.m_isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.m_timmer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.m_isOver = true;
        print(this.m_timmer);
    }


}
