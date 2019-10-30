using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public bool paused=true;

	void Start(){
		paused=true;
	}
	public bool GetPaused(){
		return paused;
	}
	public void ResumeGame(){
		paused=false;
	}
	public void PauseGame(){
		paused=true;
	}
}
