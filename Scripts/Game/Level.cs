using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
public class Level : NetworkBehaviour { 
    public GameObject Cube;
    public GameObject Net;
    public int Max;
    public GameObject[] tags;
    public bool name35;
    public int spieler;
    public GameObject Canvas1;
    public int zu;
    public bool Server;
    public float MaxFloat = 0.0f;
    public Slider Slide;
    public float Muni;
    public float Score;
    public bool weiter;
    public bool QuickGame, Endless, Rpg;
    public List<string> Players = new List<string>();
    // Use this for initialization
    void Start () {
        //Debug.Log(GameObject.Find("Network").GetComponent<NetworkManagerHUD>().manager.matchName);
        if (GameObject.Find("Network").GetComponent<NetworkManagerHUD>().manager.matchName.Contains("Q"))
        {
            QuickGame = true;
        }
        if (GameObject.Find("Network").GetComponent<NetworkManagerHUD>().manager.matchName.Contains("p"))
        {
            QuickGame = true;
            Rpg = true;
        }
        if (GameObject.Find("Network").GetComponent<NetworkManagerHUD>().manager.matchName.Contains("E"))
        {
            Endless = true;
        }
        if (Endless == true)
        {
            Generieren(1200);
            Muni = 10;
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>().muni = (int)Muni;
               // GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>().BenötigterScore = (int)Score;

            }
            Debug.Log("Endless");
        }
        else if(QuickGame == true)
        {
            Generieren(Random.Range(100, 200));
            Debug.Log("Normal");
        }
        else if(Rpg == true)
        {
            Generieren(Random.Range(100, 200));
            Debug.Log("Rpg");
        }

    }
	public void Add(string name)
    {
        Players.Add(name);
       
    }
    void Awake()
    {
        
    }
    public string Get(int zahl)
    {
        return Players[zahl];
    }
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            //Debug.Log("t");
           // RNeustarten();
        }
        if (Input.GetKeyDown(KeyCode.R) && QuickGame == false && Endless ==  false)
        {

            Generieren(0);
        }
        //tags = GameObject.FindGameObjectsWithTag("PlayerTag");
        //Net.GetComponent<NetworkManager>().StartMatchMaker();
        //if(name35 == false)
        //{
        //   for(int i = 0; i < tags.Length; i++ )
        //    {
        //        tags[i].GetComponent<Text>().text = "Player" + Random.Range(1, 7);
        //    }
        //    name35 = true;
        //}
        //if (spieler != tags.Length)
        //{
        //    RpcName(zu);
        //    name35 = false;
        //    spieler = tags.Length;
        //}
    }

    void OnGUI()
    {
        GameObject.Find("Network").GetComponent<NetworkManagerHUD>().enabled = false;

        if (Server == true && QuickGame  == false && Endless == false)
        {
            
            //Blöcke Anzahl
            MaxFloat = GUI.HorizontalSlider(new Rect(40, 30, 150, 30),MaxFloat, 0, 750.0F);
            GUI.Box(new Rect(10, 25f, 30 , 25), ""+Max);
            GUI.Label(new Rect(200, 22.5f, 250, 20), "Anzahl an Blöcken");
            Max = (int)MaxFloat;
      


            //Munition der Spieler
            Muni = GUI.HorizontalSlider(new Rect(40, 60, 150, 30), Muni, 0.0F, 20.0F);
            GUI.Box(new Rect(10, 55f, 30, 25), "" + (int)Muni);
            GUI.Label(new Rect(200, 52.5f, 250, 20), "Anzahl an Munition");

            //Benötigter Score
            Score = GUI.HorizontalSlider(new Rect(40, 90, 150, 30),Score,1.0F, 20.0F);
            GUI.Box(new Rect(10, 85f, 30, 25), "" + (int)Score);
            GUI.Label(new Rect(200, 82.5f, 250, 20), "Benötigter Score");



        }
       
        }
    public override void OnStartServer()
    {

        //zu = Random.Range(1, 7);
        //spieler = 1;
        
        if (isServer)
            Server = true;
      

    }
    //IEnumerator Zeit()
    //{
    //    yield return new WaitForSeconds(1);
    //        spieler = tags.Length;
    //}
    //[ClientRpc]
    //public void RpcName(int Random)
    //{
    //    for (int i = 1; i < tags.Length; i++)
    //    {
    //        tags[i].GetComponent<Text>().text = "Player" + (i + 1);
    //    }
    //}
    public void Neustarten(int maxvalue)
    {
        if (Rpg == false)
        {
            Generieren(maxvalue);
            MaxFloat = GameObject.FindGameObjectsWithTag("Wand").Length;
        }
    }
  public void RpgStart()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wand").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Wand")[i]);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Item").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Item")[i]);
        }
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Player")[i].SendMessage("Rpg");
        }
    }
    public void Generieren(int maxvalue)
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
         //   GameObject.FindGameObjectsWithTag("Player")[i].transform.position = new Vector3(Random.Range(-5, 5), 0);
            GameObject.FindGameObjectsWithTag("Player")[i].SendMessage("Neu");
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wand").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Wand")[i]);
        }
       
           
            StartCoroutine(Pause1(maxvalue));
         //   Ab:
        
            //if(weiter == false)
            //{
            //    goto Ab;
            //}
        
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>().muni = (int)Muni;
            GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<PlayerController>().BenötigterScore = (int)Score;

        }

    }
    IEnumerator Pause1(int maxvalue)
    {
        if(maxvalue == 0)
        {
            for (int i = Max; i > 0; i--)
            {
                yield return new WaitForSeconds(0.01f);
                if (Endless == true)
                {
                    var cub = (GameObject)Instantiate(Cube, new Vector3(Random.Range(-42.5f, 42.5f), Random.Range(-3.9f,1000)), Cube.transform.rotation);
                    NetworkServer.Spawn(cub);
                }
                else if(Endless == false)
                { 
                    var cub = (GameObject)Instantiate(Cube, new Vector3(Random.Range(-42.5f, 42.5f), Random.Range(-3.9f, 62)), Cube.transform.rotation);
                    if(Rpg == true)
                    cub.SendMessage("Rpg");
                    NetworkServer.Spawn(cub);
                }
               
                MaxFloat = GameObject.FindGameObjectsWithTag("Wand").Length;
            }
        }
        if(maxvalue > 0)
        {
            for (int i =maxvalue; i > 0; i--)
            {
                yield return new WaitForSeconds(0.01f);
                if (Endless == true)
                {
                    var cub = (GameObject)Instantiate(Cube, new Vector3(Random.Range(-42.5f, 42.5f), Random.Range(-3.9f, 1000)), Cube.transform.rotation);
                    NetworkServer.Spawn(cub);
                }
                else if (Endless == false)
                {
                    var cub = (GameObject)Instantiate(Cube, new Vector3(Random.Range(-42.5f, 42.5f), Random.Range(-3.9f, 62)), Cube.transform.rotation);
                    if (Rpg == true && Random.Range(0,6) == 1)
                        cub.SendMessage("Rpg");
                    NetworkServer.Spawn(cub);
                }
             
                MaxFloat = GameObject.FindGameObjectsWithTag("Wand").Length;
            }
        }
       
    }
    public int GetMax()
    {
        return Max;
    }

    }
