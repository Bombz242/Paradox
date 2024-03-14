using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Test : MonoBehaviour {


    public GameObject Door;

    public GameObject[] DOORS;

    public bool Working = false;

    //private void OnTriggerEnter (Collider other) {
        
    //}

    //public List<GameObject> obj;

    

    private void OnTriggerEnter (Collider other) {
        if (!Working) {
            GetComponent<AudioSource>().Play();
        }
    }

    public void OnTriggerStay (Collider other) {
        //print (obj.Contains(other.gameObject));
        //if (obj.Contains(other.gameObject)) {

        Working = true;
        if (DOORS.Length == 0) {
            Door.GetComponent<Door_Test>().ButtonEvent(true);
        } else {
            foreach(GameObject t in DOORS) {
                t.GetComponent<Door_Test>().ButtonEvent(true);
            }
        }

        //Door.GetComponent<Door_Test>().ButtonEvent(true);
    }




    private void OnTriggerExit (Collider other) {
        Working = false;
        if (DOORS.Length == 0) {
            Door.GetComponent<Door_Test>().ButtonEvent(false);
        } else {
            foreach (GameObject t in DOORS) {
                t.GetComponent<Door_Test>().ButtonEvent(false);
            }
        }

        //Door.GetComponent<Door_Test>().ButtonEvent(false);
    }






}
