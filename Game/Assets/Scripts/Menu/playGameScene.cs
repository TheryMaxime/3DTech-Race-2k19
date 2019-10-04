using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playGameScene : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("LaunchRace", LoadSceneMode.Single);
    }
}
