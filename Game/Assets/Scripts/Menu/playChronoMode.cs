using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playChronoMode : MonoBehaviour
{
    public void playChronoModeScene()
    {
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);
    }
}
