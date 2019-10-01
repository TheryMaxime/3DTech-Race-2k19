using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRoad : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
