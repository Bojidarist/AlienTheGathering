using UnityEngine;

namespace ATG.Controllers
{
    public class NinjaController : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private AlienController player = default;
        private int direction = 0;   // This value will be multiplied on movement
        private Vector3 movementVec = Vector3.zero;

        void Start()
        {
            player = GetComponent<AlienController>();
        }

        void Update()
        {
            if (player != null)
            {
                if(player.gameObject.transform.position.x < transform.position.x)
                {
                    direction = -1;
                }
                else if (player.gameObject.transform.position.x > transform.position.x)
                {
                    direction = 1;
                }
                else 
                {
                    direction = 0;
                }
                
                movementVec.x = (direction * speed) * Time.deltaTime;
                transform.position += movementVec;
            }
        }
    }
}
