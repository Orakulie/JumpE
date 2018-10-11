using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {
    public GameObject[] Players;
    public int PlayerAuswahl;
    public float DistX;
    public float DistY;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        try
        {
            Players = GameObject.FindGameObjectsWithTag("Player");
            transform.position = new Vector3(Players[PlayerAuswahl].transform.position.x, Players[PlayerAuswahl].transform.position.y + DistY, -157);
        }
        catch
        {
            Debug.Log("FEHLER");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (PlayerAuswahl < Players.Length)
                PlayerAuswahl++;
            if (PlayerAuswahl >= Players.Length)
                PlayerAuswahl = 0;

        }
    }

    }
