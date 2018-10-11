using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Camera1 : MonoBehaviour {
    public bool follow;
    public GameObject Player;
    void Update () {
        transform.rotation = Quaternion.identity;
   if(follow == true)
        {
            try {
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 2);
            }catch
            {
                SceneManager.LoadScene("Menü");
            }
        }
    }
    public void Follow(GameObject Player2)
    {
        follow = true;
        Player = Player2;
    }
    public void Name(string nam)
    {
        GetComponentInChildren<Text>().text = nam;
    }
    public GameObject Get()
    {
        return Player;
    }
    //[RPC]
    //public void updateName(string name1)
    //{
    //    nametag.text = name1 + Random.Range(0,7);
    //}
}
