using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Test : MonoBehaviour {


    public GameObject Door;

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
        Door.GetComponent<Door_Test>().ButtonEvent(true);
    }




    private void OnTriggerExit (Collider other) {
        Working = false;
        Door.GetComponent<Door_Test>().ButtonEvent(false);
    }






}
