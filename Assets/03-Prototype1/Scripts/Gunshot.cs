using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public GameObject prefabProjectile;
    public float velocityMult = 10f;
    public string directional;
    public GameObject projectile;
    private Rigidbody projectileRigidbody;

    private float movementX;
    private float movementY;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    void MakeBullet()
    {
        if (directional == "North" || directional == "north")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
        else if (directional == "South" || directional == "south")
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
        else if (directional == "East" || directional == "east")
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
        else if (directional == "West" || directional == "west")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
    }

    void FixedUpdate()
    {
        if (directional == "North" || directional == "north")
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                projectileRigidbody.velocity = new Vector3(0, 0, 45) * Time.deltaTime;
                projectile = null;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
        else if (directional == "South" || directional == "south")
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                projectileRigidbody.velocity = new Vector3(0, 0, -45) * Time.deltaTime;
                projectile = null;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
        else if (directional == "East" || directional == "east")
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                projectileRigidbody.velocity = new Vector3(45, 0, 0) * Time.deltaTime;
                projectile = null;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
        else if (directional == "West" || directional == "west")
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                projectileRigidbody.velocity = new Vector3(-45, 0, 0) * Time.deltaTime;
                projectile = null;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                projectile.transform.position = this.transform.position;
                projectileRigidbody = projectile.GetComponent<Rigidbody>();
            }
        }
    }
}
