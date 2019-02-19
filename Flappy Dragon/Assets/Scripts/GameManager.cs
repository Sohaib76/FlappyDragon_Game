using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for adding GUI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// all variables should be public bcz we are going to reference in inspector

	// a system used to give control or command of all things to one class(GameManager) and it can be used as reference 
	public static GameManager instance;

	public float scrollSpeed = -1.2f;

	public Text ScoreGUI;

	//public GameObject gameOverAudio;



	// to reference top&bottom obstacles
	public Transform bottomObstacle,topObstacle;
	// varibale that hold audio source component
	AudioSource ad;
	// to show or hide the gameover text
	public GameObject gameOverText;

	public int Score = 0;
	public bool gameOver = false;

    //check
    public  AudioClip Sound1;

    // used before start .tis step is important
    void Awake() 
		{
			//If we don't currently have a game control...
			if (instance == null)
				//...set this one to be it...
				instance = this;
			//...otherwise...
			else if(instance != this)
				//...destroy this one because it is a duplicate.
				Destroy (gameObject);
		}
		
	

	// Use this for initialization
	void Start () {
        ad = GetComponent<AudioSource>();


        // game starts score will be zero

        // finding gameobject (Score) to edit text in the game scene
        // ScoreGUI = GameObject.Find ("Score").GetComponent<Text> ();

        // after doing all work in variable obstacle spawner we are going to implement it on start function
        InvokeRepeating ("ObstacleSpawner", .5f, 1.5f);
		// Invoke repeating function is used to repeated called a specified function
		// 1, parameter is function which is to repeated
		// 2, parameter is how long should it wait before it call the invoke repeating function
		// 3, parameter is the time interval b/w repeating

		// declaring audio variabe
		ad = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
		 
		
			if (gameOver == true && Input.GetMouseButtonDown (0))
			{
            
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
	

	}





    // A variable which will increament in our score
    // this should be public bcz of restrictions
    public void DragonScored() {

        if (gameOver == true)
        {

            return;
        }
        else
        {
            this.Score++;
            // finally text in the game view will update each time Gmaddscore triggered
            ScoreGUI.text = "Score: " + Score.ToString();
            ad.Play();
        }
	}
	// we have to update our obstacle script

	void ObstacleSpawner() {


		if (gameOver)
			return;


		// created a variable that store generated random number 
		int rand = Random.Range (0, 2);
		float 
		// top obstacle must spawn somewhere in top so min y of 2 and max y of 6
		topObstacleMinY = 3f,
		topObstacleMaxY = 6f,
		// bottom obstacle spawn somewhere in bottom so max y is -2 and min y -6
		bottomObstacleMinY = -6f,
		bottomObstacleMaxY = -3f;

		// we use generated random no in our switch statement to whether spawn top or bottom obstacle  
		switch (rand) {
		// if the random no generated 0 we will instantiate our bottom obstacle
		case 0:
			Instantiate (// unity built in function to create instance of a prefab
				bottomObstacle, new Vector2 (9f, Random.Range (bottomObstacleMinY, bottomObstacleMaxY)
					
			),
				Quaternion.identity);
			
			break;

		case 1:
			Instantiate (
				topObstacle, new Vector2 (9f, Random.Range (topObstacleMinY, topObstacleMaxY)
                
			),
				Quaternion.identity);
			break;
		}


		// Instantiate function needs 3 parameters 
		// 1, prefab reference (top or bottomObstacles variable)
		// 2, position of instantiated object (x vlue is 9 bcz we spawn obstacles beyond the game) and y value we set in random
		// 3, rotation


	}

	public void DragonDied()
	{

       
		
		
        StartCoroutine(DeathDragon());
		//ad.Play ();
		//Time.timeScale = 0;
	}

    private IEnumerator DeathDragon()
    {
        gameOver = true;
        yield return new WaitForSeconds(2);
        gameOverText.SetActive(true);
       
        // ad.clip = Sound1;
        // ad.Play ();


    }


}
