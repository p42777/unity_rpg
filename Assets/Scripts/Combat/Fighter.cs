using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat{
    public class Fighter : MonoBehaviour, Action{
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;

        Transform target;
        float timeSinceLatAttack = 0;

        private void Update(){
            timeSinceLatAttack = timeSinceLatAttack + Time.deltaTime; 
            if (target == null) return;

            if (!GetIsInRange()){
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                // attack within range
                AttackBehaviour();
                // GetComponent<Animator>().SetTrigger("attack");
            }
        }

        private void AttackBehaviour(){
            // throttling attack
            if (timeSinceLatAttack > timeBetweenAttacks){
                // triggers Hit() event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLatAttack = 0; // reset 
            }
            
        }

        // Animation Events
        private void Hit(){
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange(){
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget){
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel(){
            target = null;
        }

       
    }
}