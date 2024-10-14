using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Driver : MonoBehaviour
{
   [SerializeField] float steerSpeed = 0.1f;
   [SerializeField] float moveSpeed = 7f;
   [SerializeField] float slowSpeed = 5f;
   [SerializeField] float boostSpeed = 13f;
   
    void Update()
    {
        float streerAmont = Input.GetAxis("Horizontal") * -steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, streerAmont);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      moveSpeed = slowSpeed;   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            // Debug.Log("BOosted");
            moveSpeed = boostSpeed;
        }
    }
}
