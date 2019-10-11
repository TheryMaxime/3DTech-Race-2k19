using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseScore : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
        	//when the character avoid an obstacle, the score is increased (see scored() function in the game controller)
            gameController.instance.scored();
            // the avoided obstacle is destroyed
            Destroy(this);
        }
    }
}
