using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float deathTimer = -1f;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0 && deathTimer == -1)
        {
            deathTimer += 45;

        }
        if (deathTimer > 0)
        {
            deathTimer -= 1;
            if (deathTimer == 0)
            {
                DestroyImmediate(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hurtbox"))
        {
            health -= 1;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);


            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().mass = 0;
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
