using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * 4;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.left * (float)(4 + Spawner.difficulty / 10);
        if(transform.position.x < -10) {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();
        
        if (controller != null)
        {
            UIManager.AddScore(200);
            Destroy(gameObject);
        }
    }

}
