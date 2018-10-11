using UnityEngine;
using System.Collections;

public class Rnd : MonoBehaviour {
    private Database Data;
    public int Item;
	// Use this for initialization
	void Start () {
        Data = GameObject.FindGameObjectWithTag("Database").GetComponent<Database>();
        Item = Random.Range(0, Data.Items.Capacity);
        //Debug.Log(Data.Items[Random.Range(0, Data.Items.Capacity)].Name);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().Inventar.Add(Data.Items[Item]);
            Destroy(this.gameObject);
        }
    }
}
