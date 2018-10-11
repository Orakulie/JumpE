using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using System.Collections.Generic;
using UnityEngine.Networking;
public class Ziel : MonoBehaviour {

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Network").GetComponent<NetworkManagerHUD>().manager.matchName.Contains("E"))
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            GameObject.Find("Game").GetComponent<Level>().SendMessage("RpgStart");



        }
    }
}
