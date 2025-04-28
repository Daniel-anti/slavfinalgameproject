using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 3f;
    public float burnTimer = 0f;
    private SpriteRenderer sR;
    public float invinceTimer = 0f;
    private float frame;
    public bool inSun = false;
    public GameObject burnSprite;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        burnSprite.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        frame = (frame + 1) % 10;
        if (invinceTimer > 0) 
        {
            invinceTimer -= 1;
            switch (frame > 4)
            {
                case false:
                    sR.enabled = false;
                    break;
                case true:
                    sR.enabled = true;
                    break;
            }
            if (invinceTimer == 0) 
            {
                sR.enabled = true;
            }

        }
        if (burnTimer > 0)
        {
            burnSprite.SetActive(true);
            burnTimer -= 1;
            if (burnTimer == 0)
            {
                damage();
                if (inSun)
                {
                    isBurning();
                }
                else {
                    burnSprite.SetActive(false);
                }
            }
        }
        
    }


    public void isBurning() 
    {
        burnTimer += 50;
    }

    public void notBurningAnymore() 
    {
        burnTimer = 0;
        burnSprite.SetActive(false);
    }

    public void damage() 
    {
        health -= 1;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        invinceTimer += 50;
        //rb.AddForce()

    }
}
