using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newword : MonoBehaviour
{
    public GameObject introduce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            introduce.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            introduce.SetActive(false);
        }
    }
}
