using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag != "Road")
        {
            gameController.instance.died();
        }
    }

}
