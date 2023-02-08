using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    // Start is called before the first frame update
    private float yBound = 8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= yBound )
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -yBound)
        {
            Destroy(gameObject);
        }
    }
}
