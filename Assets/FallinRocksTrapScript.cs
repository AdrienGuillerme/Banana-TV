using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallinRocksTrapScript : MonoBehaviour {

    public GameObject DieMenu;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
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