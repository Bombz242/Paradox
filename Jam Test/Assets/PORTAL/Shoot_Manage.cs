using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Manage : MonoBehaviour {


    public float speed = 2.5f;

    private void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            GAME_MANAGER.MAN.DEATH();
        }
    }

}
