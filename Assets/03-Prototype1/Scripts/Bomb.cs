using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float deathCounter;
    public static float tester;
    
    // Start is called before the first frame update
    void Start()
    {
        deathCounter = 0;
        tester = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        deathCounter = deathCounter + Time.deltaTime;
        if(deathCounter >= tester)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }
    }
}
