using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour {

    public Canvas MainCanvas;

    public void quitOn()
    {
        Application.Quit();
    }

    public void restartOn()
    {
        SceneManager.LoadScene("Level1");
    }
}
