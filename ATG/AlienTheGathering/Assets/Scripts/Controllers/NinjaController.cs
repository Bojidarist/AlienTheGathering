using UnityEngine;
using System.Collections;

namespace ATG.Controllers
{
    public class NinjaController : MonoBehaviour
    {
        [SerializeField] private int health = 10;
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private AlienController player = default;
        private int direction = 0;   // This value will be multiplied on movement
        private Vector3 movementVec = Vector3.zero;
        private SpriteRenderer spriteRenderer = default;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();            
        }

        void Update()
        {
            if (player != null)
            {
                if(player.gameObject.transform.position.x < transform.position.x)
                {
                    direction = -1;
                    spriteRenderer.flipX = true;
                }
                else if (player.gameObject.transform.position.x > transform.position.x)
                {
                    direction = 1;
                    spriteRenderer.flipX = false;
                }
                else
                {
                    direction = 0;
                }
                
                movementVec.x = (direction * speed) * Time.deltaTime;
                transform.position += movementVec;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "PlayerAttack")
            {
                StartCoroutine(TakeDamage());
            }
        }

        private IEnumerator TakeDamage()
        {
            if(--health <= 0)
            {
                Destroy(this.gameObject);
            }
            
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }
    }
}
