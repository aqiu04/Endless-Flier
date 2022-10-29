using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    GameObject player;
    public GameObject enemy;
    int verticalMultiplier = 1;
    double timer;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        timer = (4 - Spawner.difficulty / 30);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < player.transform.position.y) {
            verticalMultiplier = 1;
        }
        else {
            verticalMultiplier = -1;
        }
        rb.velocity = Vector3.up * verticalMultiplier;
        
        timer -= Time.deltaTime;
        if(timer <= 0) {
            Instantiate(enemy, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
