using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private GameManager gameManager;
    public float xRange = 20;
    private float maxRange = 73.2f;
    private float spawn = -14.75f;
    private float speed = 30.0f;
    public float horizontalInput;
    
    private Coin[] coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = FindObjectsOfType<Coin>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);

        if (gameManager.isGameActive) {
            if (transform.position.x < spawn)
            {
                transform.position = new Vector3(spawn, transform.position.y, transform.position.z);
                ResetCoins();
            }
            if (transform.position.x > maxRange)
            {
                transform.position = new Vector3(spawn, transform.position.y, transform.position.z);
                ResetCoins();
            }
        }
    }

    void ResetCoins()
    {
        foreach (Coin coin in coins)
        {
            coin.ResetPosition();
        }
    }
}
