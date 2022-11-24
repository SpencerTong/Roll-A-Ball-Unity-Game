using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public GameObject textDisplay;
    public int timeLeft = 120;
    public bool takingAway = false;

    public void Start(){
         textDisplay.GetComponent<Text>().text= "Time Remaining: " + timeLeft; 
    }

    public void Update() {
        if (!takingAway && timeLeft>0){
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake(){
        takingAway = true; 
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        textDisplay.GetComponent<Text>().text = "Time Remaining: " + timeLeft; 
        takingAway = false;
    }
}
