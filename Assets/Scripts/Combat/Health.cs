using UnityEngine;
namespace RPG.Combat{
    public class Health : MonoBehaviour{
        
        [SerializeField] float healthPoint = 100f;

        bool isDead = false;

        public void TakeDamage(float damage){
            
            healthPoint = Mathf.Max(healthPoint - damage, 0); // non-negativity
            // print(healthPoint);
            if(healthPoint == 0)
            {
                Die();
            }
        }

        private static void Die(){
            if(isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

}

