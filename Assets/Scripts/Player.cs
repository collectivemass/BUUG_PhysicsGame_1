using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //*** Properties
    public float force;
    public Rigidbody physics;

    //*** Variables
    private bool isDragging = false;
    private Vector3 dragFrom;

    //*** Unity Messages
    private void Awake() {
        Game.instance.playerLine.SetActive(false);
    }
    private void Update() {

        if(isDragging) {
    
            //*** Get mouse position in pixels
            Vector3 vMouse = Input.mousePosition;

            //*** Move to world co-ords
            vMouse.z = Game.instance.gameCamera.transform.position.y * -1;
            vMouse = Game.instance.gameCamera.ScreenToWorldPoint(vMouse);
            vMouse.y = 0;

            //*** Get the delta
            Vector3 vDelta = vMouse - dragFrom;
            float xLength = vDelta.magnitude;
            vDelta.Normalize();

            Game.instance.playerLine.transform.localScale = new Vector3(1, 1, xLength);

            //*** Calculate angle
            float xAngle = Mathf.Atan2(vDelta.x, vDelta.z);

            Game.instance.playerLine.transform.eulerAngles = new Vector3(0, (xAngle) * Mathf.Rad2Deg, 0);
        }
        
    }
    private void OnMouseDown() {

        //*** Turn On Player Line
        Game.instance.playerLine.SetActive(true);
        Game.instance.playerLine.transform.position = transform.position;

        //*** Stop any movement
        physics.velocity = Vector3.zero;
        physics.angularVelocity = Vector3.zero;

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

            //*** Turn Off Player Line
            Game.instance.playerLine.SetActive(false);

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
            physics.AddForce(vDelta * 3, ForceMode.Impulse);
        }
    }

}
