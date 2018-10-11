using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : NetworkBehaviour {

    public List<Items> Inventar = new List<Items>();
    private Database Data;
    // Use this for initialization
    
    public float Speed, Jump, MaxSpeed;
    public bool aufboden = true, aufwand = false, springen = false,spell = true;
    public Vector3 Pos;
    public float time = 0;
    public int muni;
    public GameObject[] players;
    public int playersanz = 1;
    public GameObject gewonnen;
    public bool first;
    public int BenötigterScore = 3;
    public string Text;
    public GameObject Block;
    public string Name,Name2;
    public bool warten;
    public GameObject NamenÜberPlayer;
    [SyncVar]
    public int Score;
    [SyncVar]
    public string NameServer;
   public bool p1, p2, p3, p4;
    public bool papa;
    public bool nan;
    public GameObject HSV;
    public AudioClip HSVClip, Normal;
    public bool fliegen;
    public bool Fly;
    public bool RpgMode;
    public GameObject Hand;
    



    [SyncVar]
    public float Dmg;
    [SyncVar]
    public float Leben;
    [SyncVar]
    public float Rüstung;


    [Command]
    public void CmdAdd()
    {
        GameObject.Find("Game").SendMessage("Add", PlayerPrefs.GetString("Name"));
        
    }
    
    public void AddName(string nam)
    {
        NameServer = nam;

    }
    [Command]
    public void CmdAddName(string nam)
    {
        NameServer = nam;

    }
   
    public void GetName(GameObject pla)
    {
      pla.SendMessage("GetN", NameServer);
        //NamenErstellung(pla, NameServer);
    }
    public void GetN(string n)
    {
        Debug.Log(n);
        Name2 = n;
        NamenErstellung(this.gameObject, NameServer);
    }

    void Start() {


        if (isLocalPlayer)
        {
            Data = GameObject.FindGameObjectWithTag("Database").GetComponent<Database>();
            GameObject.Find("Minimap").GetComponent<Camera>().enabled = true;
            GameObject.Find("Platz").GetComponent<Image>().enabled = true;
            GameObject.Find("Image1").GetComponent<Image>().enabled = true;
            Name = PlayerPrefs.GetString("Name");
           CmdAddName(Name);
       
        }
        if (!isLocalPlayer)
        {
            Name = NameServer;
            //if (isServer)
            //{
            //    CmdAddName(Name);
            //}
        }

        if (!isServer)
        {



            if (isLocalPlayer)
            {
        //    Debug.Log(NameServer);
        //        NamenErstellung(this.gameObject, NameServer);

                CmdAdd();
                if (PlayerPrefs.GetString("Farbe") == "Blau")
                {

                 
                }
                if (PlayerPrefs.GetString("Farbe") == "Gelb")
                {


                   
                }
                //for(int i = 0; i < players.Length; i++)
                //{
                //    if(players[i] != isLocalPlayer)
                //    {
                //        CmdGet(i);
                //    }
                //}
            }
            //if(!isLocalPlayer)
            //{
            //    GetName(this.gameObject);

            //    //NamenErstellung(this.gameObject, NameServer);
            //    //   CmdGetName(this.gameObject);
            //}
            
      

                //    //NamenErstellung(this.gameObject, RpcGet(this.gameObject));
                //    //RpcGet(this.gameObject);

                //}
            }
        
        if (isServer)
        {
            if (isLocalPlayer)
            {
                Debug.Log(NameServer);
                NamenErstellung(this.gameObject, NameServer);

                CmdAdd();
                if (PlayerPrefs.GetString("Farbe") == "Blau")
                {

                   
                }
                if (PlayerPrefs.GetString("Farbe") == "Gelb")
                {


                
                }
            }
            //if (!isLocalPlayer)
            //{

            //    // NamenErstellung(this.gameObject, NameServer);
            //    GetName(this.gameObject);
            //}
        }
     

    }
    

    public void NamenErstellung(GameObject PlayerG, string nameE)
    {
        //GameObject.Find("NameText").GetComponent<Text>().text = nameE;
        // GUI.Label(new Rect(10, 10, 50, 50), nameE);
        Debug.Log(PlayerG + " " + nameE);
       var text1 = Instantiate(NamenÜberPlayer);
        text1.SendMessage("Follow", PlayerG);
        text1.SendMessage("Name", nameE);
        // text1.GetComponentInChildren<Text>().text = nameE;
        
        // PlayerG.GetComponentInChildren<Text>().text = nameE;


        //RpcChangeName(PlayerG, nameE);

    }
   
    void Awake()
    {
        
       
       

    }
    
    [Command]
    public void CmdCube1(Vector3 vec)
    {
        var cube = Instantiate(Block);
        cube.transform.position = vec;
        NetworkServer.Spawn(cube);
    }


    IEnumerator Cheat()
    {
        yield return new WaitForSeconds(1);
        warten = false;
    }
    IEnumerator Cheat1()
    {
        yield return new WaitForSeconds(1);
        p1 = false;
    }
    IEnumerator Cheat2()
    {
        yield return new WaitForSeconds(1);
        p2 = false;
    }
    
   
    void Update() {

        
        if(Fly == true)
        {


            GetComponent<Rigidbody>().isKinematic = true;
        }
        if(Fly == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;

        }



        



        if(Input.GetKeyDown(KeyCode.P))
        {
            warten = true;
            StartCoroutine(Cheat());
        }
      if(warten == true)
        {
           
            if(Input.GetKeyDown(KeyCode.A))
            {
                p1 = true;
                StartCoroutine(Cheat1());
            }
        }
        if (p1 == true)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                p2 = true;
                StartCoroutine(Cheat2());
            }
        }
        if (p2 == true)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                //GetComponent<Rigidbody>().useGravity = false;
                if(papa == false)
                {
                    papa = true;
                }
                else if(papa == true)
                {
                    papa = false;
                }
                p2 = false;
                p1 = false;
                warten = false;
                if (papa == true)
                {
                    GetComponent<Rigidbody>().useGravity = false;
                    HSV.active = true;
                    GameObject.Find("Network").GetComponent<AudioSource>().clip = HSVClip;
                    GameObject.Find("Network").GetComponent<AudioSource>().Play();
                    //  aufboden = true;
                    fliegen = true;
                }
                else if (papa == false)
                {
                    HSV.active = false;
                    GameObject.Find("Network").GetComponent<AudioSource>().clip = Normal;
                    GameObject.Find("Network").GetComponent<AudioSource>().Play();
                    GetComponent<Rigidbody>().useGravity = true;
                    fliegen = false;
                }
            }
         
        }
      



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Network.Disconnect();
   
            SceneManager.LoadScene(0);
        }
        if (NameServer != "" && nan == false )
        {
            if (!isLocalPlayer)
            {

                // NamenErstellung(this.gameObject, NameServer);
                GetName(this.gameObject);
                nan = true;
            }
            if(isLocalPlayer)
            {
                if(!isServer)
                NamenErstellung(this.gameObject, NameServer);
                nan = true;
            }

        }
       // score1 = score;
        players = GameObject.FindGameObjectsWithTag("Player");
        //if (score >= 3)
        // {
        //
        //      GameObject.Find("Network").GetComponent<NetworkManagerHUD>().SendMessage("Beenden");
        //  }
        if (!isLocalPlayer)
            return;
        if (Input.GetKeyDown(KeyCode.E) && muni > 0)
        {
            //var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
          
            //cube.tag = "Wand";
            //cube.GetComponent<MeshRenderer>().material.color = Color.black;

            //cube.AddComponent<NetworkIdentity>();
         
          CmdCube1(new Vector3(transform.position.x, transform.position.y - 1));
           
            muni--;

        }
    }
    void send()
    {
        GameObject.FindGameObjectWithTag("MainCamera").SendMessage("Player", playersanz);
        first = true;
    }

  
    public string GetName()
    {
        return NameServer;
    }
    

        void FixedUpdate()
    {
       
        if(Leben <= 0)
        {
            // transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
            // Destroy(this.gameObject);
            //transform.gameObject.active = false;
            if(isServer)
            {
                transform.gameObject.active = false;
            }
            else if(isLocalPlayer)
            {
                SceneManager.LoadScene("Menü");
            }
            else if(!isLocalPlayer && !isServer)
            {
                transform.gameObject.active = false;
            }
            
        }




        if (!isLocalPlayer)
        {

            //NamenErstellung(this.gameObject, NameServer);
            //   CmdGetName(this.gameObject);

        }
        if (Score >= BenötigterScore)
        {
            Score = 0;
            gewonnen = GameObject.Find("Gewonnen");
            Text = NameServer;

            gewonnen.GetComponent<Text>().enabled = true;
            gewonnen.GetComponent<Text>().text = Text + " hat gewonnen!";

            StartCoroutine(Beenden());


        }



        if (!isLocalPlayer)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isServer)
            GameObject.Find("Network").GetComponent<NetworkManagerHUD>().Beenden();
         //   Destroy(GameObject.Find("Network"));
            
            SceneManager.LoadScene("Menü");
        }
        if (playersanz < players.Length)
        {

            //for (int i = 1; i < players.Length; i++)
            //{
            //    players[i].GetComponentInChildren<Text>().text = "Player " + (i + 1);


            //}


            //for(int i = 0; i< players.Length;i++)
            //{
            //    CmdName(players[i], players[i].GetComponent<PlayerController>().GetName());
            //    //Debug.Log(players[i].GetComponent<PlayerController>().GetName());
            //}


            //if(isServer)
            //{
            //    // CmdName(players[players.Length], players[players.Length].GetComponent<PlayerController>().GetName());
            //    // CmdName(players[players.Length], GameObject.Find("Game").GetComponent<Level>().Get(players.Length));
            //    NamenErstellung(players[players.Length - 1], players[players.Length -1].GetComponent<PlayerController>().NameServer);
            //}
            playersanz = players.Length;
            if(first == false)
            {
                send();
            }
          
        }
        RaycastHit hit;
        Vector3 mousepoz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      
        mousepoz.y = mousepoz.y - 5.5f;
        mousepoz.z = 0;
        Vector3 direction = mousepoz - transform.position;
        if (Input.GetMouseButton(0))
        {



            GetComponent<LineRenderer>().enabled = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);

            GetComponent<LineRenderer>().SetPosition(1, transform.position + direction);


        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
      
        Debug.DrawLine(transform.position, mousepoz);
        if (Physics.Raycast(transform.position, mousepoz - transform.position, out hit))
        {
        
            if (Input.GetMouseButton(0) )
            {



                 
                

                    if (hit.collider.gameObject.tag == "Player")
                {

                    hit.collider.gameObject.SendMessage("DmgTaken", Dmg - 0.5 * hit.distance);
                    // Debug.Log("Treffer");
                    Debug.Log(hit.distance);

                }

            }
          
        }    
        if (aufboden == false && aufwand == false)
        {
            GetComponent<Rigidbody>().mass = 10000000000;
        }
        if (aufboden == true)
        {
            GetComponent<Rigidbody>().mass = 1;
        }
        if(aufwand == true)
        {
            GetComponent<Rigidbody>().mass = 1;
        }
        GetComponent<Rigidbody>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody>().velocity, MaxSpeed);
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(Speed, 0, 0);    
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(-Speed, 0, 0);            
        }
        if (Input.GetKeyDown(KeyCode.Space) && aufboden == true )
        {
            //GetComponent<Rigidbody>().velocity += new Vector3(0, Jump, 0);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);
            aufboden = false;    
        }    
        if (Input.GetKeyDown(KeyCode.Space) && aufboden == false && time == 1)
        {
            //GetComponent<Rigidbody>().velocity += new Vector3(0, Jump, 0);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);
            time = 0;
            aufwand = false; 
        }   
    }
   
   public void DmgTaken(int DmgT)
    {
        if(Rüstung > 0)
        Leben -= DmgT * Rüstung;
        if (Rüstung == 0)
            Leben -= DmgT;
    }
    public void Neu()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public void Rpg()
    {
        if (!isLocalPlayer)
            return;
        muni = 0;
        RpgMode = true;
       if(Inventar.Contains(Data.Items[1]))
        {
            Dmg = Data.Items[1].Schaden;
        }else if(Inventar.Contains(Data.Items[0]))
        {
            Dmg = Data.Items[0].Schaden;
        }

        if (Inventar.Contains(Data.Items[3]))
        {
            Rüstung = Data.Items[3].Rüstung;
        }
        else if (Inventar.Contains(Data.Items[2]))
        {
            Rüstung = Data.Items[2].Rüstung;
        }

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Boden")
        {
            aufboden = true;
        }
        if (coll.gameObject.tag == "Ziel")
        {
            
            
            Score++;
            int max = GameObject.FindGameObjectsWithTag("Wand").Length;
         GameObject.Find("Game").GetComponent<Level>().SendMessage("Neustarten",max);
            //  Debug.Log(score);
       

        }
    }
    void OnCollisionStay(Collision coll)
    {

        if (coll.gameObject.tag == "Wand")
        {
            aufwand = true;
            time +=1f;
            if(time >= 1)
            {
                time = 1;
                
            }
        }
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    if(coll.gameObject.tag == "Wand")
        //    {
        //        try
        //        {

        //            coll.gameObject.SendMessage("Fly");

        //            if(Fly == true)
        //            {
        //                Fly = false;
        //            }else  if(Fly == false)
        //            {
        //                Fly = true;
        //            }
        //        }catch
        //        {
        //            Debug.Log("Kein Block!");
        //        }

        //    }
        //}

    }
    void OnCollisionLeave(Collision coll)
    {

        if (coll.gameObject.tag == "Wand")
        {
            aufwand = false;
          
            }
       

    }
    //public override void OnStartLocalPlayer()
    //{
       
    //    GetComponent<MeshRenderer>().material.color = Color.blue;
    //    GetComponentInChildren<Text>().color = Color.green;

    //}
     IEnumerator Beenden()
    {
        yield return new WaitForSeconds(2);
        if (GameObject.Find("Network").GetComponent<NetworkManagerHUD>().manager.matchName.Contains("Q"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
        }
        GameObject.Find("Network").GetComponent<NetworkManagerHUD>().SendMessage("Neustarten");
    }


    void OnGUI()
    {

        for(int i = 0; i < Inventar.Count; i++)
        {
            GUI.Label(new Rect(10, i * 20, 200, 50), Inventar[i].Name);
        }

    }
}
    
    
