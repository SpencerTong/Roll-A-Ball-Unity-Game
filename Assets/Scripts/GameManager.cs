using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

public Text winText;
public Button startButton;

public RedPlayerController RedPlayer;
public GreenPlayerController GreenPlayer;
public GameTimer Timer;
public Text timeUpdate;
public Text CollisionWinner;

int RedCount = 0;
int RedScore = 0;

int GreenScore = 0; 
int GreenCount = 0;
int TimeLeft = 120;
int TimePopUp = 120;

   private void Awake()
   {
       Time.timeScale = 0f;
   }

   private void OnEnable()
   {
      startButton.onClick.AddListener(StartGame);
   }

   private void OnDisable()
   {
      startButton.onClick.RemoveListener(StartGame);
   }

   private void StartGame()
   {
      Time.timeScale = 1f;

      // Hides the button
      startButton.gameObject.SetActive(false);
   }


   void Start() {
      winText.text = "";
      timeUpdate.text = "";
      CollisionWinner.text = "";
   }

   void Update() {
      RedCount = RedPlayer.RedCount;
      GreenCount = GreenPlayer.GreenCount;

      RedScore = RedPlayer.RedScore;
      GreenScore = GreenPlayer.GreenScore;
      
      TimeLeft = Timer.timeLeft;
      if (RedCount + GreenCount >=20){
         if (RedScore>GreenScore){
            winText.text = "Red Wins!";
         } else if (GreenScore>RedScore){
            winText.text = "Green Wins!";
         } else {
            winText.text = "Tie!";
         }
      }

      if (TimeLeft==0){
         timeUpdate.text = "Time Is Up!";
         Time.timeScale = 0f;
      }

      if (TimeLeft==120/2){
         timeUpdate.text = "Time Is Halfway Done!";
      }

      if (TimeLeft==55){
         timeUpdate.text = "";
      }

      if (TimeLeft==TimePopUp){
         CollisionWinner.text = "";
      }


      if (RedPlayer.greenWonCollision){
         CollisionWinner.text = "Green Won The Collision!";
         TimePopUp = TimeLeft-3;
      }

      if (GreenPlayer.redWonCollision){
          CollisionWinner.text = "Red Won The Collision!";
         TimePopUp = TimeLeft-3;
      } 
   }



}
