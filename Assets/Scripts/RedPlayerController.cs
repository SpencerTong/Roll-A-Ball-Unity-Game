using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RedPlayerController : MonoBehaviour {

public float speed;

private Rigidbody rb;



public int RedCount = 0;
public int RedScore = 0;
public Text countText;

private Vector3 jump;
public bool isGrounded=true;
public float gravityScale = 4;
public bool greenWonCollision = false;

void Start(){
    rb = GetComponent<Rigidbody>();
    RedCount = 0;
    RedScore = 0;
    setScoreText();    
    jump = new Vector3(0.0f, 10.0f, 0.0f);

}


 void FixedUpdate() 
 {
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    rb.AddForce(movement * speed);

    if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            
            isGrounded = false;
            rb.AddForce(jump, ForceMode.Impulse);
        }


 }

 void OnTriggerEnter(Collider other) {
     if (other.gameObject.CompareTag("Pick Up")){
        other.gameObject.SetActive(false);
        RedCount++; 
        RedScore++;
        setScoreText();    
    }

 }
    
void setScoreText() {
        countText.text = "Red Player: " + RedScore.ToString();
}



void OnCollisionEnter(Collision collision){

        if (collision.collider.tag=="Ground"){
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Walls")){
            RedScore--;
        }

        if (collision.gameObject.CompareTag("Ball")){
            float altOther = collision.transform.position.y;
            float currAlt = transform.position.y;
            if (altOther-0.2>currAlt)
            {
                RedScore--;
                greenWonCollision = true;
            } 
        }

        setScoreText();
}

void OnCollisionExit(Collision collision){
     if (collision.gameObject.CompareTag("Ball")){
        greenWonCollision = false;
     }
}


}



