using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GreenPlayerController : MonoBehaviour {

public float speed;

private Rigidbody rb;



public int GreenCount = 0;
public int GreenScore = 0;
public Text countText;

private Vector3 jump;
public bool isGrounded=true;
public float gravityScale = 4;
public bool redWonCollision = false;


void Start(){
    rb = GetComponent<Rigidbody>();
    GreenCount = 0;
    GreenScore = 0;
    setScoreText();    
    jump = new Vector3(0.0f, 10.0f, 0.0f);

}


 void FixedUpdate() 
 {
    float moveHorizontal = Input.GetAxis ("HorizontalAlt");
    float moveVertical = Input.GetAxis ("VerticalAlt");

    rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    rb.AddForce(movement * speed);

    if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded){
            
            isGrounded = false;
            rb.AddForce(jump, ForceMode.Impulse);
        }

 }
 

 void OnTriggerEnter(Collider other) {
     if (other.gameObject.CompareTag("Pick Up")){
        other.gameObject.SetActive(false);
        GreenCount++; 
        GreenScore++;
        setScoreText();    
    }

 }
    
void setScoreText() {
        countText.text = "Green Player: " + GreenScore.ToString();
}



void OnCollisionEnter(Collision collision){
        if (collision.collider.tag=="Ground"){
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Walls")){
            GreenScore--;
        }

        if (collision.gameObject.CompareTag("Ball")){
            float altOther = collision.transform.position.y;
            float currAlt = transform.position.y;
            if (altOther-0.2>currAlt)
            {
                GreenScore--;
                redWonCollision = true;
            } 
        }
        setScoreText();
}

void OnCollisionExit(Collision collision){
     if (collision.gameObject.CompareTag("Ball")){
        redWonCollision = false;
     }
}


}



