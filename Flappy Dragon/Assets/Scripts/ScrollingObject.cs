using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

     Rigidbody2D rb;

	// Speed of scrolling
	//float scrollSpeed = -1.5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (GameManager.instance.scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
			
		if (GameManager.instance.gameOver == true) {
			rb.velocity = Vector2.zero;
		}
	}
}
