using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeHillAI : MonoBehaviour
{
    public float senseRange;
    public GameObject player;
    public ChimeState aiState = ChimeState.idle;
    public enum ChimeState 
    {
        idle,
        pursue,
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update state by proximity
        if (Vector3.Distance(player.transform.position, transform.position) > senseRange)
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
                break;
            case ChimeState.pursue:
                break;
           
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<Health>().damage();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * 4f, ForceMode2D.Impulse);
        }
    }
}
