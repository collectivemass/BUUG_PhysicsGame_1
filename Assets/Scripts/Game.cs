﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Game : MonoBehaviour {

    //*** Static
    public static Game instance;

    //*** Properties
    public Camera gameCamera;

    //*** Variables
    
    //*** Unity Methods
    private void Awake() {
    
        //*** Set Singleton
        instance = this;
    }
    
    //*** Main Methods
}
