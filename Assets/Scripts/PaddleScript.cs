using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaddleScript : MonoBehaviour {

    float paddleSpeed = 15f;
    public GameObject ballPrefab;
    
    
    public GUISkin scoreboardSkin;
    public GUISkin livesSkin;
    int lives = 3;

    int score = 0;

    GameObject attachedBall=null;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

       
    }

    void OnGUI()
    {
        GUI.skin = scoreboardSkin;
        GUI.skin = livesSkin;
        GUI.Label(new Rect(0, 10, 300, 100), "Score: " + score);
        GUI.Label(new Rect(0, 30, 300, 100), "Lives: " + lives);
    }


    public void OnLevelWasLoaded(int level)
    {
        SpawnBall();
    }

    public void AddPoint(int v)
    {
        score = score + v ;
        

    }

    public void LoseLife()
    {
        lives--;
        
        if (lives > 0)
            SpawnBall();
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

	// Update is called once per frame
	void Update () {
        //Sağ-Sol
        transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);

        if (transform.position.x > 7.49f)
        {
            transform.position=new Vector3(7.49f, transform.position.y, transform.position.z);
        } 
        else if(transform.position.x < -7.49f){
            transform.position= new Vector3(-7.49f, transform.position.y, transform.position.z);
        }

        if (attachedBall)
        {
            Rigidbody ballRigidbody = attachedBall.GetComponent<Rigidbody>();
            ballRigidbody.position= transform.position+ new Vector3(0, .75f, 0);

            if (Input.GetButtonDown("Jump"))//Jump space'e basma anlamında input managerdan degistirebiliyoruz.
             {
            
                attachedBall.GetComponent<Rigidbody>().isKinematic=false;
                attachedBall.GetComponent<Rigidbody>().AddForce(400f  *Input.GetAxis("Horizontal"), 700f, 0);
                attachedBall = null;
            }     
        }
        
    }

    void FixedUpdate()
    {

    }

    public void SpawnBall()
    {
        attachedBall = (GameObject)Instantiate(ballPrefab, transform.position + new Vector3(0, .75f, 0),Quaternion.identity);
        
    }

    void OnCollisionEnter(Collision col)
    {
        foreach(ContactPoint contact in col.contacts)
        {
           if (contact.thisCollider == GetComponent<Collider>())
            {
                float english=contact.point.x - transform.position.x;

                contact.otherCollider.GetComponent<Rigidbody>().AddForce(400f * english, 0, 0);
               
            }
        }
    }

    

}
