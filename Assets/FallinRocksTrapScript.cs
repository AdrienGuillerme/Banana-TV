using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallinRocksTrapScript : MonoBehaviour {

    public GameObject DieMenu;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && coll.otherCollider.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 50)
        {
            DieMenu.SetActive(true);
            Time.timeScale = 0;
        }

        // Use this for initialization
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}