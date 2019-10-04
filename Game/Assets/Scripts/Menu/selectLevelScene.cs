using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectLevelScene : MonoBehaviour
{
    public void selectLevel()
    {
        SceneManager.LoadScene("selectLevel", LoadSceneMode.Single);
    }
}
