using UnityEngine;
using ATG.Utilities;

namespace ATG.Controllers
{
    public class CowController : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;
        private int direction = 0;
        private Vector3 movementVec = Vector3.zero;
        private ScreenBorderDetector borderDetector = default;

        void Start()
        {
            direction = new int[2] { -1, 1 }[Random.Range(0, 2)];    // Pick random direction
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
        }

        void Update()
        {
            if (transform.position.x >= borderDetector.rightBorder)
            {
                direction = -1;
            }
            else if (transform.position.x <= borderDetector.leftBorder)
            {
                direction = 1;
            }

            movementVec.x = (direction * speed) * Time.deltaTime;
            transform.position += movementVec;
        }
    }
}
