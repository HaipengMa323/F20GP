using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public GameObject pausemenu;
    public void playgame()//start game 
    {
        SceneManager.LoadScene("game1");//Scene jump
    }
    public void gameover()//End of the game
    {
        Application.Quit();
    }
}