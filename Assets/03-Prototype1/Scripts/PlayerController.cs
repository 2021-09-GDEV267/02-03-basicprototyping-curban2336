using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI healthText;
    public GameObject winTextObject;
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
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        player.SetActive(true);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();

        if (health == 0)
        {
            loseTextObject.SetActive(true);
            player.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;

            SetHealthText();
        }

        if (other.gameObject.CompareTag("Turret"))
        {
            health = health - 1;

            SetHealthText();
        }
    }
}
