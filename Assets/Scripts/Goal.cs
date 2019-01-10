using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    //*** Properties

    //*** Unity Messages
    private void OnTriggerEnter(Collider fancyBallPants) {

        //*** Check what collided
        Ball oBall = fancyBallPants.gameObject.GetComponent<Ball>();
        Player oPlayer = fancyBallPants.gameObject.GetComponent<Player>();

        //*** If it was the ball
        if(oBall != null) {

            //*** Remove from List
            Game.instance.balls.Remove(oBall);

            //*** DESTROY!!!!
            Destroy(oBall.gameObject);

            //*** Check for end game
            if(Game.instance.balls.Count <= 0) {
                Debug.Log("Winner winner chicken dinner!");
            }
        }

        //*** If it was the player
        else if(oPlayer != null) {
            
            //*** Kill the player
            Destroy(oPlayer.gameObject);
            
            //*** End Game
            Debug.Log("Better luck next time!");
        }
    }
}
