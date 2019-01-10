using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //*** Properties
    public float force;

    //*** Variables
    private Rigidbody physics;
    private bool isDragging = false;
    private Vector3 dragFrom;

    //*** Unity Messages
    private void Awake() {
    
        //*** Gets the rigid body component
        physics = GetComponent<Rigidbody>();
    }
    private void OnMouseDown() {

        //*** Get mouse position in pixels
        Vector3 vMouse = Input.mousePosition;

        //*** Move to world co-ords
        vMouse.z = Game.instance.gameCamera.transform.position.y * -1;
        dragFrom = Game.instance.gameCamera.ScreenToWorldPoint(vMouse);
        dragFrom.y = 0;
        Debug.Log(dragFrom);

        //*** Set Dragging
        isDragging = true;
    }
    private void OnMouseUp() {

        //*** If we are dragging
        if(isDragging) {

            //*** Stop dragging
            isDragging = false;
    
            //*** Get mouse position in pixels
            Vector3 vMouse = Input.mousePosition;

            //*** Move to world co-ords
            vMouse.z = Game.instance.gameCamera.transform.position.y * -1;
            vMouse = Game.instance.gameCamera.ScreenToWorldPoint(vMouse);
            vMouse.y = 0;

            //*** Get the delta
            Vector3 vDelta = vMouse - dragFrom;
            //float xLength = vDelta.magnitude;
            //vDelta.Normalize();

            //*** Add the force
            physics.AddForce(vDelta, ForceMode.Impulse);
        }
    }

}
