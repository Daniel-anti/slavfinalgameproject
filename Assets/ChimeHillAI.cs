using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeHillAI : MonoBehaviour
{
    public float senseRange;
    public GameObject player;
    public ChimeState aiState = ChimeState.idle;
    private Rigidbody2D rb;
    private float flipTimer = 75;
    private SpriteRenderer sR;
    
    public float walkSpeed = 2f;
    public enum ChimeState 
    {
        idle,
        pursue,
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (GetComponent<EnemyHealth>().deathTimer > 0) 
        {
            return;
        }
        if (flipTimer > 0) 
        {
            flipTimer -= 1;
        }
        //update state by proximity
        if (Vector3.Distance(player.transform.position, transform.position) < senseRange)
        {
            aiState = ChimeState.pursue;
        }
        else if(aiState == ChimeState.pursue) 
        {
            aiState = ChimeState.idle;
        }


        switch (aiState) 
        {
            case ChimeState.idle:
                if (flipTimer == 0) 
                {
                    flipTimer += 75;
                    GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                    rb.velocity = rb.velocity * new Vector2(0, 1);
                }

                if (!GetComponent<SpriteRenderer>().flipX)
                {
                    rb.velocity += Vector2.right * -1 * walkSpeed * Time.deltaTime;
                }
                else 
                {
                    rb.velocity += Vector2.right * walkSpeed * Time.deltaTime;
                }


                    break;
            case ChimeState.pursue:
                float horizontalDirection = player.transform.position.x > transform.position.x ? 1f : -1f;
                rb.velocity = new Vector2(horizontalDirection * walkSpeed, rb.velocity.y);
                if (horizontalDirection < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                break;

        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponent<EnemyHealth>().deathTimer <= 0) 
        {
            collision.gameObject.GetComponent<Health>().damage();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * -10f, ForceMode2D.Impulse);
        }
    }
}
