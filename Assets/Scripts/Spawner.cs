using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hazard; 
    public GameObject collectible;
    public GameObject warning;
    public static double difficulty = 0.0;
    static System.Random random = new System.Random();
    double timeInterval = 0.0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() 
    {
        if(PlayerControl.gameActive) {
            if(difficulty < 100)
            difficulty += Time.deltaTime;

            timeInterval += Time.deltaTime;
            if(timeInterval + difficulty / 140 > 1) {
                Spawn(hazard);
                timeInterval = 0.0;

                if(random.NextDouble() < 0.1)
                Spawn(collectible);

                if(random.NextDouble() < 0.05)
                Spawn(warning, transform.position.x - 2.5f);
            }
        }
    }

    void Spawn(GameObject thing) {
        Instantiate(thing, new Vector2(transform.position.x, ((float)(random.NextDouble()) * 10 - 5)), Quaternion.identity);
    }

    void Spawn(GameObject thing, float xPos) {
        Instantiate(thing, new Vector2(xPos, ((float)(random.NextDouble()) * 10 - 5)), Quaternion.identity);
    }

    public static void clearObjects() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("remove when paused");
        for(int i = 0; i < enemies.Length; i++) {
            Destroy(enemies[i]);
        }
    }
}
