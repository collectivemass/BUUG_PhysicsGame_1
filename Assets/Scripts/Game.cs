using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Game : MonoBehaviour {

    //*** Static
    public static Game instance;

    //*** Properties
    public GameObject playerLine;
    public Camera gameCamera;
    public List<Ball> balls;

    //*** Variables
    
    //*** Unity Methods
    private void Awake() {
    
        //*** Set Singleton
        instance = this;
    }
    
    //*** Main Methods
}
