using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTranslation : MonoBehaviour
{
    Rigidbody cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.velocity = new Vector3(0, 0, 2);
    }
}
