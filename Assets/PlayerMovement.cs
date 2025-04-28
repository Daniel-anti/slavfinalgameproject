using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum pS 
    {
        rI, //right idle
        lI, // left 
        rR,
        lR,
        rJ,
        lJ,
    }
    public pS playerState;
    private Rigidbody2D rb;
    public float maxSpeed = 5f;
    public float acc = 2f;
    public float jumpForce = 5f;
    public bool isGrounded;

    public Transform rightSlash;
    public Transform leftSlash;


    public AudioSource jump;
    public AudioSource slash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        playerState = pS.rI;
        rightSlash = transform.Find("SlashRight");
        leftSlash = transform.Find("SlashLeft");

        rightSlash.gameObject.SetActive(false);
        leftSlash.gameObject.SetActive(false);

        jump = transform.Find("AudioSources/Jump").gameObject.GetComponent<AudioSource>();
        slash = transform.Find("AudioSources/Slash").gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        //You know I'm hacking this together quickly when this is the first fucking line I write.
        float h = Input.GetAxisRaw("Horizontal");

        

        if (Mathf.Abs(rb.velocity.x) < maxSpeed) 
        {
            rb.velocity += new Vector2(2f * h,0);
        
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)  
        {
            jump.PlayOneShot(jump.clip);
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        
        
        if (Mathf.Abs(rb.velocity.x) > 0.1f) 
        {
            if (rb.velocity.x > 0)
            {
                playerState = pS.rR;
            }
            else 
            {
                playerState = pS.lR;
            }
        }
        //If is idle
        if (Mathf.Abs(rb.velocity.x) <= 0.1f)
        {
            switch (playerState) 
            {
                case pS.rR:
                    playerState = pS.rI;
                    break;
                case pS.lR:
                    playerState = pS.lI;
                    break;
                case pS.rJ:
                    playerState = pS.rI;
                    break;
                case pS.lJ:
                    playerState = pS.lI;
                    break;
            }
        }
        //If is in the air (should overwrite the above)
        if (Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            if (rb.velocity.x >= 0)
            {
                playerState = pS.rJ;
            }
            else
            {
                playerState = pS.lJ;
            }
        }

        if (rb.velocity.y < -0.1f)
        {
            rb.gravityScale = 3;
        }
        else 
        {
            rb.gravityScale = 1;
        }


        if (Input.GetKeyDown(KeyCode.K)) 
        {
            slash.PlayOneShot(slash.clip);
            switch (playerState) 
            {
                case pS.rR:
                    rightSlash.gameObject.SetActive(true);
                    break;
                case pS.lR:
                    leftSlash.gameObject.SetActive(true);
                    break;
                case pS.rJ:
                    rightSlash.gameObject.SetActive(true);
                    break;
                case pS.lJ:
                    leftSlash.gameObject.SetActive(true);
                    break;
            }
        }
        



    }
}
