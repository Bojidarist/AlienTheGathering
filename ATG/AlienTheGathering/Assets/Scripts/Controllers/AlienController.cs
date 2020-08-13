using UnityEngine;
using System.IO;
using System.Collections;
using ATG.Core;
using System;
using ATG.Utilities;

namespace ATG.Controllers
{
    public class AlienController : MonoBehaviour
    {
        [SerializeField] private int health = 10;
        [SerializeField] private float speed = 0.0f;
        [SerializeField] private float jumpForce = 0.0f;
        [SerializeField] private Vector3 attackSpritePos = Vector3.zero;
        [SerializeField] private GameObject attackSprite = default;
        private float horizontalInput = 0.0f;
        private float verticalInput = 0.0f;
        private Vector3 movementVector = Vector3.zero;
        private Vector2 jumpVector = Vector2.zero;
        private Rigidbody2D rb = default;
        private bool isOnGround = false;
        private int attackDirection = 1;
        private AudioSource attackSFX = default;
        private SpriteRenderer spriteRenderer = default;
        private bool isAttacking = false;
        private bool isTakingDamage = false;
        private DateTime lastTimeAttacked = default;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            AudioManager.Instance.LoadSound(ref attackSFX, Path.Combine("SFX", "Attack"));
        }

        // Update is called once per frame
        void Update()
        {
            if (isTakingDamage && (DateTime.Now - lastTimeAttacked).TotalMilliseconds >= 1000)
            {
                StartCoroutine(TakeDamage());
            }
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            movementVector.x = horizontalInput;

            transform.position += (movementVector * speed) * Time.deltaTime;

            if (verticalInput >= 0.5f && isOnGround)
            {
                isOnGround = false;
                jumpVector.y = jumpForce;
                rb.AddForce(jumpVector, ForceMode2D.Impulse);
            }

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"))
            {
                if(horizontalInput < 0)
                {
                    attackDirection = -1;
                }
                else if(horizontalInput > 0)
                {
                    attackDirection = 1;
                }

                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            if (attackSFX != null)
            {
                attackSFX.volume = ATGConfig.SFXVolume;
                attackSFX.Play();
            }

            attackSprite.transform.position = transform.position + (attackSpritePos * attackDirection);
            Vector3 flipVec = attackSprite.transform.localScale;
            flipVec.x = -attackDirection;
            attackSprite.transform.localScale = flipVec;

            isAttacking = true;
            attackSprite.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            attackSprite.gameObject.SetActive(false);
            isAttacking = false;
        }

        private IEnumerator TakeDamage()
        {
            if(--health <= 0)
            {
                Destroy(this.gameObject);
            }
            
            lastTimeAttacked = DateTime.Now;
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "EnemyAttack" && !isAttacking)
            {
                isTakingDamage = true;
            } 
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.tag == "EnemyAttack")
            {
                isTakingDamage = false;
            } 
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isOnGround = false;
            }
        }
    }
}