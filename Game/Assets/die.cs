﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    { 
            print("sale");
            gameController.instance.died();

    }


    /*public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("sale");
        gameController.instance.died();
    }*/
}