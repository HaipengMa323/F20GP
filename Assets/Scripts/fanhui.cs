using UnityEngine;
using UnityEngine.SceneManagement;

public class fanhui : MonoBehaviour
{
   public GameObject Fanhui;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Fanhui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Fanhui.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Load the next scenario
        }
    }
}
