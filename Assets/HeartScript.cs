using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public GameObject player;
    public float thisHeart;
    public GameObject full;
    private RuntimeAnimatorController fullHeart;
    public GameObject empty;
    private RuntimeAnimatorController emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        fullHeart = full.GetComponent<Animator>().runtimeAnimatorController;
        emptyHeart = empty.GetComponent<Animator>().runtimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        float curHealth = player.GetComponent<Health>().health;
        if (curHealth < thisHeart )
        {
            if (this.GetComponent<Animator>().runtimeAnimatorController == fullHeart)
            {
                this.GetComponent<Animator>().runtimeAnimatorController = emptyHeart;
            }
        }
        else if (this.GetComponent<Animator>().runtimeAnimatorController == emptyHeart)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = fullHeart;
        }
    }
}
