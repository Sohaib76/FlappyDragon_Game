using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {

	// Dragon script will hold movement, animation and collide.

	// for declaring rigidbody component
	Rigidbody2D rb;
	// for declaring animator component
	Animator anim;
	// fo dragon to fly or jump and how much power
	float jump=5f;
	// for variable to stooore if dragon is alive
	bool isDead = false;
	AudioSource ad;
	//public AudioClip flap;

	public static AudioClip Sound1;
	public AudioClip Sound2;


	void Start () {
		// our dragon alive at start of game
			
        // adding reference of game component rigidbody and animator
	    rb = GetComponent<Rigidbody2D> ();
	    anim =  GetComponent<Animator> ();
		ad = GetComponent<AudioSource>();
		// for jump 
		//jump = 5f;
		// for gravity
		//rb.gravityScale = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		// if dragon is alive then it fly
		if(isDead == false){
			// checks  for screen tap to flap
			if(Input.GetMouseButton (0)){

				// added after declaring void flap now our dragon will do the void flap things
				rb.velocity = Vector2.zero;
				rb.velocity = new Vector2 (0, jump);
				// above we set x value to 0 and y value to jump(which we declared)
				// trigger flap animation
				anim.SetTrigger ("Flap");
				// added after declaring void checkifdragon... now our dragon do all checkif things
				CheckIfDragonVisibleOnScreen ();


				//AudioSource.PlayClipAtPoint(flap , transform.position);
				ad.clip = Sound2;
				ad.Play ();


	        }
       }
   }


	// when a collider collides with other collider use this function
	void OnCollisionEnter2D(Collision2D other) //Collision2D target){
	{// if the game object obstacles(the tag we created for bottom and top obstacles) collide with dragon dragon is not alive
		// time.timescale means game time(game will close at 0) when collde
		//if (target.gameObject.tag == "Obstacles") {

			//if(other.gameObject.tag == "BackGround")
			//{
				//return;
			//}

		     isDead = true;

			// when dragon dies it falls on the ground
			rb.velocity = Vector2.zero;
		    anim.SetTrigger ("Die");
		   // ad.clip = Sound1;                 //remove comment
		   // ad.Play ();
		   
		    GameManager.instance.DragonDied ();

      

		 
		}

    
    void CheckIfDragonVisibleOnScreen() {
	
		if (Mathf.Abs (gameObject.transform.position.y) > 5.1) {
			isDead = true;
			rb.velocity = Vector2.zero;
			Time.timeScale = 0;

		 
		}
	}
	


			



	// Function made by us to check if dragon go outside the game view
	//void CheckIfDragonVisibleOnScreen(){
		// 5.25 is the maximum value to go upwards
		//if (Mathf.Abs (gameObject.transform.position.y) > 4.89f)
		//if (Mathf.Abs (gameObject.transform.position.y) > -5f)
		//{
			
			//Time.timeScale = 0f;
			// when dragon fly outside it die and time become zero
		//}

		
	//}





}