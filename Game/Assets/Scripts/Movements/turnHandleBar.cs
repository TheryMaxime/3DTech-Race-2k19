using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnHandleBar : MonoBehaviour
{
    Rigidbody bikeRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        bikeRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 turnRight = new Vector3(1f, 0, 0);
            bikeRigidBody.transform.position += turnRight;
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector3 turnRight = new Vector3(-1f, 0, 0);
            bikeRigidBody.transform.position += turnRight;
        }
    }
}
