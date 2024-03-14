using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Test : MonoBehaviour {

    public GameObject[] Buttons;
    public bool t;

    public AudioClip[] audios;

    public bool isOpen;
    public bool isLaser;
    public bool isFinal;

    public void ButtonEvent (bool result) {

        if (isFinal && !result) {
            gameObject.SetActive(false);
            Canvas_Manage.Man.Final();
            return;
        }

        if (Buttons.Length == 0) { // Solo es una puerta con 1 boton, tan solo abre 
            if (result ) {
                if (!isLaser) {
                    GetComponent<AudioSource>().clip = audios[1];
                    if (isOpen != transform.GetChild(0).gameObject.activeSelf) {
                        GetComponent<AudioSource>().Play();
                    }
                }

                transform.GetChild(0).gameObject.SetActive(false);
            } else {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        } else { // Es una puerta compuesta por multiples botones, deben verificarse q todos esten presionados para abrirla
            for (int i = 0; i < Buttons.Length; i ++) {
                t = Buttons[i].GetComponent<Button_Test>().Working;
                if (!t) {
                    //GetComponent<AudioSource>().clip = audios[0];
                    break;
                }
                if (!isLaser) {
                    GetComponent<AudioSource>().clip = audios[1];
                }
            }
            if (!isOpen && t && !isLaser    ) {
                GetComponent<AudioSource>().Play();

            }
            isOpen = t;
            //if (gameObject.activeSelf == t) {
                //print ("ASDASD");
                //GetComponent<AudioSource>().Play(); 
            //}

            transform.GetChild(0).gameObject.SetActive(!t);
        }

    }




}
