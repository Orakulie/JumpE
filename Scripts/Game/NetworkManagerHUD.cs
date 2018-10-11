#if ENABLE_UNET
using UnityEngine.SceneManagement;
namespace UnityEngine.Networking
{
    [AddComponentMenu("Network/NetworkManagerHUD")]
    [RequireComponent(typeof(NetworkManager))]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
   
    public class NetworkManagerHUD : MonoBehaviour
    {
        public Animation anim;
        bool priv;
        bool butt;
        bool quick;
        bool butt2,butt3;
        bool wieder;
        bool beenden;
        public GUIStyle font;
        public NetworkManager manager;
        [SerializeField]
        public bool showGUI = true;
        [SerializeField]
        public int offsetX;
        [SerializeField]
        public int offsetY;
        public bool RPG;
        // Runtime variable
        bool showServer = false;
        public int RandomName;
        void Start()
        {

        }
       
        public void Neustarten()
        {
        
            manager.ServerChangeScene("1");

            manager.StopHost();
            SceneManager.LoadScene(0);
        }
        public void RNeustarten()
        {

          //  manager.ServerChangeScene("1");
            manager.ServerChangeScene("2");
           
        }
        public void Beenden()
        {
            manager.StopHost();
            SceneManager.LoadScene(0);
        }
        void Awake()
        {
            manager = GetComponent<NetworkManager>();
            RandomName = Random.Range(1, 100);
        }

        void Update()
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
            {
                Debug.Log("t");
                RNeustarten();
            }
            {
                Debug.Log("tot");
            }
            if (!showGUI)
                return;
            manager.StartMatchMaker();
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    Application.LoadLevel("Menü");

            //}

            if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    manager.StartServer();
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    manager.StartHost();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    manager.StartClient();
                }
            }
            if (NetworkServer.active && NetworkClient.active)
            {
                //if (Input.GetKeyDown(KeyCode.Escape))
                //{
                //    SceneManager.LoadScene(0);
                //}
            }
        }

        void OnGUI()
        {
            if(beenden == true)
            {
                if (anim["Camera"].time == 0.0f)
                {
                    SceneManager.LoadScene(0);
                    beenden = false;
                }
            }
            if (!showGUI)
                return;

            int xpos = 10 + offsetX;
            int ypos = 40 + offsetY;
            int spacing = 24;

            if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
            {
                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Host(H)"))
                {
                    manager.StartHost();
                }
                ypos += spacing;

                if (GUI.Button(new Rect(xpos, ypos, 105, 20), "LAN Client(C)"))
                {
                    manager.StartClient();
                }
                manager.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 95, 20), manager.networkAddress);
                ypos += spacing;

                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Server Only(S)"))
                {
                    manager.StartServer();
                }
                ypos += spacing;
            }
            else
            {
                if (NetworkServer.active)
                {
                    GUI.Label(new Rect(xpos, ypos - 8, 300, 20), "Raum name = " + manager.matchName);
                    ypos += spacing;
                }
                if (NetworkClient.active)
                {
                    //GUI.Label(new Rect(xpos, ypos, 300, 20), "Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
                    //ypos += spacing;
                }
            }

            

            if (NetworkServer.active || NetworkClient.active)
            {
                //if (GUI.Button(new Rect(xpos, ypos + 100, 200, 20), "Back (Esc)",font))
                //{
                //    //  Destroy(this);
                //    // manager.StopMatchMaker();
                //    // Network.Disconnect();
                //    ////     manager.StopMatchMaker();
                //    //showGUI = false;
                    
                //    manager.StopClient();
                //    SceneManager.LoadScene(0);

                //}
                //ypos += spacing;
            }

            if (!NetworkServer.active && !NetworkClient.active)
            {
                
                ypos += 10;

                if (manager.matchMaker == null)
                {
                    if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Enable Match Maker (M)"))
                    {
                        manager.StartMatchMaker();
                    }
                    ypos += spacing;
                }
                else
                {
                    if (manager.matchInfo == null)
                    {
                        zur:
                        if (manager.matches == null)
                        {
                            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Join match",font))
                            {


                                manager.matchMaker.ListMatches(0, 20, "", true, 0, 0, manager.OnMatchList);
                                butt3 = true;
                            }
                            ypos += 10;

                        }
                        else
                        {

                            GUI.Label(new Rect(xpos, ypos, 200, 20), "Available Rooms:",font);
                            ypos += spacing;
                            foreach (var match in manager.matches)
                            {
                                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "" + match.name,font))
                                {
                                    manager.matchName = match.name;
                                    manager.matchSize = (uint)match.currentSize;
                                    manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
                                }
                                ypos += spacing += 10;
                            }
                            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back",font))
                            {
                                butt3 = false;
                                manager.matches = null;
                                goto zur;

                            }
                        }
                    }
                           
                  
                          
                        
                    
                    ypos += spacing;
                    if (butt3 == false)
                    {
                        if (butt2 == false)
                        {
                            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create quick match",font))
                            {


                                butt = true;
                                quick = true;
                                priv = false;
                                butt2 = true;
                                butt = false;
                                goto Quick;

                            }
                            ypos += spacing;
                        }
                        if (RPG == false)
                        {
                            if (butt == false)
                            {
                                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create private match", font))
                                {
                                    butt = true;
                                    priv = true;
                                    butt2 = false;

                                }
                            }
                        }
                        if (priv == false)
                            ypos += spacing;
                        ypos += 10;
                        if (RPG == false)
                        {
                            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Endless", font))
                            {
                                if (manager.matchInfo == null)
                                {

                                    if (manager.matches == null)
                                    {
                                        manager.matchName = "ERoom  " + Random.Range(1, 1000);
                                        manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);
                                    }
                                }
                            }
                            ypos += 50;
                        }
                        //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                        //{
                           
                        //    SceneManager.LoadScene("Menü");
                        //}

                        if (priv == true)
                            ypos += spacing;
                        if (manager.matchInfo == null && priv == true)
                        {
                            // zur:
                            if (manager.matches == null)
                            {



                                ypos += 20;




                                GUI.Label(new Rect(xpos, ypos, 100, 20), "Room name:",font);
                                manager.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20), "Room no. " + Random.Range(1, 1000),font);
                                // manager.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20),manager.matchName);

                                //ypos += spacing;

                                //ypos += 10;

                                ////if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Search Room"))
                                ////{
                                ////    manager.matchMaker.ListMatches(0, 20, "", true, 0, 0, manager.OnMatchList);
                                ////}
                                //ypos += spacing + 10;
                                //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                                //{
                                //    SceneManager.LoadScene("Menü");
                                //}
                                //ypos += spacing;
                                ypos += spacing;
                            }
                            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create Room",font))
                            {
                                manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);


                            }
                            //else
                            //{

                            //    GUI.Label(new Rect(xpos, ypos, 200, 20), "Available Rooms:");
                            //    ypos += spacing;
                            //    foreach (var match in manager.matches)
                            //    {
                            //        if (GUI.Button(new Rect(xpos, ypos, 200, 20), "" + match.name))
                            //        {
                            //            manager.matchName = match.name;
                            //            manager.matchSize = (uint)match.currentSize;
                            //            manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
                            //        }
                            //        ypos += spacing += 10;
                            //    }

                            //    if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                            //    {
                            //        manager.matches = null;
                            //        goto zur;
                            //    }
                            //}
                            goto Private;
                        }
                        Quick:

                        //if(butt == true)
                        //{
                        //butt = false;
                        //}

                        if (manager.matchInfo == null && quick == true && RPG == false)
                        {
                            //   zur:
                            if (manager.matches == null)
                            {





                                ypos += spacing + 20;

                                GUI.Label(new Rect(xpos, ypos, 100, 20), "Room name:",font);
                                manager.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20), "QRoom no. " + Random.Range(1, 1000),font);
                                // manager.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20),manager.matchName);
                                ypos += spacing;
                                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create Room",font))
                                {
                                    manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);


                                }
                                ypos += spacing;

                                ypos += 10;

                                //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Search Room"))
                                //{
                                //    manager.matchMaker.ListMatches(0, 20, "", true, 0, 0, manager.OnMatchList);
                                //}
                                ypos += spacing + 10;
                                //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                                //{
                                //    SceneManager.LoadScene("Menü");
                                //}
                                ypos += spacing;
                            }
                            //else
                            //{
                            //    ypos += spacing;

                            //    GUI.Label(new Rect(xpos, ypos, 200, 20), "Available Rooms:");
                            //    ypos += spacing;

                            //    foreach (var match in manager.matches)
                            //    {
                            //        if (GUI.Button(new Rect(xpos, ypos, 200, 20), "" + match.name))
                            //        {
                            //            manager.matchName = match.name;
                            //            manager.matchSize = (uint)match.currentSize;
                            //            manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
                            //        }
                            //        ypos += spacing += 10;
                            //    }

                            //    if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                            //    {
                            //        manager.matches = null;
                            //        goto zur;
                            //    }
                            //}

                        }
                        if (manager.matchInfo == null && quick == true && RPG == true)
                        {
                            //   zur:
                            if (manager.matches == null)
                            {





                                ypos += spacing + 20;

                                GUI.Label(new Rect(xpos, ypos, 100, 20), "Room name:", font);
                                manager.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20), "RpgRoom no. " + Random.Range(1, 1000), font);
                                // manager.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20),manager.matchName);
                                ypos += spacing;
                                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create Room", font))
                                {
                                    manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);


                                }
                                ypos += spacing;

                                ypos += 10;

                                //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Search Room"))
                                //{
                                //    manager.matchMaker.ListMatches(0, 20, "", true, 0, 0, manager.OnMatchList);
                                //}
                                ypos += spacing + 10;
                                //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                                //{
                                //    SceneManager.LoadScene("Menü");
                                //}
                                ypos += spacing;
                            }
                            //else
                            //{
                            //    ypos += spacing;

                            //    GUI.Label(new Rect(xpos, ypos, 200, 20), "Available Rooms:");
                            //    ypos += spacing;

                            //    foreach (var match in manager.matches)
                            //    {
                            //        if (GUI.Button(new Rect(xpos, ypos, 200, 20), "" + match.name))
                            //        {
                            //            manager.matchName = match.name;
                            //            manager.matchSize = (uint)match.currentSize;
                            //            manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
                            //        }
                            //        ypos += spacing += 10;
                            //    }

                            //    if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back"))
                            //    {
                            //        manager.matches = null;
                            //        goto zur;
                            //    }
                            //}

                        }
                        Private:

                        ypos += 15;
                        if(priv == true)
                        {
                            ypos += 92;
                        }
                        if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Back", font))
                        {
                            if (beenden == false && anim["Camera"].time == 0)
                            {
                                anim["Camera"].speed = -1.0f;
                                anim["Camera"].time = anim["Camera"].length;
                                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>().Play();
                                //    Debug.Log(anim["Camera"].time);
                                beenden = true;
                            }
                            }




                    }






                            
                    //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Change MM server"))
                    //{
                    //	showServer = !showServer;
                    //}
                    if (showServer)
                    {
                        ypos += spacing;
                        if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Local"))
                        {
                            manager.SetMatchHost("localhost", 1337, false);
                            showServer = false;
                        }
                        ypos += spacing;
                        if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Internet"))
                        {
                            manager.SetMatchHost("mm.unet.unity3d.com", 443, true);
                            showServer = false;
                        }
                        ypos += spacing;
                        if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Staging"))
                        {
                            manager.SetMatchHost("staging-mm.unet.unity3d.com", 443, true);
                            showServer = false;
                        }
                    }

                    ypos += spacing;

                    //GUI.Label(new Rect(xpos, ypos, 300, 20), "MM Uri: " + manager.matchMaker.baseUri);
                    ypos += spacing;

                    //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Disable Match Maker"))
                    //{
                    //	manager.StopMatchMaker();
                    //}
                    ypos += spacing;
                }
            }
        }
    }

};
#endif //ENABLE_UNET

