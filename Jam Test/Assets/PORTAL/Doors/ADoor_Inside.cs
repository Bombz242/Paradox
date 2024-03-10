using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADoor_Inside : MonoBehaviour {

    public ADoor_Manage Manage;

    private void OnTriggerEnter (Collider other) {
        if (other.tag != "Obj") {
            Manage.inside = true;
        }
        //Manage.inside = true;
    }

    private void OnTriggerExit (Collider other) {
        if (other.tag != "Obj") {
            Manage.inside = false;
        }
    }
}
