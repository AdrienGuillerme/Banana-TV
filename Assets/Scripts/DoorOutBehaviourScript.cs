using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOutBehaviourScript : MonoBehaviour {

    public double xTarget;
    public double yTarget;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector2((float)xTarget, (float)yTarget);
        }
    }
}
