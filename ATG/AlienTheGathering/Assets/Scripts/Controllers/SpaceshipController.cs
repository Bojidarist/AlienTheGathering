using UnityEngine;

namespace ATG.Controllers
{
    public class SpaceshipController : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        private float horizontalInput = 0.0f;

        // Update is called once per frame
        void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            gameObject.transform.Translate((horizontalInput * speed) * Time.fixedDeltaTime, 0.0f, 0.0f);
        }
    }
}
