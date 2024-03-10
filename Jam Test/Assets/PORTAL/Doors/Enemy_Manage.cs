using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Manage : MonoBehaviour {


    public NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public Transform Objetive;


    public GameObject Shoot;
    public Transform point;

    private void Start () {
        //agent =  GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void OnTriggerEnter (Collider other) {
        //print ("COL");

        //if (other.tag == "Player") {
        //    Objetive = other.transform;
            //agent.SetDestination (Objetive.transform.position);
        //}
    }

    private void OnTriggerStay (Collider other) {
        if (other.tag == "Player" || other.tag == "Shadow") {
            //Ejecutar raycast para saber si es posible observarlo o hay un obstaculo de por medio
            //Vector3 fwd = transform.TransformDirection(Vector3.forward);

            LayerMask l = 0;
            RaycastHit r;

            if (Physics.Linecast(transform.position, other.transform.position, out r)) {
                //print (r.transform.name);

           
                if (r.transform.tag == "Player" || r.transform.tag == "Shadow") {
                    if (Objetive == null) {
                        Objetive = other.transform;
                    }
                    //Objetive = other.transform;
                    if (Vector3.Distance (transform.position, Objetive.transform.position) < 1f) {
                        print ("RESET");
                        GAME_MANAGER.MAN.DEATH();
                    }
                    print("CAN SEE IT");
                } else {
                    //point.LookAt(transform.forward);
                    Objetive = null;
                    UpdateDestination();
                    Debug.Log("blocked");
                }
                //Debug.Log("blocked");
                //Objetive = other.transform;
           
            }

            /*
            if (Physics.Raycast(transform.position, fwd, 10f)) {
                //print("There is something in front of the object!");
                print (other.tag);
                if (other.tag == "Player" || other.tag == "Shadow") {
                    Objetive = other.transform;
                } else {
                    Objetive = null;
                    UpdateDestination();
                }
            } else {
                //Objetive = null;
                //UpdateDestination();
            }*/


            //Objetive = other.transform;
            //agent.SetDestination (Objetive.transform.position);
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.tag == "Player" && Objetive == other.transform) {
            Objetive = null;
            UpdateDestination();

            //agent.SetDestination (Objetive.transform.position);
        }
    }


    public float shootTime;

    private void Update () {
        shootTime -= Time.deltaTime;

        if (Objetive != null) {
            //point.LookAt(Objetive.GetChild(1));

            if (Shoot && shootTime < 0) {
                //Puede disparar
                shootTime = 1f;
                point.LookAt(Objetive.GetChild(1));
                Instantiate (Shoot, point.position, point.rotation);
            } 
            agent.SetDestination(Objetive.transform.position);

        } else {
            if (Vector3.Distance(transform.position, target) < 1) {
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
    }



    void UpdateDestination () {
        //point.LookAt(transform.parent.forward);
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex () {
        waypointIndex++;
        if (waypointIndex == waypoints.Length) {
            waypointIndex = 0;
        }
    }




}
