using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWinner : MonoBehaviour
{
   public Transform mainCamera;

   void Start(){
       mainCamera = Camera.main.transform;
   }

   void Update(){
       transform.position = mainCamera.position;
   }
}
