using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_Detect : MonoBehaviour {

    public Shadow_Manage shadow;

    private void OnTriggerEnter (Collider other) {
        if (other.transform.tag == "Obj") {
            shadow.cubos.Add(other.gameObject);
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.transform.tag == "Obj") {
            shadow.cubos.Remove(other.gameObject);
        }
    }
}
