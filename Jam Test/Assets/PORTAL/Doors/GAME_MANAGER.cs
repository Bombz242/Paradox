using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GAME_MANAGER : MonoBehaviour {

    public static GAME_MANAGER MAN;

    public float Counter;

    private void InstantiateController () {
        if (MAN == null) {
            MAN = this;
            DontDestroyOnLoad(this);
        } else if (this != MAN) {
            Debug.Log("Destroying extra GM");
            Destroy(this.gameObject);
        }
    }

    private void Awake () {
        this.InstantiateController();
        Cursor.visible = onMenu;
    }
    public int stage = 0;   

    public void DEATH () {
        Canvas_Manage.Man.Alert();
        Past = new List<Data>(Now);
        StopAllCoroutines();
        SceneManager.LoadScene(stage, LoadSceneMode.Single);
    }


    public Transform Player;
    public Player_Manage PlayerManager;
    public Transform BotPrefb;


    public float iteration = 0.25f;

    public Transform Bot;
    public Shadow_Manage BotManager;

    public List<Data> Past;
    public List<Data> Now;

    public bool onMenu = true;
    public bool isPlaying = false;



    //public List <Events> PastEvents;
    //public List <Events> NowEvents;

    public enum Events {
        None, Pick, Release, Shoot, Etc
    }


    public void StartGame () {
        onMenu = false;
        isPlaying = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnLevelWasLoaded (int level) {
        //Cursor.visible = onMenu;
        Start();
    }

    public void NextLevel () {
        stage++;
        Past.Clear();
        Now.Clear();
        DEATH();
    }
    //DEATH ();


    private void Update () {
        Counter += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) ) {
            DEATH();
        }

        if (Input.GetKey(KeyCode.Tab)) {
            Time.timeScale = 2.5f;
        } else {
            Time.timeScale = 1f;
        }
    }




    private void Start () {
        Counter = 0f;
        Player = GameObject.Find("Player").transform;
        PlayerManager = Player.GetComponent<Player_Manage>();

        if (!onMenu) {
            Cursor.visible = onMenu;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Past.Count > 0) {
            StartCoroutine(PlayBot());
            CancelInvoke("RecordTime");
            Now.Clear();
        }
        InvokeRepeating("RecordTime", 0f, iteration);
    }

    IEnumerator PlayBot () {
        Bot = Instantiate(BotPrefb, Past[0].pos, transform.rotation) as Transform;
        BotManager = Bot.GetComponent<Shadow_Manage>();



        //for (int i = 0; i < Past.Count; i++)
        int it = 0;
        foreach (Data data in Past) {
            //it++;


            float time = iteration, elapsedTime = 0;
            Vector3 startingPos = Bot.position, finalPos = data.pos;
            Bot.rotation = data.rot;

            while (elapsedTime < time) {
                Bot.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                //print ("Mutiples veces");
                yield return null;
            }

            if (it > 0) {

                //print(Past[it - 1].hold != data.hold);
                if (Past[it - 1].hold != data.hold) {
                    //print("Cambio");
                    if (data.hold) {
                        bool desync = BotManager.Holding();
                        if (desync) { //Desync
                            Desynced();
                            //StopAllCoroutines();
                        }
                    } else {
                        BotManager.Release();
                    }
                }
            }
            it++;
            //print ("Una sola vez cada iteration");

        }
        StopAllCoroutines();
    }

    public void Desynced () {
        //print("DESYNC");
        Canvas_Manage.Man.Alert();
        StopAllCoroutines();
    }


    void RecordTime () {
        Data temp = new Data();
        Anima ani = new Anima();

        if (Input.GetKey(KeyCode.Space)) {
            ani = Anima.Jump;
        } else if (Input.GetKey(KeyCode.W)) {
            ani = Anima.Forward;
        } else if (Input.GetKey(KeyCode.S)) {
            ani = Anima.Backward;
        }
        temp.Agregar(Player.position, Player.rotation , ani, PlayerManager.isHolding, PlayerManager.isShooting);
        Now.Add(temp);
    }








    [System.Serializable]
    public class Data {
        public Vector3 pos;
        public Anima anim;
        public bool hold;
        public bool shoot;
        public Quaternion rot;
        public Events eve;

        public void Agregar (Vector3 t1 , Quaternion q, Anima t2, bool h, bool s) {
            pos = t1;
            rot = q;
            anim = t2;
            hold = h;
            shoot = s;
        }
    }
    public enum Anima {
        Idle, Forward, Backward, Jump
    }


}
