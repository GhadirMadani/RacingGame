using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // ← Add this

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    // Drag your TMP_Text references directly in the Inspector
    public TextMeshProUGUI MinuteDisplay;
    public TextMeshProUGUI SecondDisplay;
    public TextMeshProUGUI MilliDisplay;

    public GameObject LapTimeBox;

    public TextMeshProUGUI LapCounter;
    public int LapsDone;

    public float RawTime;

    public GameObject RaceFinish;
    

    void Update () {
        if (LapsDone == 2){
            RaceFinish.SetActive (true);
        }
    }

    // If you care which object triggered it, use the Collider parameter; 
    // otherwise you can leave it parameterless as before.
    void OnTriggerEnter()
    {
        LapsDone +=1;

        RawTime = PlayerPrefs.GetFloat ("RawTime");
        if (LapTimeManager.RawTime <= RawTime){
     // Format seconds with leading zero if needed
            if (LapTimeManager.SecondCount <= 9)
                SecondDisplay.text = $"0{LapTimeManager.SecondCount}.";
         else
                SecondDisplay.text = $"{LapTimeManager.SecondCount}.";

    // Format minutes with leading zero if needed
            if (LapTimeManager.MinuteCount <= 9)
                MinuteDisplay.text = $"0{LapTimeManager.MinuteCount}.";
         else
             MinuteDisplay.text = $"{LapTimeManager.MinuteCount}.";

    // Milliseconds (no extra formatting)
            MilliDisplay.text = LapTimeManager.MilliCount.ToString("F0");
        }
      

        PlayerPrefs.SetInt ("MinSave", LapTimeManager.MinuteCount);
        PlayerPrefs.SetInt ("SecSave", LapTimeManager.SecondCount);
        PlayerPrefs.SetFloat ("MilliSave", LapTimeManager.MilliCount);
        PlayerPrefs.SetFloat ("RawTime", LapTimeManager.RawTime);

        // Reset the timer
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0;
        LapTimeManager.RawTime = 0;
        LapCounter.text = LapsDone.ToString();

        // Switch your triggers
        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}
