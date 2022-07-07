using UnityEngine;
using RPG.Movement;
using RPG.Combat;

// script responsible for RayCasts

namespace RPG.Control{
    public class PlayerController : MonoBehaviour{

        private void Update(){
            // TODO
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat(){

            RaycastHit[] hits = Physics.RaycastAll(getMouseRay());
            foreach (RaycastHit hit in hits){

                // check whether we hit a combat component and start attacking it
                CombatTarget target = hit.transform.GetComponent<CombatTarget>(); // available for both RigidBody and Collider
                if(target == null){
                    continue;
                }
                if(Input.GetMouseButtonDown(0)){
                    GetComponent<Fighter>().Attack(target);

                }

            }
        }

        private void InteractWithMovement(){
            if (Input.GetMouseButton(0)){

                MoveToCursor();
            }
        }

        private void MoveToCursor(){

            RaycastHit hit;
            bool hasHit = Physics.Raycast((Ray)getMouseRay(), out hit);
            if (hasHit == true){
                
                // change Nav Mesh Agent's destination to the impact point of Raycast hit
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray getMouseRay(){

            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}


