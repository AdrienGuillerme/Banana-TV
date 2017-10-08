using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformBehaviourScript : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Rigidbody2D>().gravityScale = 7f;
        }
    }
}
