using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Manage : MonoBehaviour {


    public NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    public Vector3 target;
    public Transform Objetive;


    //public GameObject Shoot;
    //public Transform point;

    private void Start () {
        //agent =  GetComponent<NavMeshAgent>();
        speed = agent.speed;
        UpdateDestination();
    }

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Player" || other.tag == "Shadow") {
            Objetive = other.transform;
        } //else {
         //   Objetive = null;
        //    UpdateDestination();
       // }
    }

    private void OnTriggerSty (Collider other) {
        if (other.tag == "Player" || other.tag == "Shadow") {
            //Ejecutar raycast para saber si es posible observarlo o hay un obstaculo de por medio
            //Vector3 fwd = transform.TransformDirection(Vector3.forward);

            LayerMask l = 0;
            RaycastHit r;

            Objetive = other.transform;
            return;
            if (Physics.Linecast(transform.position, other.transform.GetChild(0)    .position, out r)) {

                if (r.transform.tag == "Player" || r.transform.tag == "Shadow") {
                    //if (Objetive == null) {
                        Objetive = other.transform;
                    //}
                } else {
                    //point.LookAt(transform.forward);
                    Objetive = null;
                    UpdateDestination();
                }
           
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
        } else {
            Objetive = null;
            UpdateDestination();
        }


    }

    private void OnTriggerExit (Collider other) {
        if (other.tag == "Player" && Objetive == other.transform) {
            Objetive = null;
            UpdateDestination();
        }
        if (other.tag == "Shadow" && Objetive == other.transform) {
            Objetive = null;
            UpdateDestination();
        }
    }

    public bool canFollow = false;
    public float speed;
    public Transform point;

    //public float shootTime;

    private void Update () {
        //shootTime -= Time.deltaTime;
        
        if (Objetive != null) {

            LayerMask l = 6;
            RaycastHit r;

            Debug.DrawLine(point.position, Objetive.transform.GetChild(0).position, Color.red);

            if (Physics.Linecast(point.position, Objetive.transform.GetChild(0).position, out r, ~l)) {

                //print (r.transform.name);

                if (r.transform.tag == "Player" || r.transform.tag == "Shadow") {
                    GAME_MANAGER.MAN.BotLooking();
                    agent.SetDestination(Objetive.transform.position);
                    GetComponent<MeshRenderer>().enabled = true;
                } else {
                    GetComponent<MeshRenderer>().enabled = false;
                    UpdateDestination();
                    //agent.SetDestination(Objetive.transform.position);
                }

            }



            //if (Shoot) {

            //}
            //GAME_MANAGER.MAN.BotLooking();
            //agent.SetDestination(Objetive.transform.position);
            //point.LookAt(Objetive.GetChild(1));

            //if (Shoot && shootTime < 0) {
            //Puede disparar
            //    shootTime = 1f;
            //    point.LookAt(Objetive.GetChild(1));
            //    Instantiate (Shoot, point.position, point.rotation);
            //} 

            //if (!canFollow) {
            //    agent.speed = 0f;
            //}// else {
            //    agent.speed = 0f;
            //}
            //agent.SetDestination(Objetive.transform.position);

        } else {
            GetComponent<MeshRenderer>().enabled = false;
            agent.speed = speed;
            if (Vector3.Distance( agent.transform.position, target) < 1) {
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
