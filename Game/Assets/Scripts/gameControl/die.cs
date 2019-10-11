using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
	//this function looks if the character enter on collision with a collider (the obstacles here)
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
    	//avoid the road collision
        if(hit.transform.tag != "Road")
        {
        	//launch the die script associated to the current scene
            gameController.instance.died();
        }
    }

}
