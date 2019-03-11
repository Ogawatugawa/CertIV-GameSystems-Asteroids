using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 10f;
        public float rotationSpeed = 360f;
        private Rigidbody2D rb;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey (KeyCode.W))
            {
                rb.AddForce(transform.up * movementSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.up * movementSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.rotation -= rotationSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.rotation += rotationSpeed * Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("A COLLISION HAS OCCURRED");
        }
    }

}