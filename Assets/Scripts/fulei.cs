using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fulei : MonoBehaviour
{

    protected AudioSource dieAudio;     
    protected Animator anima;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anima = GetComponent<Animator>();
        dieAudio = GetComponent<AudioSource>();
    }

    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
    public void JumpOn()//Create a public Jumpon method for palyerSport to use  
    {
        anima.SetTrigger("gwdie");
        dieAudio.Play();
    }

}
