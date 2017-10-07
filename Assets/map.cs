using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {
    private Vector2[] levelPositions = { new Vector2 (19.61f, 9.58f), new Vector2 (22.61f, 9.58f) };
    private bool isActive = false;
    private int selectedLevel = 0;
    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            if (Input.GetKeyDown("v"))
            {
                Resume(selectedLevel);
            }
        }
		
	}

    public void showMap(int door, GameObject p)
    {
        player = p;
        Time.timeScale = 0;
        isActive = true;
        this.gameObject.SetActive(isActive);
        selectedLevel = door;
    }

    private void Resume(int level) {
        player.transform.position = levelPositions[level];
        player.transform.position = levelPositions[level];
        Time.timeScale = 1;
        isActive = false;
        this.gameObject.SetActive(isActive);
    }
}
