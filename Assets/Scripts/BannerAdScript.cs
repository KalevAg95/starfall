using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAdScript : MonoBehaviour {

	private BannerView bannerView;

	public void Start()
	{
			RequestBanner();
	}

	private void RequestBanner()
	{
			string adUnitId = "ca-app-pub-2091552892124144/1641205499";
			/*string adUnitId = "ca-app-pub-3940256099942544/6300978111"; //testing

			AdRequest request = new AdRequest.Builder()           //TES
				.AddTestDevice(AdRequest.TestDeviceSimulator)				//TING
				.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")	//ONE
				.Build();																						//TWO
				*/

			AdRequest request = new AdRequest.Builder().Build();



			// Create a 320x50 banner at the bottom of the screen.
			BannerView bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
			bannerAd.LoadAd(request);

	}
}
