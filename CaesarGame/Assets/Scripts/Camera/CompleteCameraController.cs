using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    public float offsetZ = 10f;            //Private variable to store the distance in Z axis from player

    // Use this for initialization
    void Start()
    {
        offsetZ = -offsetZ;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, except in Z axis
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, offsetZ);
    }
}