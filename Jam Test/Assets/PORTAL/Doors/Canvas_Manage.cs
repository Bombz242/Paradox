using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Manage : MonoBehaviour {

    static public Canvas_Manage Man;

    public GameObject FIN;

    public void Alert () {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Complete () {
        transform.GetChild(2).gameObject.SetActive(true);   
    }

    public void Credits () {
        transform.GetChild(3).gameObject.SetActive( !transform.GetChild(3).gameObject.activeInHierarchy);
    }

    public void CubeText(bool status) {
        transform.GetChild(4).gameObject.SetActive(status);
    }

    public void Final () {
        FIN.SetActive(true);
    }


    private void Start () {
        Man = this;
        transform.GetChild(0).gameObject.SetActive( GAME_MANAGER.MAN.onMenu );
    }

    public void Game_Unpause () {
        //transform.GetChild(0).gameObject.SetActive(GAME_MANAGER.MAN.onMenu);
        GAME_MANAGER.MAN.StartGame();
        transform.GetChild(0).gameObject.SetActive(GAME_MANAGER.MAN.onMenu);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //transform.GetChild(0).gameObject.SetActive();
        }
    }
}
