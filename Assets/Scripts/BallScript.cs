using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public AudioClip[] blips;

    // Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Die()
    {
        Destroy(gameObject);
        GameObject paddleObject=GameObject.Find("Paddle");
        PaddleScript paddleScript= paddleObject.GetComponent<PaddleScript>();
        paddleScript.LoseLife();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        AudioSource.PlayClipAtPoint(blips[Random.Range(0,blips.Length)], transform.position,.5f);
    }
    
}
