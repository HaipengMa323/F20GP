using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emue : MonoBehaviour
{
    protected Animator anim;

    protected AudioSource deathAudio;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }

    
    public void Death()
    {
        
        Destroy(gameObject);
    }
    public void JumpOn()
    {
        
        anim.SetTrigger("dath");
        deathAudio.Play();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
