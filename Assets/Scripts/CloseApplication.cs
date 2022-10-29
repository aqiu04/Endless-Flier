using UnityEngine;
using System.Collections;

//Program terminates when Esc key is pressed
public class CloseApplication : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}