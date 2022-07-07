using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// script to control the Nav Mesh Agent

namespace RPG.Movement{
    
    public class Mover : MonoBehaviour{
    
        [SerializeField] Transform target;

        void Update(){

            UpdateAnimator();
        }


        public void MoveTo(Vector3 destination){
            
            GetComponent<NavMeshAgent>().destination = destination;
        }

        private void UpdateAnimator(){
            
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity; // global velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); // convert to local velocity
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}