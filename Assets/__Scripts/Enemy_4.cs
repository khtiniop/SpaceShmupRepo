 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 [RequireComponent( typeof(EnemyShield) )]
 public class Enemy_4 : Enemy {            // Enemy_4 also extends the Enemy class[Header("Enemy_4 Inscribed Fields")]
     public float           duration = 4;  
     

     private Vector3        p0, p1;        
     private float          timeStart;    

     public AudioClip deathSound; 
     public GameObject explosion; 
     void Start() {


         
        p0 = p1 = pos;                                                      
        InitMovement();

        AudioSource audioSource = GetComponent<AudioSource>(); 
        if (audioSource != null && audioSource.clip != null) { 
            audioSource.Play(); 
        }

     }

      void InitMovement() {                                                   
         p0 = p1;   
         
         float widMinRad = bndCheck.camWidth  - bndCheck.radius;
         float hgtMinRad = bndCheck.camHeight - bndCheck.radius;
         p1.x = Random.Range( -widMinRad, widMinRad ); 
         p1.y = Random.Range( -hgtMinRad, hgtMinRad );
         
        
         if ( p0.x * p1.x > 0 && p0.y * p1.y > 0 ) {                           
             if ( Mathf.Abs( p0.x ) > Mathf.Abs( p0.y ) ) {
                 p1.x *= -1;
             } else {
                 p1.y *= -1;
             }
         }     
        timeStart = Time.time;
     }

     public override void Move() {
         float u = (Time.time -timeStart) /duration;
 
         if (u >=1) {   
             InitMovement();
             u=0;
         }
 
         u = u - 0.15f * Mathf.Sin( u * 2 * Mathf.PI );  
         pos = (1-u)*p0 + u*p1;              

     }
     
 }