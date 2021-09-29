using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public GameObject prefabProjectile;
    public float velocityMult = 40f;
    public GameObject projectile;
    private Rigidbody projectileRigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.velocity = new Vector3(0,10,0);
        projectile = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
    }
}
