using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI healthText;
    public GameObject loseTextObject;
    public GameObject player;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 5;

        SetHealthText();
        loseTextObject.SetActive(false);
        player.SetActive(true);
    }

    void SetHealthText()
    {
        healthText.text = "Player Health: " + health.ToString();

        if (health == 0)
        {
            loseTextObject.SetActive(true);
            player.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Bomb")
        {
            Destroy(collidedWith);

            health = health - 1;

            SetHealthText();

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        //pos.y = mousePos3D.y;
        this.transform.position = pos;
    }
}
