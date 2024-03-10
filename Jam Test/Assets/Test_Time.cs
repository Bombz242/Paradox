using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Time : MonoBehaviour {


    public float iteration = 0.25f;

    public float speed = 5f;
    public List<Vector3> pos;
    public bool isRecord, isReading;
    public Transform Player;




    void RecordTime () {
        pos.Add( Player.position);
    }


    void RepeatingTime () {
        StartCoroutine(Fade());
    }


    IEnumerator Fade () {

        foreach ( Vector3 temp in pos) {

            //Player.transform.position = temp;
            //yield return new WaitForSeconds(0.5f);

            Vector3 startingPos = Player.position;
            //Vector3 finalPos = transform.position + (transform.forward * 5);
            Vector3 finalPos =  temp;

            float time = iteration;
            float elapsedTime = 0;

            while (elapsedTime < time) {
                Player.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }




        }
        print ("FINAL");

        //Color c = renderer.material.color;
        //for (float alpha = 1f; alpha >= 0; alpha -= 0.1f) {
        //    c.a = alpha;
        //    renderer.material.color = c;
         //   yield return new WaitForSeconds(.1f);
        //}
    }




    private void Update () {

        Player.transform.position += new Vector3 ( Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime );


        if (Input.GetKeyDown(KeyCode.Q)) {
            isRecord = !isRecord;
            if (isRecord) {
                pos.Clear();
                InvokeRepeating("RecordTime", 0f, iteration);
            } else {
                CancelInvoke("RecordTime");
                StopCoroutine(Fade());
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            isReading = !isReading;
            if (isReading) {

                RepeatingTime();
            } else {
                CancelInvoke("RecordTime");
                StopCoroutine(Fade());
            }
        }
    }



}

















