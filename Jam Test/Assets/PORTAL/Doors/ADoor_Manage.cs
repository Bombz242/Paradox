using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADoor_Manage : MonoBehaviour {


    public bool inside = false;
    public GameObject obj;
    public Animator anim;

    public AudioClip[] clips;

    private void OnTriggerExit (Collider other) {
        if (other.tag == "Shadow" || other.tag == "Player") {
            //return;
            if (inside) {
                obj = other.gameObject;
                anim.SetTrigger("Change");
                GetComponent<AudioSource>().clip = clips[0];
                GetComponentInParent<AudioSource>().Play();
            } else {
                obj = null;
                anim.SetTrigger("Change");
            }
            anim.SetBool("Use", inside);
        }
    }


    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Shadow" || other.tag == "Player") {
            //return;
            if (inside) {
                anim.SetTrigger("Change");
                anim.SetBool("Use", false);
                GetComponent<AudioSource>().clip = clips[1];
                GetComponentInParent<AudioSource>().Play();
            }

            if (other.tag == "Shadow" && obj != null) {
                if (obj != other.gameObject) {
                    GAME_MANAGER.MAN.Desynced();
                    print("DESYNC DOOR");
                }
            }
        }


    }



}
