using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {
    public GameObject[] Players;
    public int PlayerAuswahl;
    public float DistZ;
    public float DistY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
        try
        {
            Players = GameObject.FindGameObjectsWithTag("Player");
           transform.position = new Vector3(Players[PlayerAuswahl].transform.position.x, Players[PlayerAuswahl].transform.position.y + DistY, DistZ);
        }
        catch
        {
            Debug.Log("FEHLER");
        }
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(PlayerAuswahl < Players.Length)
            PlayerAuswahl++;
            if (PlayerAuswahl >= Players.Length)
            PlayerAuswahl = 0;

        }
        //if (Input.GetKeyDown(KeyCode.KeypadPlus)&& transform.position.z < -30)
        //{
        //    DistZ += 30;
        //    DistY -= 8;


        //}
        //if (Input.GetKeyDown(KeyCode.KeypadMinus)&&transform.position.z > -108)
        //{
        //    DistZ -= 30;
        //    DistY += 8;
        //}
        

    }
    public void Player(int players)
    {
        PlayerAuswahl = players - 1;
    }
}
