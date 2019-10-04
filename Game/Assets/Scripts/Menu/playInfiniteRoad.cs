using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playInfiniteRoad : MonoBehaviour
{
    public void playInfiniteRoadScene()
    {
        SceneManager.LoadScene("infiniteRoadScene", LoadSceneMode.Single);
    }
}
