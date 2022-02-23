using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class caidan : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pausemenu;
    public void playgame()//start game 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Scene jump
    }
    public void gameover()//End of the game
    {
        Application.Quit();
    }

    public void UIStart()
    {
        GameObject.Find("Canvas/mubu/UI").SetActive(true);//Gradient background, font appears after background
    }

    public void pausegame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;//Time stops, pause the game
    }
    public void resumegame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;//Time to recover and start the game
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume",value);
    }
}