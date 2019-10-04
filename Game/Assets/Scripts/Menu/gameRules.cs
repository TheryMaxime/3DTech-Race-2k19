using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameRules : MonoBehaviour
{
    public void showRules()
    {
        SceneManager.LoadScene("RulesScene", LoadSceneMode.Single);
    }
}
