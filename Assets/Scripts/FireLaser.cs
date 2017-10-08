using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


// IMPORTANT: First child of this GameObject _must_ be the sprite to
// be displayed.
public class FireLaser : MonoBehaviour
{
	public float length;
	public float maxLength = 100f;
	public float width = 1.0f;
	public LayerMask layerMask;

	private GameObject collider;

	private float defaultWidth;

    // Use this for initialization
    void Start()
    {
		Vector3 eulerAngles = transform.GetChild(0).eulerAngles;
		transform.GetChild(0).eulerAngles = Vector3.zero;
		
		defaultWidth = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
		
		transform.GetChild(0).eulerAngles = eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit2D hit;
		
		// TODO: Center position
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		float angle = (transform.eulerAngles.z) * Mathf.Deg2Rad;
		Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

		if (length > 0) {
			hit = Physics2D.Raycast(position, direction, length, layerMask.value);
		}
		else {
			hit =  Physics2D.Raycast(position, direction, Mathf.Infinity, layerMask.value);
		}
		
		float actualLength;

		if (hit.collider) {
			actualLength = Vector2.Distance(hit.point, position);

			collider = hit.collider.gameObject;
		}
		else {
			actualLength = length;
			
			if (actualLength == 0) {
				actualLength = maxLength;
			}

			collider = null;
		}

		Vector3 scale = transform.localScale;
		scale.x = actualLength / defaultWidth;
		scale.y = width;
		
		transform.localScale = scale;
    }
}
