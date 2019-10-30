using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public GameObject bird;
	public PauseScript pauseScript;

	void Start () {
	}

	void Update () {
		if(pauseScript.GetPaused()==false){

			int randomNumber = Random.Range(1,1000);

			if(randomNumber>=994){
				Vector3 randomSpawn = new Vector3(Random.Range(-3f, 3f),transform.position.y,transform.position.z);
				Instantiate (bird, randomSpawn, transform.rotation);
			}
		}
	}
}
