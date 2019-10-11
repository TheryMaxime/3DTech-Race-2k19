using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playChronoMode : MonoBehaviour
{
	// when the chrono mode button is clicked, the Chrono scene is launched
    public void playChronoModeScene()
    {
        SceneManager.LoadScene("Chrono", LoadSceneMode.Single);
    }
}
