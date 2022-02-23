using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qingwa : fulei
{

    private Rigidbody2D rb;
    //private Animator anima;

    public Transform leftpoint, rightpoint;
    public float Speed,JumpForce;
    private bool Faceleft = true;

    private float leftx, rightx;
    private Collider2D Coll;
    public LayerMask Ground;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(rightpoint.gameObject);
        Destroy(leftpoint.gameObject);

        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        SwitchAnima();
    }

    void Movement()
    {
        if (Faceleft)
        {
            if (Coll.IsTouchingLayers(Ground))
            {
                anima.SetBool("jumping", true);
                rb.velocity = new Vector2(-Speed, JumpForce);//face←
            }
            
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
            }
        }  
        else
        {
            if (Coll.IsTouchingLayers(Ground))
            { 
                anima.SetBool("jumping", true);
                rb.velocity = new Vector2(Speed, JumpForce);//face→
            }
            
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }
            
        }

    void SwitchAnima()
    {
        if (anima.GetBool("jumping"))
        {
            if(rb.velocity.y < 0.1)
            {
                anima.SetBool("jumping", false);
                anima.SetBool("falling", true);
            }
        }
        if (Coll.IsTouchingLayers(Ground) && anima.GetBool("falling"))
        {
            anima.SetBool("falling", false);
        }
    }

    /*void Die()
    {
        Destroy(gameObject);
    }
    public void JumpOn()//创建公开jumpon方法，供palyersport使用
    {
        anima.SetTrigger("qwdie");
    }*/

}

