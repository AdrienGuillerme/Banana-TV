using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {
    private Vector3[] levelPositions = { new Vector3 (19.61f, 9.58f, 0), new Vector3(22.61f, 9.58f, 0) };
    public GameObject player;
    private bool isActive = false;
    private int selectedLevel = 0;

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

    public void showMap(int door)
    {
        Time.timeScale = 0;
        isActive = true;
        this.gameObject.SetActive(isActive);
        if (door == 1)
        {
            selectedLevel = 1;
        }
    }

    private void Resume(int level) {
        player.transform.position = levelPositions[level];
        Time.timeScale = 1;
        isActive = false;
        this.gameObject.SetActive(isActive);
    }
}
