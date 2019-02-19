using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	// we use rigidbody velocity to move our obstacles
	// we destroy our game object if goes outside the game view
	// add score when dragon pass obstacles

    Rigidbody2D rb;
	// float variable to find first dragon position in our scene and add score {Holds the dragon x position}
	float dragonXposition;
	// to add score
	bool isScoreAdded;
	// after creating game manager script
	GameManager gameManager;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		// to move obstacle horizontally at velocity of -2.5 mving left
		//if (GameManager.instance.gameOver == true)
			//return;


		rb.velocity = new Vector2 (-2.5f, 0);

		// declaring position of dragon in game as a dragonXposition 
		dragonXposition = GameObject.Find("Dragon").transform.position.x;

		// score will not added at start
		isScoreAdded = false;

		// referencing game manager object using gameobject.find and get its gamemanagerscript using get component
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.gameOver == true) {
			rb.velocity = Vector2.zero;
		}



		//if (gameOver)
			//return;

		// if dragon pass through obstacle (transform.position.x is current x position of obstacle and
		// dragon x postion is current x position of dragon)
		if (transform.position.x <= dragonXposition) {
		// score will add after dragon passs obstacle
			if (!isScoreAdded){
				// Add Score is function that shows in what way score will add
				AddScore ();
				isScoreAdded = true;
			}
		}
		// if x postion of obstacle is less than -9 the game object(obstacle) will destroy
		if (transform.position.x <= -9f) {
			Destroy (gameObject);
			//GameManager.instance.gameOver ();
		}
	}

	void AddScore (){
	// now call our GMAddScore function in our obstacle script
		gameManager . DragonScored();
	}

}
