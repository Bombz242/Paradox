using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Test : MonoBehaviour {



    //public Collider Door;

    public GameObject[] Buttons;
    public bool t;

    private void OnCollisionEnter (Collision collision) {
        
    }


    public void ButtonEvent (bool result) {

        if (Buttons.Length == 0) { // Solo es una puerta con 1 boton, tan solo abre 
            if (result) {
                gameObject.SetActive(false);
            } else {
                gameObject.SetActive(true);
            }

        } else { // Es una puerta compuesta por multiples botones, deben verificarse q todos esten presionados para abrirla
            
            //bool[] t = new bool[Buttons.Length];
            
            //bool t = false;

            for (int i = 0; i < Buttons.Length; i ++) {
                t = Buttons[i].GetComponent<Button_Test>().Working;
                if (!t) {
                    break;
                }
            }
            gameObject.SetActive(!t);
        }


    }




}
