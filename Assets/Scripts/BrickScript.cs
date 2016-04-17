using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BrickScript : MonoBehaviour {

    static int numBricks = 0;
    public int hitPoints = 1;
    public int pointValue = 1;
  
    // Use this for initialization
    void Start () {
        numBricks++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Die();
        }
       
    }
    void Die()
    {
        
        Destroy(gameObject);
        GameObject.Find("Paddle").GetComponent<PaddleScript>().AddPoint(pointValue);
        
        
        numBricks=numBricks-1;
        if (numBricks <= 0)
        {
            
            SceneManager.LoadScene("Level2");

        }
    }
}
