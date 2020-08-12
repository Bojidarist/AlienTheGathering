using UnityEngine;

namespace ATG.Controllers
{
    public class CowController : MonoBehaviour
    {
        [SerializeField] private GameObject ground = null;
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float turnbackMargin = 1.0f;
        private int direction = 0;
        private Vector3 movementVec = Vector3.zero;
        private float groundStartX = 0.0f;
        private float groundEndX = 0.0f;
        private RectTransform groundRect = default;

        void Start()
        {
            groundRect = ground.GetComponent<RectTransform>();
            direction = new int[2] { -1, 1 }[Random.Range(0,2)];    // Pick random direction
        }

        void Update()
        {
            if(ground != null)
            {
                groundStartX = ground.transform.position.x - ground.transform.localScale.x + turnbackMargin;
                groundEndX = ground.transform.position.x + ground.transform.localScale.x - turnbackMargin;

                if (transform.position.x >= groundEndX)
                {
                    direction = -1;
                }
                else if(transform.position.x <= groundStartX){
                    direction = 1;
                }

                movementVec.x = (direction * speed) * Time.deltaTime;
                transform.position += movementVec;
            }
        }
    }
}
