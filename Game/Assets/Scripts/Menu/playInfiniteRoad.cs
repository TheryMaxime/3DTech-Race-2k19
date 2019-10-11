using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playInfiniteRoad : MonoBehaviour
{
	// when the infinite road mode button is clicked, the Infinite road scene is launched
    public void playInfiniteRoadScene()
    {
        SceneManager.LoadScene("infiniteRoadScene", LoadSceneMode.Single);
    }
}
