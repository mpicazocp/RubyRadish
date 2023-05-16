using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    
    public float speed;

    // Update is called once per frame
    void Update () {
        var step =  speed * Time.deltaTime; // calculate distance to move
        var target = player.position;
        target.z = this.transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
