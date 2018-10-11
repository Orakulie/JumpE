using UnityEngine;
using System.Collections;

public class Wolken : MonoBehaviour {
    public float speed;
    public float XMax = 320;
    public float XMin = -155;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
       if(transform.position.x >= XMax)
        {
            transform.position = new Vector2(XMin, transform.position.y);
        }
	}
    void FixedUpdate ()
    {
        transform.position += transform.right * speed * Time.deltaTime;

    }
}
