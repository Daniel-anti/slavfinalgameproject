using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float slashTimer;
    // Start is called before the first frame update
    void Start()
    {
        slashTimer = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slashTimer > 0) 
        {
            slashTimer -= 1;
            if (slashTimer == 0) 
            {
                slashTimer += 50;
                gameObject.SetActive(false);
            }
        }
    }
}
