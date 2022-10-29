using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject startPanel;
    public static bool gameActive = false;
    bool jumpActive = false;
    bool alive = false;
    int multiplier = 0; //changes based on whether or not the game should be active
    Rigidbody2D rb = new Rigidbody2D();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(jumpActive == false && Input.GetKey(KeyCode.S))
            StartJump();
        if(alive == true && Input.GetKey(KeyCode.C))
            rb.gravityScale -= 0.10f * multiplier;
        else {
            rb.gravityScale += 0.10f * multiplier;
        }
        
        if(rb.gravityScale >= 1.5f)
            rb.gravityScale = 1.5f;
        else if(rb.gravityScale <= -1.5f)
            rb.gravityScale = -1.5f;

        if(rb.velocity.y > 5)
            rb.velocity = Vector3.up * 5;
        else if (rb.velocity.y < -5)
            rb.velocity = Vector3.up * -5;

        

        if(/*gameActive == true &&*/ transform.position.y < -5.5) {
            EndGame();
        }
        if(gameActive == false && transform.position.y > 0) {
            StartGame();
        }
    }

    void StartJump() {
        jumpActive = true;
        startPanel.SetActive(false); 
        transform.position = new Vector3(transform.position.x, -5.5f, 0);
        rb.velocity = Vector3.up * 5;
        rb.gravityScale = 0.10f;
    }

    void StartGame() {
        alive = true;
        multiplier = 1;
        Spawner.difficulty = 0.0;
        startPanel.SetActive(false); 
        rb.gravityScale = 1.5f;
        gameActive = true;
        UIManager.SetScore(0);
    }

    void EndGame() {
        multiplier = 0;
        rb.gravityScale = 0.0f;
        rb.velocity = Vector3.up * 0;
        
        gameActive = false;
        jumpActive = false;
        alive = false;
        startPanel.SetActive(true);
        Spawner.clearObjects();
    }

    public void die() {
        alive = false;
    }

    public float getHeight() {
        return rb.position.y;
    }
}