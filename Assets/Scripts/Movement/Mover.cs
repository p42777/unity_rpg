using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

// script to control the Nav Mesh Agent

namespace RPG.Movement{
    public class Mover : MonoBehaviour, Action{
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;

        private void Start(){
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update(){
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination){
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination){
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel(){
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator(){      
            Vector3 velocity = navMeshAgent.velocity; // global velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); // convert to local velocity
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }

}