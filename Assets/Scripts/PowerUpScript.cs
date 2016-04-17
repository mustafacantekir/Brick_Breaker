using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter(Collision col)
    {
        
        Destroy(gameObject);
    }
    public void changeGravity()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
