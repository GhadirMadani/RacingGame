using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // <-- Use this instead of GameObject
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;
    public AudioSource LevelMusic;

    void Start()
    {
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);

        countdownText.text = "3";
        GetReady.Play();
        countdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);
        countdownText.text = "2";
        GetReady.Play();
        countdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);
        countdownText.text = "1";
        GetReady.Play();
        countdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);
        GoAudio.Play();
        LevelMusic.Play();
        LapTimer.SetActive(true);
        CarControls.SetActive(true);
    }
}
