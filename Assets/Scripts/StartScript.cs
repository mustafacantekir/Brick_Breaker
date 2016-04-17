using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    public Canvas MainCanvas;

	// Use this for initialization
    
    public void quitOn()
    {
        Application.Quit();
    }

	public void loadOn()
    {
        SceneManager.LoadScene("Level1");
    }
}
