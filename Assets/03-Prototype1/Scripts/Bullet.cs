using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bottomY = -16f;
    private float topY = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topY)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
