using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseScore : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            gameController.instance.scored();
        }
    }
}
