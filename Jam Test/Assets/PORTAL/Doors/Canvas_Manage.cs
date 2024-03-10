using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Manage : MonoBehaviour {

    static public Canvas_Manage Man;


    public void Alert () {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void Start () {
        Man = this;
        transform.GetChild(0).gameObject.SetActive( GAME_MANAGER.MAN.onMenu );
    }

    public void Game_Unpause () {
        //transform.GetChild(0).gameObject.SetActive(GAME_MANAGER.MAN.onMenu);
        GAME_MANAGER.MAN.StartGame();
        transform.GetChild(0).gameObject.SetActive(GAME_MANAGER.MAN.onMenu);
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //transform.GetChild(0).gameObject.SetActive();
        }
    }
}
