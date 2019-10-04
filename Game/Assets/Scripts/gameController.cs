using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public List<GameObject> roadsPrefabsList;
    public List<GameObject> roadsList;

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
        roadsList = new List<GameObject>();

        for(int i = 0; i < roadsPrefabsList.Count; i++)
        {
            GameObject obj = Instantiate(roadsPrefabsList[i], new Vector3(0, 0, z), Quaternion.identity) as GameObject;
            roadsList.Add(obj);
            z+=roadsList[i].GetComponentInChildren<BoxCollider>().transform.localScale.z;
        }

    }

    // Update is called once per frame
    void Update()
    {
         if(character.transform.position.z > roadsList[0].transform.position.z + roadsList[0].GetComponentInChildren<BoxCollider>().transform.localScale.z)
         {
             replaceRoad();
         }
    }

    private void replaceRoad()
    {
        GameObject copy = roadsList[0];
        roadsList.RemoveAt(0);
        roadsList.Add(copy);
        float newPos = roadsList[roadsList.Count - 2].transform.position.z + roadsList[roadsList.Count - 2].GetComponentInChildren<BoxCollider>().transform.localScale.z;
        roadsList[roadsList.Count - 1].transform.position = new Vector3(0, 0, newPos);
    }
}
