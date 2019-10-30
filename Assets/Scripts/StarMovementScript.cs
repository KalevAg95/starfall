using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMovementScript : MonoBehaviour {

	public PauseScript pauseScript;
	public SpriteRenderer starSpriteRenderer;
	public Rigidbody2D rb;
	public Transform transform;
	private Vector2 currentForce;

	public float starForce;
	public bool ended=false;
	public int currentScore;
	public float countdown =0.25f;

	public GameObject mofokinStarboy;
	public GameObject playButton;
	public GameObject	scoreButton;
	public GameObject rateButton;
	public GameObject starLogo;
	public GameObject fallLogo;
	public GameObject jumpLeftButton;
	public GameObject jumpRightButton;
	public GameObject pauseButton;
	public GameObject shareButton;
	public GameObject menuButton;
	public Text scoreTextTop;
	public Text displayScore;
	public Text displayCurrentScore;
	public Text scoreText;
	public Text gameOverText;


	void Start(){
		displayCurrentScore.text=PlayerPrefs.GetFloat("CurrentHighScore").ToString();
		displayScore.text=PlayerPrefs.GetFloat("HighScore").ToString();
		rb.Sleep();
		currentScore=0;
	}

	public void Update(){

		bool paused = pauseScript.paused;

		if(paused==false){
			countdown -= Time.deltaTime;
			if(countdown<=0){
				currentScore+=5;
				SetCountText();
				countdown=0.25f;
			}
			currentForce=rb.velocity;
		}else{
			rb.Sleep();
		}
//NOOOOOOO stops all animation

		if(rb.velocity.x>0){
			transform.rotation = Quaternion.Euler(0,180,0);
		}else{
			transform.rotation = Quaternion.Euler(0,0,0);
		}

		PlayerPrefs.SetFloat("CurrentHighScore", currentScore);
	}

	public void JumpRight(){
		rb.Sleep();
		rb.AddForce(new Vector2(starForce, starForce*3.5f));
	}

	public void JumpLeft(){
		rb.Sleep();
		rb.AddForce(new Vector2(-starForce, starForce*3.5f));
	}

	public void StartGame(){
		rb.AddForce(new Vector2(0, starForce*3.5f));
	}

	public void ResetPosition(){
		transform.position = new Vector2(0f, 1f);
	}

	public void ResumeGame(){
		rb.velocity=currentForce;
	}

	void SetCountText(){
		scoreTextTop.text= "SCORE: " + currentScore.ToString();
	}

	public void FlipX(){
		if(currentForce.x>0){
			starSpriteRenderer.flipX=true;
		}
	}

	public void DestroyBirds(){
		var clones = (GameObject.FindGameObjectsWithTag("Bird"));
		foreach(var clone in clones){
			Destroy(clone);
		}
	}

	public void EndGame(){


		displayCurrentScore.text=PlayerPrefs.GetFloat("CurrentHighScore").ToString();

		pauseButton.SetActive(false);
		jumpLeftButton.SetActive(false);
		jumpRightButton.SetActive(false);
		scoreTextTop.gameObject.SetActive(false);
		mofokinStarboy.gameObject.SetActive(false);


		menuButton.SetActive(true);
		shareButton.SetActive(true);
		gameOverText.gameObject.SetActive(true);
		scoreText.gameObject.SetActive(true);
		displayCurrentScore.gameObject.SetActive(true);


		if (currentScore>PlayerPrefs.GetFloat("HighScore")){
			PlayerPrefs.SetFloat("HighScore", currentScore);
			displayScore.text=PlayerPrefs.GetFloat("HighScore").ToString();
		}
		currentScore=0;
		Time.timeScale = 1;
	}

	void OnCollisionEnter2D(Collision2D coll){

		if(coll.gameObject.tag=="Bottom"){
			EndGame();
		}

		if(coll.gameObject.tag=="Bird" || coll.gameObject.tag=="Bottom"){
			ended=true;
			pauseScript.paused=true;
			ResetPosition();
			DestroyBirds();
			EndGame();

		}
	}

}
