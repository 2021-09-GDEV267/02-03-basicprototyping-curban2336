using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombDropper : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject bombPrefab;
    public GameObject boss;
    public float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenBombDrops = 1f;
    public TextMeshProUGUI bossHealthText;
    public int health;
    public int increment;
    private bool wavePause;


    // Start is called before the first frame update
    void Start()
    {
        health = 40;
        increment = 0;
        SetHealthText();
        Invoke("DropBomb", 2f);
        boss.SetActive(true);
    }

    void SetHealthText()
    {
        bossHealthText.text = "Boss Health: " + health.ToString();

        if (health == 0)
        {
            boss.SetActive(false);
        }
    }

    void DropBomb()
    {
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = new Vector3 (transform.position.x,transform.position.y, 10f);
        if (health == 0)
        {
            Invoke("WaveMaker", 0f);
            wavePause = true;
        }
        else
        {
            Invoke("DropBomb", secondsBetweenBombDrops);
        }
        if (wavePause == true)
        {
            float secondCounter = secondsBetweenBombDrops;
            secondsBetweenBombDrops = 4;
            Invoke("DropBomb", 4f);
            Invoke("newBoss", 4f);
            secondsBetweenBombDrops = secondCounter;
            wavePause = false;
        }
    }

    void newBoss()
    {
        increment += 10;
        health = 40 + increment;
        boss.SetActive(true);
    }

    void WaveMaker()
    {
        if (Mathf.Abs(speed) / speed == -1)
        {
            speed -= 5;
        }
        else
        {
            speed += 5;
        }
        if (secondsBetweenBombDrops > 0.25)
        {
            secondsBetweenBombDrops = secondsBetweenBombDrops / 2;
        }
        Bomb.tester += 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);

            health = health - 1;

            SetHealthText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
        SetHealthText();
    }
}

