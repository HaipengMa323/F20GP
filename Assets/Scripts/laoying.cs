using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laoying : fulei
{

    public float Speed;
    public Transform Up, Down;
    private float upY, downY;
    //private Collider2D Coll;
    private Rigidbody2D rb;

    private bool isUp = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //Coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        upY = Up.position.y;
        downY  = Down.position.y;
        Destroy(Up.gameObject);
        Destroy(Down.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (isUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, Speed);
            if (transform.position.y > upY)
            {
                isUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -Speed);
            if (transform.position.y < downY)
            {
                isUp = true;
            }
        }
    }
}
