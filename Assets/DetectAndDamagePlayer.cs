using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndDamagePlayer : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //tells player that it's burning, starts a timer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Health>().isBurning();
            //confirms whether player is in the sun (should continue burning if damaged)
            collision.GetComponent<Health>().inSun = true;
            //collision.GetComponent
        }
    }

    //tells player that it's no longer in sun, cancels timer
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Health>().notBurningAnymore();
            collision.GetComponent<Health>().inSun = false;
        }
    }

}
