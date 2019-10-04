using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;

    [SerializeField] Text countDownText;
    public Button buttonCancel;

    public List<GameObject> roadsPrefabsList;
    public List<GameObject> roadsList;

    private GameObject character;

    public static gameController instance;

    public bool gameOver = false;

    public Button backMenu;

    public GameObject obstaclePrefab;
    private int score;

    public Text scoreText;
    public Text gameOverText;

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
        score = 0;
        backMenu.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        currentTime = startingTime;
        character = GameObject.FindGameObjectWithTag("Player");

        float z = 0f;
        roadsList = new List<GameObject>();

        for(int i = 0; i < roadsPrefabsList.Count; i++)
        {
            GameObject obj = Instantiate(roadsPrefabsList[i], new Vector3(0, 0, z), Quaternion.identity) as GameObject;
            roadsList.Add(obj);
            z+=roadsList[i].GetComponentInChildren<BoxCollider>().transform.localScale.z;
            if(z!=0)
                generateObstacles(z);
        }



    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1f * Time.deltaTime;
        if (currentTime > 1f)
        {
            countDownText.text = currentTime.ToString("0");
        }
        else countDownText.text = "Go !";

        if (currentTime < -1f)
        {
            countDownText.gameObject.SetActive(false);
            buttonCancel.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            //SceneManager.LoadScene("SampleSceneAntoine", LoadSceneMode.Single);
        }

        if (character.transform.position.z > roadsList[0].transform.position.z + roadsList[0].GetComponentInChildren<BoxCollider>().transform.localScale.z)
        {
            replaceRoad();
            //generateObstacles();
        }

        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

    private void replaceRoad()
    {
        GameObject copy = roadsList[0];
        roadsList.RemoveAt(0);
        roadsList.Add(copy);
        float newPos = roadsList[roadsList.Count - 2].transform.position.z + roadsList[roadsList.Count - 2].GetComponentInChildren<BoxCollider>().transform.localScale.z;
        roadsList[roadsList.Count - 1].transform.position = new Vector3(0, 0, newPos);
        generateObstacles(newPos);
    }

    private void generateObstacles(float z)
    {
        for (int i =0; i<3; i++)
        {
            float spawnXPosition = Random.Range(-3f, 3f);
            float spawnZPosition = Random.Range(z-30f, z+30f);
            Instantiate(obstaclePrefab, new Vector3(spawnXPosition, 0.52f, spawnZPosition), Quaternion.identity);
        }
    }   

    public void scored()
    {

        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score : " + score.ToString();
    }

    public void died()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        backMenu.gameObject.SetActive(true);
    }
}
