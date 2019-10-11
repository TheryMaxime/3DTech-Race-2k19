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

    public AudioSource audioSource;
    public AudioClip audioDie;


    void Awake()
    {

        //singleton pattern
        if (instance == null) 
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

        // These game objects have to be activated after other actions
        backMenu.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

        currentTime = startingTime;

        //character tagged  "player"
        character = GameObject.FindGameObjectWithTag("Player");

        float z = 0f;
        roadsList = new List<GameObject>();

        // instantiate number of road prefab choosed by the player (create the illusion of depth)
        // all prefabs are added to the list
        for(int i = 0; i < roadsPrefabsList.Count; i++)
        {
            GameObject obj = Instantiate(roadsPrefabsList[i], new Vector3(0, 0, z), Quaternion.identity) as GameObject;
            roadsList.Add(obj);
            z+=roadsList[i].GetComponentInChildren<BoxCollider>().transform.localScale.z;
            if(z!=0)
                // obstacles are generated for each road instantiated
                generateObstacles(z);
        }



    }

    // Update is called once per frame
    void Update()
    {
        // all conditions below are for the count down printing (count down > "Go!", enable/disable Buttons, etc)
        currentTime -= 1f * Time.deltaTime;
        if (currentTime > 1f)
        {
            countDownText.text = currentTime.ToString("0");
        }
        else
        {
            countDownText.text = "Go !";
            character.GetComponent<CharacterMovement>().EnabledMovement();
        }

        if (currentTime < -1f)
        {
            countDownText.gameObject.SetActive(false);
            buttonCancel.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }

        // this condition get the character position and compare it to the road position in order to add the first road of the list at the end of the list
        // the GetComponentInChildren<BoxCollider>() is used to get the cube road box collider which is child of the road prefab
        if (character.transform.position.z > roadsList[0].transform.position.z + roadsList[0].GetComponentInChildren<BoxCollider>().transform.localScale.z)
        {
            replaceRoad();
        }

        // when the game is over, user just have to click left to go back to the main menu
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

    private void replaceRoad()
    {
        // create a copy of the first element of the list (first road prefab)
        GameObject copy = roadsList[0];
        // remove the first element of the list (first road prefab)
        roadsList.RemoveAt(0);
        // add the copied element (first road prefab) to the list...
        roadsList.Add(copy);
        // and set the new position with an offset calculated from the last-1 road of the list (for place roads end to end)
        float newPos = roadsList[roadsList.Count - 2].transform.position.z + roadsList[roadsList.Count - 2].GetComponentInChildren<BoxCollider>().transform.localScale.z;
        roadsList[roadsList.Count - 1].transform.position = new Vector3(0, 0, newPos);
        //generate new random obstacles
        generateObstacles(newPos);
    }

    private void generateObstacles(float z)
    {
        // generate 3 obstacles on one road prefab -> can be modified for the difficulty of the game.
        for (int i =0; i<3; i++)
        {
            // Random X and Z position on the road
            float spawnXPosition = Random.Range(-3f, 3f);
            float spawnZPosition = Random.Range(z-30f, z+30f);
            //instantiation of the obstacles with fixed Y position 
            Instantiate(obstaclePrefab, new Vector3(spawnXPosition, 0.52f, spawnZPosition), Quaternion.identity);
        }
    }   

    public void scored()
    {
        // when scored is called, the score increase by 1 and the score text changes.
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score : " + score.ToString();
    }

    public void died()
    {
        // if the character die (when it enter in collision with obstacle) the text "game over" is enable
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        // same as game over text, the button to go back to menu is enable and the player can use it to replay or smthing
        backMenu.gameObject.SetActive(true);
        //character gameobject set to over (it is dead)
        character.GetComponent<CharacterMovement>().SetOver();

        // Stop playing audiosource and play the die audio source
        this.audioSource.Stop();
        this.audioSource.PlayOneShot(this.audioDie);
    }

}
