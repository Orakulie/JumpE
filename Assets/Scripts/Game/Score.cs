using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public GameObject[] Players;
    public Vector3 Y,Y2;

    public int Höchster,Höchster2;
    public Text ScoreText;
    public Text ScoreText2;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        


        Players = GameObject.FindGameObjectsWithTag("Player");
   
        for (int i = 0; i < Players.Length; i ++)
        {
            if (Players[i].transform.position.y > Y.y)
            {
      
                Höchster = i;

            }
            
        
            }
        try
        {
            Y.y = Players[Höchster].transform.position.y;

        }catch
        {

        }
        try
        {

            for(int i = 0; i < GameObject.FindGameObjectsWithTag("Cab").Length;i++)
            {
                if(Players[Höchster] == GameObject.FindGameObjectsWithTag("Cab")[i].GetComponent<Camera1>().Get())
                {
                    ScoreText.text = "1. " + GameObject.FindGameObjectsWithTag("Cab")[i].gameObject.GetComponentInChildren<Text>().text;
                }
            }

          
            
        }
        catch
        {

        }


    }

   
    
}
