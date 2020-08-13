using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAttackController : MonoBehaviour
{
    private float speed = -2.0f;

    void Update()
    {
        gameObject.transform.Translate(0.0f, speed * Time.deltaTime, 0.0f); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cow")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }        
    }
}
