using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlowMotion : MonoBehaviour {

    public Rigidbody2D rb2d;

    // Slow motion
    public float timeScale = 0.1f;
    bool slowMoBool = true;
    float startMass, startGravityScale, startVelocity, startAngularVelocity;

    // Duration of the slow
    float slowTimeStamp;
    float slowDuration = 3.0f;

    // Cooldown of the slow
    float slowCooldownTimeStamp = -5.0f;
    float slowCooldown = 2.0f;
    

    // Smooth damp
    public float smoothTime = 0.5f;
    public float velocity = 0.0f;

    //max velocity
    public float maxVelocity = 10.0f;

    void Awake()
    {
        startGravityScale = rb2d.gravityScale;
        startMass = rb2d.mass;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.W) &&
            slowMoBool &&
            (Time.time - slowCooldownTimeStamp > slowCooldown))
        {
            Debug.Log("alo");
            SlowMo();
            slowTimeStamp = Time.time;
        }
        
        else if (!slowMoBool && (Input.GetKey(KeyCode.W) || (Time.time - slowTimeStamp > slowDuration)))
        {
            Debug.Log(Time.time - slowTimeStamp);
            StopSlowMo();
            slowCooldownTimeStamp = Time.time;
        }
        
    }

    void SlowMo()
    {
        
        if (slowMoBool)
        {
            rb2d.gravityScale *= timeScale;
            rb2d.mass /= timeScale;
            rb2d.velocity *= timeScale;
            rb2d.angularVelocity *= timeScale;

            //rb2d.gravityScale = Mathf.SmoothDamp(rb2d.gravityScale, startGravityScale * timeScale, ref velocity, smoothTime, 0.3f);
            //rb2d.mass = Mathf.SmoothDamp(rb2d.mass, startMass / timeScale, ref velocity, smoothTime, 0.3f);
            //rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, startVelocity  , ref v2Velocity, smoothTime, 0.3f, Time.deltaTime);
            //rb2d.angularVelocity = Mathf.SmoothDamp(rb2d.angularVelocity, startAngularVelocity / timeScale, ref velocity, smoothTime, 0.3f);
        }

        slowMoBool = false;

        float dt = Time.fixedDeltaTime * timeScale;
        //dt = Mathf.SmoothDamp(dt, Time.fixedDeltaTime * timeScale, ref velocity, smoothTime, 0.3f);

        rb2d.velocity += Physics2D.gravity / rb2d.mass * dt;
        //rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, startVelocity + (Physics2D.gravity / rb2d.mass * dt), ref velocity, smoothTime, 0.3f);
    }

    void StopSlowMo()
    {
        if (!slowMoBool)
        {
            rb2d.gravityScale = startGravityScale;
            rb2d.mass = startMass;


            rb2d.velocity /= timeScale * 5;
        }

        slowMoBool = true;
    }
}
