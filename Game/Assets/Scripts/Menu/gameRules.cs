using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameRules : MonoBehaviour
{
	// when the associated button is clicked, the rules scene is launched
    public void showRules()
    {
        SceneManager.LoadScene("RulesScene", LoadSceneMode.Single);
    }
}
