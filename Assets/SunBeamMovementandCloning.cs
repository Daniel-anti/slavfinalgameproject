using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBeamMovementandCloning : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 originalPos;
    public Transform clonePoint;
    public bool hasCloned = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (!hasCloned && transform.position.x >= clonePoint.position.x) 
        {
            Instantiate(gameObject, originalPos, Quaternion.identity, transform.parent);
            hasCloned = true;
        }
    }
}
