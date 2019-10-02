using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject[] roadsPrefabs;
    private GameObject[] roads;

    private GameObject character;


    public static gameController instance;

    void Awake()
    {
        if (instance == null) //singleton pattern
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        float z = 0f;
        roads = new GameObject[roadsPrefabs.Length];
        for(int i = 0; i < roadsPrefabs.Length; i++)
        {
            roads[i] = Instantiate(roadsPrefabs[i], new Vector3(0,0,z), Quaternion.identity) as GameObject;
            z += roads[i].transform.Find("cube_road").GetComponent<BoxCollider>().size.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
