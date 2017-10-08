using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBase : MonoBehaviour
{

    Transform target;
    Transform enemyTransform;
    public float speed = 3f;
    public float rotationSpeed = 3f;
    public float detectionRange = 10;
    public GameObject DieMenu;

    void OnCollisionEnter2D(Collision2D coll)
    {
        var contact = coll.contacts[0].normal;
        if (coll.gameObject.tag == "Player" && (contact == new Vector2(-1,0) || contact == new Vector2(1, 0)))
        {
            DieMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }
    void Start()
    {
        //obtain the game object Transform
        enemyTransform = gameObject.GetComponent<Transform>();
    }   

    void Update()
    {

        target = GameObject.FindWithTag("Player").transform;
        Vector3 targetHeading = target.position - enemyTransform.position;
        Vector3 targetDirection = targetHeading.normalized;
     //   enemyTransform.transform.rotation = Quaternion.LookRotation(targetDirection); // Converts target direction vector to Quaternion
     //  enemyTransform.transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z);
        gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(targetDirection.x, targetDirection.y) *speed* Time.deltaTime;
        Vector3 temp = enemyTransform.localScale;
        if (targetHeading.x > 0)         
            temp.x = 1;      
        if (targetHeading.x < 0)
            temp.x = -1;
        enemyTransform.localScale = temp;
        /** 
        //rotate to look at the player
            


        //move towards the player
       // 
     //   

        if (Vector3.Distance(transform.position, target.position) >= 150)
        {

        //      transform.position += transform.forward * 50 * Time.deltaTime;

        }**/
    }
}


