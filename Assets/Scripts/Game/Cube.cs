using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class Cube : NetworkBehaviour
{
    public GameObject Player;
    public bool destroy;
    public GameObject Item;
	// Use this for initialization
	void Start () {
       
        Player = GameObject.FindGameObjectWithTag("Player");
        try
        {
            if (transform.position.y >= Player.transform.position.y && transform.position.x == Player.transform.position.x && transform.position.y < Player.transform.position.y + 2)
                Destroy(this);
        }catch
        { 
}
            if (transform.position == Player.transform.position)
        {
         
            Destroy(this.gameObject);
        }
    
     
	}
	
	// Update is called once per frame
	void Update () {
      //  GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(30, 40);
	}

    
    public void Fly()
    {
        Animator anim = GetComponentInChildren<Animator>();
        if (anim.GetBool("Fly") == false)
        {
            anim.SetBool("Fly", true);
        }
        else if (anim.GetBool("Fly") == true)
            anim.SetBool("Fly", false);
      
    }
    

    public void Rpg()
    {
        var cub = (GameObject)Instantiate(Item, new Vector3(transform.position.x,transform.position.y + 2), Quaternion.identity);
        NetworkServer.Spawn(cub);
    }
}
