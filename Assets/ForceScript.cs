    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    private float _gravityOfObjectWhoHaveBeenCollied;
    private Rigidbody2D _rbCollidedObject;
    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.otherCollider.gameObject.SetActive(false);

        if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            _gravityOfObjectWhoHaveBeenCollied = coll.gameObject.GetComponent<Rigidbody2D>().gravityScale;
            _rbCollidedObject = coll.gameObject.GetComponent<Rigidbody2D>();
            coll.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
            Invoke("SetGravityBack", 0.5f);
        }
       


    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
     void SetGravityBack()
     {
         _rbCollidedObject.gravityScale = 1;
     }

    // Use this for initialization
    void Start () {
		Invoke("Hide",0.65f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
