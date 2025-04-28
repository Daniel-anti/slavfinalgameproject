using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class ManualPlayerAnimator : MonoBehaviour
{
    public Sprite idle1;
    public Sprite idle2;

    public Sprite run1;
    public Sprite run2;
    public Sprite run3;
    public Sprite run4;

    public Sprite jump1;
    public Sprite jump2;

    
    private int frame = 0;
    private SpriteRenderer sR;

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frame = (frame + 1) % 50;

        pS pState = GetComponent<PlayerMovement>().playerState;

        switch (pState) 
        {
            case pS.lI:
                sR.sprite = idle();
                if (!sR.flipX) 
                {
                    sR.flipX = true;
                }
                break;
            case pS.rI:
                sR.sprite = idle();
                if (sR.flipX) 
                {
                    sR.flipX = false;
                }
                break;
            case pS.lR:
                sR.sprite = run();
                if (!sR.flipX)
                {
                    sR.flipX = true;
                }
                break;
            case pS.rR:
                sR.sprite = run();
                if (sR.flipX)
                {
                    sR.flipX = false;
                }
                break;
            case pS.lJ:
                sR.sprite = jump();
                if (!sR.flipX)
                {
                    sR.flipX = true;
                }
                break;
            case pS.rJ:
                sR.sprite = jump();
                if (sR.flipX)
                {
                    sR.flipX = false;
                }
                break;
        }

    }

    Sprite idle() 
    {
        switch (frame > 24) 
        {
            case true:
                return idle2;
                
            case false:
                return idle1;
                
        }
    }

    Sprite run() 
    {
        if (frame < 12)
        {
            return run1;
        }
        else if (frame < 24)
        {
            return run2;
        }
        else if (frame < 36)
        {
            return run3;
        }
        else 
        {
            return run4;
        }
    
    }

    Sprite jump()
    {
        if (frame < 25)
        {
            return jump1;
        }
        else 
        {
            return jump2;
        }
    }

}
