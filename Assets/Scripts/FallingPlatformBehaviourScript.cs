using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformBehaviourScript : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D other)
    {
        var contact = other.contacts[0].normal;
        if (other.gameObject.tag == "Player" && contact == new Vector2(0, -1))
        {
            Invoke("Fall",0.75F);
        }
    }

    void Fall()
    {
        Debug.Log("coucou   ");
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().gravityScale = 9;
    }
}
