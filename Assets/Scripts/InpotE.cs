using UnityEngine;

public class InpotE : MonoBehaviour
{

    public GameObject inpotE;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inpotE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inpotE.SetActive(false);
        }
    }
}
