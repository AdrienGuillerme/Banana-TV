using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBehaviourScript : MonoBehaviour {

    public GameObject pressCenter;
    public double Min;
    public double Max;
    public double vitesse;
    private float n;

	// Use this for initialization
	void Start () {

        n = -1f * (float)vitesse;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(transform.position.x, transform.position.y + n);
        pressCenter.transform.position = new Vector2(pressCenter.transform.position.x, pressCenter.transform.position.y + n/2);
        pressCenter.transform.localScale = new Vector2(pressCenter.transform.localScale.x, pressCenter.transform.localScale.y - 3.5f * n);

        if(transform.position.y <= Min)
        {
            n = 1f * (float)vitesse;
        }
        if(transform.position.y >= Max)
        {
            n = -1f * (float)vitesse;
        }
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x - 5, collision.gameObject.transform.position.y);
        }
    }
}
