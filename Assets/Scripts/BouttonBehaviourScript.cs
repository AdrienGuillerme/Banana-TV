using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonBehaviourScript : MonoBehaviour
{

    public Renderer button;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            button.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            button.enabled = true;
        }
    }
}