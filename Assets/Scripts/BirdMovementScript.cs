using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovementScript : MonoBehaviour {


	public Rigidbody2D rb;
	public GameObject bird;
	public float birdSpeed;
	public bool right = true;
	private Vector3 directionRight=new Vector3(1,1,0);
	private Vector3 directionLeft=new Vector3(-1,1,0);
	private Vector2 currentForce;
	private bool prevPaused;

	void Start () {
		if(right){
			rb.AddForce(new Vector2(100,90));
		}else if(right==false){
			rb.AddForce(new Vector2(-100,90));
		}

		bool prevPaused=false;
	}

	void Update () {

		bool paused = GameObject.Find("Paused").GetComponent<PauseScript>().paused;

		if(prevPaused!=paused&&paused==false){
				rb.velocity=currentForce;
				prevPaused=false;
		}

		if(paused) {
      Time.timeScale = 0;
   	} else if (!paused) {
  		Time.timeScale = 1;
		}

		if(paused==false){
			currentForce=rb.velocity;
			if(rb.velocity.x>0){
				transform.rotation = Quaternion.Euler(0,180,0);
			}else{
				transform.rotation = Quaternion.Euler(0,0,0);
			}
		}else{
			prevPaused=true;
			rb.Sleep();
		}

	}

	public void ResumeGame(){
		rb.velocity=currentForce;
	}

	void OnCollisionEnter2D(Collision2D coll){

		if(coll.gameObject.tag=="Bird" || coll.gameObject.tag=="WallLeft" || coll.gameObject.tag=="WallRight"){
			if(right){
				rb.Sleep();
				rb.AddForce(new Vector2(100,90));
				right=false;
			}else{
				rb.Sleep();
				rb.AddForce(new Vector2(-100,90));
				right=true;
			}
		}else if(coll.gameObject.tag=="Ceiling"){
			Destroy(bird);
		}
	}

	public void DestroyBird(){
		Destroy(bird);
	}

}
