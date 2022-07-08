using System;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;

// script responsible for RayCasts

namespace RPG.Control{
    public class PlayerController : MonoBehaviour{
        private void Update(){
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat(){
            RaycastHit[] hits = Physics.RaycastAll(getMouseRay());
            foreach (RaycastHit hit in hits){
                // check whether we hit a combat component and start attacking it
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0)){
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement(){
            RaycastHit hit;
            bool hasHit = Physics.Raycast(getMouseRay(), out hit);
            if (hasHit){
                // change Nav Mesh Agent's destination to the impact point of Raycast hit
                if (Input.GetMouseButton(0)){
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray getMouseRay(){
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
    
}


