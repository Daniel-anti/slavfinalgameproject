using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 target = player.transform.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, target, 0.250f);
        transform.position = smooth;
    }
}
