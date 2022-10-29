using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    int verticalMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * 15;
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
        rb.velocity = new Vector3((float)(-15 - Spawner.difficulty / 10), 1 * verticalMultiplier, 0);
        if(transform.position.x < -10) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();
        
        if (controller != null)
        {
            controller.die();
            Destroy(gameObject);
        }
    }
}
