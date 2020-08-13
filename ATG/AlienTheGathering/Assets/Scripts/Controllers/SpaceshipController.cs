using UnityEngine;
using System.Collections;
using System;
using ATG.Utilities;
using ATG.Core;
using System.IO;

namespace ATG.Controllers
{
    public class SpaceshipController : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private GameObject attackObj = default;
        private float horizontalInput = 0.0f;
        private DateTime lastAttackTime = default;
        private AudioSource attackSFX = default;
        private Vector2 clampedPosition = Vector2.zero;
        private ScreenBorderDetector borderDetector = default;

        void Start()
        {
            AudioManager.Instance.LoadSound(ref attackSFX, Path.Combine("SFX", "LaserShoot"));
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
        }

        // Update is called once per frame
        void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"))
            {
                if ((DateTime.Now - lastAttackTime).TotalMilliseconds >= 1000)
                {
                    StartCoroutine(Attack());
                }
            }

            gameObject.transform.Translate((horizontalInput * speed) * Time.deltaTime, 0.0f, 0.0f);

            if (borderDetector != null)
            {
                clampedPosition = transform.position;
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, borderDetector.leftBorder, borderDetector.rightBorder);
                transform.position = clampedPosition;
            }
        }

        IEnumerator Attack()
        {
            if (attackSFX != null)
            {
                attackSFX.volume = ATGConfig.SFXVolume;
                attackSFX.Play();
            }
            
            if (attackObj != null)
            {
                Instantiate(attackObj, transform.position, Quaternion.identity);
            }

            lastAttackTime = DateTime.Now;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
