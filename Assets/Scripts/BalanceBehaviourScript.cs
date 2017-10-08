using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBehaviourScript : MonoBehaviour {

    public GameObject balance;
    public double yMax;
    public double yMin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        balance.transform.position = new Vector2(balance.transform.position.x, (float)(yMin + (yMax - transform.position.y)));
	}
}
