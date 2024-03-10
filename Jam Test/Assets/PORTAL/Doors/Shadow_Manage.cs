using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_Manage : MonoBehaviour {


    public bool isHolding;
    public bool isShooting;

    public Transform Recogido;
    public Transform Point;





    /*
    public void TryHold () {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //bool desync = false;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5.5f )) {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (hit.transform.tag == "Obj") {
                Recogido = hit.transform;
                Recogido.SetParent(Point);
                Recogido.position = Point.position;
                Rigidbody temp = Recogido.GetComponent<Rigidbody>();
                temp.useGravity = false;
                temp.constraints = RigidbodyConstraints.FreezeAll;
                isHolding = true;
            } else {
                //StopAllCoroutines();
                Release();
                //desync = true;
                print("DESYNC");
            }
        } else {
            //StopAllCoroutines();
            Release();
            //desync = true;
            print ("DESYNC");
        }
    }*/

    public List<GameObject> cubos;
    

    public bool Holding () {


        if (cubos.Count > 0) {
            Recogido = cubos[0].transform;
            Recogido.SetParent(Point);
            Recogido.position = Point.position;
            Rigidbody temp = Recogido.GetComponent<Rigidbody>();
            temp.useGravity = false;
            temp.constraints = RigidbodyConstraints.FreezeAll;
            isHolding = true;
        }

        return cubos.Count == 0;

        RaycastHit hit;
        bool desync = false;
        if (Physics.Raycast(transform.GetChild(0).position, transform.TransformDirection(Vector3.forward), out hit, 4f)) {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (hit.transform.tag == "Obj") {
                Recogido = hit.transform;
                Recogido.SetParent(Point);
                Recogido.position = Point.position;
                Rigidbody temp = Recogido.GetComponent<Rigidbody>();
                temp.useGravity = false;
                temp.constraints = RigidbodyConstraints.FreezeAll;
                isHolding = true;
                
            } else {
                //StopAllCoroutines();
                Release();
                desync = true;
                print("DESYNC");
            }
        } else {
            desync = true;
            Release();
            print("DESYNC");
        }
        return desync;
    }

    public void Release () {
        if (Recogido != null) {
            Point.DetachChildren();
            Rigidbody temp = Recogido.GetComponent<Rigidbody>();
            temp.useGravity = true;
            temp.constraints = RigidbodyConstraints.None;
        }
        Recogido = null;
        isHolding = false;
    }



}
