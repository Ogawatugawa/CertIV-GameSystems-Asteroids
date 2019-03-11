using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10f;
        private Rigidbody2D rb;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Fire(Vector3 direction)
        {

        }
    }

}
