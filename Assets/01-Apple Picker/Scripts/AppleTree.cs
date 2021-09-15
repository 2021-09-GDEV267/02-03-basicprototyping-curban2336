using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    public Text scoreGT;
    public int scoreTest;
    public bool wavePause = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreTest = int.Parse(scoreGT.text);
        Invoke("DropApple", 2f);
        
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        if ((scoreTest % 1500) == 0 && scoreTest != 0)
        {
            Invoke("WaveMaker", 0f);
            wavePause = true;
        }
        else
        {
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
        if (wavePause == true)
        {
            float secondCounter = secondsBetweenAppleDrops;
            secondsBetweenAppleDrops = 4;
            Invoke("DropApple", 4f);
            secondsBetweenAppleDrops = secondCounter;
            wavePause = false;
        }
    }

    void WaveMaker()
    {
        if (Mathf.Abs(speed)/speed == -1)
        {
            speed -= 2;
        }
        else
        {
            speed += 2;
        }
        if (speed % 20 == 0 && secondsBetweenAppleDrops > 0.25)
        {
            secondsBetweenAppleDrops = secondsBetweenAppleDrops / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftAndRightEdge)
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
        scoreTest = int.Parse(scoreGT.text);
    }
}
