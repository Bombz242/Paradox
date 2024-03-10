using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking_System2 : MonoBehaviour {


    public List<Movimiento> Datos;


    private void Start () {
        Movimiento temp = new Movimiento();
        temp.Agregar (0,0, Time.time);
        Datos.Add( temp);


    }


    private void Update () {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        if (Datos[Datos.Count-1].Checkeo(h, v)) {
            Movimiento temp = new Movimiento();
            temp.Agregar(h, v, Time.time);
            Datos.Add(temp);
        }

        
        





    }





}



[System.Serializable]
public class Movimiento {
    public float h;
    public float v;
    public float timer;


    public void Agregar(float he, float ve, float te) {
        h = he;
        v = ve;
        timer = te;
    }

    public bool Checkeo(float he, float ve) { 
        return h != he || v != ve;

        //if (h != he || v != ve) {
            
        //}
    }


}