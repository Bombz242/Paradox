    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manage : MonoBehaviour {


    public bool isHolding;
    public bool isShooting;


    public Transform Recogido;
    public Transform Point;
    public GameObject game;

    private void Awake () {
        Instantiate(game, transform.position, transform.rotation);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Finish") {
            //print ("TERMINO");
            GAME_MANAGER.MAN.NextLevel();
        }
    }


    private void Update () {

        if (Recogido == null) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1.4f)) {
                if (hit.transform.tag == "Obj") {
                    Canvas_Manage.Man.CubeText(true);
                    if (Input.GetKeyDown(KeyCode.E)) {
                        Recogido = hit.transform;
                        Recogido.position = Point.position;

                        Recogido.SetParent(Point);
                        isHolding = true;

                        Rigidbody temp = Recogido.GetComponent<Rigidbody>();
                        //Recogido.GetComponent<BoxCollider>().enabled = false;
                        temp.useGravity = false;
                        temp.constraints = RigidbodyConstraints.FreezeAll;
                    }
                } else {
                    Canvas_Manage.Man.CubeText(false);
                }
            } else {
                Canvas_Manage.Man.CubeText(false);
            }
            /*
            if (Input.GetKeyDown(KeyCode.E)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 4f)) {
                    if (hit.transform.tag == "Obj") {
                        Recogido = hit.transform;
                        Recogido.position = Point.position;

                        Recogido.SetParent(Point);
                        isHolding = true;

                        Rigidbody temp = Recogido.GetComponent<Rigidbody>();
                        //Recogido.GetComponent<BoxCollider>().enabled = false;
                        temp.useGravity = false;
                        temp.constraints = RigidbodyConstraints.FreezeAll;
                    }
                }
            }*/
        } else {
            Canvas_Manage.Man.CubeText(false);
            if (Input.GetKeyDown(KeyCode.E)) {
                Point.DetachChildren();

                Rigidbody temp = Recogido.GetComponent<Rigidbody>();
                Recogido.GetComponent<BoxCollider>().enabled = true;
                temp.useGravity = true;
                temp.constraints = RigidbodyConstraints.None;
                Recogido = null;
                isHolding = false;

            }
        }


    }











}
