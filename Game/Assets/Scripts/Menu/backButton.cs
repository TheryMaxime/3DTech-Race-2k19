using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
   // This function loads the Menu Scene and is linked to the "Menu" button in the corresponding scene
   public void backToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
