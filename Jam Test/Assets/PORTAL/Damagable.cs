using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damagable : MonoBehaviour {

    private void OnTriggerEnter (Collider other) {
        if (other.name == "Player") {
            
            print ("RESET WORLD");
            GAME_MANAGER.MAN.DEATH();
        }
    }

}
