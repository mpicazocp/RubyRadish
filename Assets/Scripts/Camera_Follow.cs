using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update () {
        // transform.position = player.transform.position + new Vector2(0, 0.5f, 0);
                this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
    }
}
