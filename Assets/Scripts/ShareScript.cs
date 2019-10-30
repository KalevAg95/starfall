using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareScript : MonoBehaviour {


// Use this for initialization

	 string subject = "Star Fall";
	 string body = "Check out my score on Star Fall!";

	 public void shareText(){

		 subject = "Star Fall";

		 body = "Check out my score on Star Fall: " + PlayerPrefs.GetFloat("HighScore").ToString() + "! http://play.google.com/store/apps/details?id=com.vvs.starfall";

	 	 	//execute the below lines if being run on a Android device
	 	 #if UNITY_ANDROID
	   //Refernece of AndroidJavaClass class for intent
	   AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
	   //Refernece of AndroidJavaObject class for intent
	   AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
	   //call setAction method of the Intent object created
	   intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
	   //set the type of sharing that is happening
	   intentObject.Call<AndroidJavaObject>("setType", "text/plain");
	   //add data to be passed to the other activity i.e., the data to be sent
	   intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
	   intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
	   //get the current activity
	   AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
	   AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
	   //start the activity by sending the intent data
	   currentActivity.Call ("startActivity", intentObject);
	   #endif
	 }
}
