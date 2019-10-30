using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateScript : MonoBehaviour {

	// Use this for initialization
	public void rateScript(){
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.vvs.starfall");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
		#endif
	}
}
