using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    // What the camera follows
    public GameObject Player;


    // Use this for initialization
    void Start()
    {
        // grabs the player object from the scene
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // where to move the camera in terms of x
        float MovingXPos = Player.transform.position.x;

        // ditto in z
        float MovingZPos = Player.transform.position.z - 1f;

        // put them together for the result: moving the camera on a single plane with the tank
        transform.position = new Vector3(MovingXPos, transform.position.y, MovingZPos);
    }
}
