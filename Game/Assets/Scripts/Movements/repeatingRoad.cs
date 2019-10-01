using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingRoad : MonoBehaviour
{

    private BoxCollider road;
    private float roadLenght;
    // Start is called before the first frame update
    void Start()
    {
        road = GetComponent<BoxCollider>();
        roadLenght = road.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -roadLenght)
        {
            repositionRoad();
        }

    }

    private void repositionRoad()
    {
        Vector3 roadOffset = new Vector3(0, 0, roadLenght * 2f);
        transform.position = (Vector3)transform.position + roadOffset;
    }
}
