using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSport : MonoBehaviour
{
    private Rigidbody2D rb;//Define a rigid body
    private Animator anima;//Declare the Animator variable  
    public AudioSource JumpAudio, HurtAudio, JiangliAudio;//Define a jump sound, damage sound, collect item sound
    public float speed = 10f;// Define the speed
    public float jump;//Define the jump
    public Collider2D coll, Discoll;
    public LayerMask ground;
    public int Cherry, Gem;//Define cherry and diamond
    public Text CherryNum, GemNum;
    public Transform up;
    private bool isHurt;//The default value is false  
    // Start is called before the first frame update   Began to read
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame   frame-wise

    private void FixedUpdate()
    {

        if (!isHurt)
        {
            Movement();
        }
        //The move method is called every frame

        SwitchAnima();
    }
    private void Update()
    {
        NewJump();
        Paxia();
    }

    void Movement()//Create move method
    {
        float yidongfx = Input.GetAxis("Horizontal"); //If you define a value, you can only get -1<0<1 if you assign the value to it by a horizontal movement  
        float mianxiangfx = Input.GetAxisRaw("Horizontal");//If you define a number, and you assign that number to that number, you only get -1, 0, 1  


        //角色移动
        if (yidongfx != 0)//不为0
        {
            rb.velocity = new Vector2(yidongfx * speed * Time.fixedDeltaTime, rb.velocity.y);//Obtain change in velocity = change in 2D surface movement xy
            anima.SetFloat("running", Mathf.Abs(mianxiangfx));//Run animation effect
        }
        if (mianxiangfx != 0)
        {
            transform.localScale = new Vector3(mianxiangfx, 1, 1);
        }


    }
    void SwitchAnima()//Create a jump switch animation
    {
        anima.SetBool("Idle", false);

        if (rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anima.SetBool("falling", true);
        }
        if (anima.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anima.SetBool("jumping", false);
                anima.SetBool("falling", true);
            }
        }
        else if (isHurt)
        {
            anima.SetBool("hurt", true);
            anima.SetFloat("running", 0);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anima.SetBool("hurt", false);
                anima.SetBool("Idle", true);
                isHurt = false;
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anima.SetBool("falling", false);
            anima.SetBool("Idle", true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)//Collect cherry, diamond, collision trigger, trigger death jump scene
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            JiangliAudio.Play();
            Cherry += 1;
            CherryNum.text = Cherry.ToString();//Real-time display of the number of cherries collected
        }
        else if (collision.tag == "gem")
        {
            Destroy(collision.gameObject);
            JiangliAudio.Play();
            Gem += 1;
            GemNum.text = Gem.ToString();
        }
        if (collision.tag == "siwang")
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("die", 1);
        }

    }
    //destroy the enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            fulei fulei = collision.gameObject.GetComponent<fulei>();
            //qingwa qw = collision.gameObject.GetComponent<qingwa>();//Production qW entity, its class is Qingwa, using QW can call all qingwa components, access another script  
            //Destroy(collision.gameObject);//The next line does the same thing
            if (anima.GetBool("falling"))
            {
                fulei.JumpOn();//The destruction method in qingwa was called
                rb.velocity = new Vector2(rb.velocity.x, jump * Time.fixedDeltaTime);
                anima.SetBool("jumping", true);
            }
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                isHurt = true;
                HurtAudio.Play();
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                isHurt = true;
                HurtAudio.Play();
            }

        }
    }
    void Paxia()//get down
    {
        if (!Physics2D.OverlapCircle(up.position, 0.2f, ground))
        {

            if (Input.GetButton("Paxia"))
            {
                anima.SetBool("dunxia", true);
                Discoll.enabled = false;
            }
            else
            {
                anima.SetBool("dunxia", false);
                Discoll.enabled = true;
            }
        }
    }
    void Restart()//restart 
    {
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Trigger the death
        }
    }
    void die()
    {
        SceneManager.LoadScene("lose");
     
    }
    void NewJump()//Character jumping
    {
        if (Input.GetButton("Jump") && coll.IsTouchingLayers(ground))//Determine the button is pressed, fix the jump BUG
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * Time.fixedDeltaTime);
            JumpAudio.Play();//Bouncing sound
            anima.SetBool("jumping", true);
        }

    }
}
