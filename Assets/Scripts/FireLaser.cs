using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class FireLaser : MonoBehaviour
{
    public float randomCoeff = 2.5f; // coeff pour que ça soit cohérent 
    public int orientation = 1; //1 pour droite, -1 pour gauche
    //public GameObject player;
    private Vector3 fwd;
    private float rayLen = 100f;
    private Transform ray;
    private RaycastHit2D[] hit = new RaycastHit2D[3];
    private RaycastHit2D baseHit;
    private RaycastHit2D lastHit;
    private ContactFilter2D filter;
    private Vector3 offsetOrigin = new Vector3(0, 0.15f, 0);

    /*
    public Transform rayTemplate = null;
    public bool onContact = false;
    */

    // Use this for initialization
    void Start()
    {
        fwd = transform.TransformDirection(this.transform.right * orientation); //à changer en fonction de l'orientation du sprite définitif
        ray = transform.GetChild(0);
        baseHit = Physics2D.Raycast(transform.position + offsetOrigin, fwd, 20.0f);
        lastHit = baseHit;
    }

    // Update is called once per frame
    void Update()
    {
        //mettre à jour la distance du laser 
        filter.NoFilter();
        Physics2D.Raycast((Vector2)(transform.position + offsetOrigin), (Vector2)fwd, filter, hit, 100.0f);
        
        if (hit[1] && hit[1].point != baseHit.point && hit[1].point != lastHit.point)
        {
            rayLen = this.transform.position.x - hit[1].point.x;
            lastHit = hit[1];
        }
        else if (hit[2] && hit[2].point != baseHit.point && hit[2].point != lastHit.point && hit[1].point != lastHit.point)
        {
            rayLen = this.transform.position.x - hit[2].point.x;
            lastHit = hit[2];
        }
        ray.localScale = new Vector3(ray.localScale.x, rayLen * randomCoeff, ray.localScale.z);

        //tuer le joueur
        if (lastHit.transform.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }

        Array.Clear(hit, 0, 3);
    }
}
