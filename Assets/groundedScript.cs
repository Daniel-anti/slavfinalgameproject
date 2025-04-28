using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("terrain")) 
        {
            transform.parent.gameObject.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("terrain"))
        {
            transform.parent.gameObject.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
