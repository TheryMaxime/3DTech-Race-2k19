using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectLevelScene : MonoBehaviour
{
	// when the associated button is clicked, the select level scene is launched
	// player can choose between two modes
    public void selectLevel()
    {
        SceneManager.LoadScene("selectLevel", LoadSceneMode.Single);
    }
}
