using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparklesScript : MonoBehaviour {

	public GameObject sparkles;

	public void Sparkle(){
		StartCoroutine(ShowAndHide(sparkles, 0.5f) );
	}

	IEnumerator ShowAndHide(GameObject go, float delay){
		go.SetActive(true);
		yield return new WaitForSeconds(delay);
		go.SetActive(false);
	}
}
