using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {
    public int level = 0;
    public GameObject Map;
    private bool _mapIsShown = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _mapIsShown = true;
            Time.timeScale = 0;
            Map.SetActive(_mapIsShown);
        }
    }
}
