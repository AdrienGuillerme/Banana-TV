    using System;
    using System.Collections;
using System.Collections.Generic;
    using Assets;
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
            coll.gameObject.GetComponent<Rigidbody2D>().gravityScale = SettingsConstants.GravityImpact;
            Invoke("SetGravityBack", SettingsConstants.GravityImpact);
        }
       


    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
     void SetGravityBack()
     {
         try
         {
             _rbCollidedObject.gravityScale = 1;

        }
        catch (Exception e)
         {
         }
     }

    // Use this for initialization
    void Start () {
		Invoke("Hide",0.65f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
