using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDemoMode : MonoBehaviour
{
    public void playDemoModeScene()
    {
        SceneManager.LoadScene("Demo", LoadSceneMode.Single);
    }
}
