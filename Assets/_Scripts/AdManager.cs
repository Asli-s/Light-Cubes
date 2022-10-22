 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
//


using System;
using UnityEngine.UI;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public GameObject GoldReward;

    public string Android_Game_ID = "4959907";
    public string Iphone_Game_ID = "4959906";

    string AdIdIOS = "Rewarded_iOS";
    string AdIdAndroid = "Rewarded_Android";

    string GameId;
    string AdId;

    public Button showAdButton;

    public Health health;
    public GameOver gameOverAlert;

    bool loadedSuccessfully = false;

    public BannerAd bannerAd;

    Scene currentScene;

    bool buttonCLick = false;


    bool testmode = false;
    public Action onRewardedAdSuccess;


    void Awake()
    {
        print("awake ad");

        if (Application.platform == RuntimePlatform.Android)
        {
            GameId = Android_Game_ID;
            AdId = AdIdAndroid;
        }


        else
        {
            GameId = Iphone_Game_ID;
            AdId = AdIdIOS;
        }

        Advertisement.Initialize(GameId, testmode, this);


        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Endless")
        {
            gameOverAlert = GameObject.Find("-----Canvas--------/Canvas/GameLoseAlert").GetComponent<GameOver>();
            health = GameObject.Find("-----Canvas--------/TextCanvas/HealthBar").GetComponent<Health>();
        }
    }





    void ActivateReward()
    {

        health.AddLife();
        gameOverAlert.CloseGameOverALert();
    }

    bool adStarted = false;

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        Advertisement.Load(AdId, this);
        bannerAd.LoadBanner();


    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("failed");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        if (!adStarted)
        {
            loadedSuccessfully = true;
            if (notready = false)
            {
                notready = true;
                Advertisement.Show(AdId, this);


            }
        }
    }
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {

        print("failed");

    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {

        print("failed");

    }

    public bool adCompleted;
    public void OnUnityAdsShowStart(string adUnitId)
    {
        adStarted = true;
        Debug.Log("Ad Started: " + adUnitId);

    }


    public void ckilcKButton()
    {
        print("adStarted" + adStarted);
        print("loaded" + loadedSuccessfully);
        if (loadedSuccessfully)
        {
            Advertisement.Show(AdId, this);

        }
        else
        {

            Advertisement.Load(AdId, this);
            notready = false;


        }
        gameOverAlert.clicked = false;

    }


    bool notready = true;

    public void OnUnityAdsShowClick(string adUnitId)
    {
        Debug.Log("Ad Clicked: " + adUnitId);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        adCompleted = showCompletionState == UnityAdsShowCompletionState.COMPLETED;
        Debug.Log("Ad Completed: " + adUnitId);
        adStarted = false;
        Advertisement.Load(AdId, this);

        ActivateReward();
    }


}