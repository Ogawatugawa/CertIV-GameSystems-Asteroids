using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // This script will be attached to any object that will be able move by screenwrapping
    public class ScreenWrap : MonoBehaviour
    {
        public float padding = 3f; // Padding around the screen for screenwrapping
        public Color debugColor = Color.blue; // The colour of the gizmos the attached object will be drawing

        private SpriteRenderer rend; // Reference to sprite renderer component

        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
        }

        // A function to draw the boundaries of our Bounds
        private void OnDrawGizmos()
        {
            Bounds camBounds = Camera.main.GetBounds(padding);
            Gizmos.color = debugColor;
            Gizmos.DrawWireCube(camBounds.center, camBounds.size);
        }

        void UpdatePosition()
        {
            // Create new Bounds called 'camBounds' which is the space of the projection of the camera in this scene tagged 'Main'
            Bounds camBounds = Camera.main.GetBounds(padding);
            // Create a new Vector3 'pos' at the position of the attached object
            Vector3 pos = transform.position;
            // Create new Vector3 'min' & 'max' at the edges of our bounds
            Vector3 min = camBounds.min;
            Vector3 max = camBounds.max;

            // Create the checks for whether the character has hit the edge of the bounds
            if (pos.x < min.x)
            {
                pos.x = max.x;
            }

            if (pos.x > max.x)
            {
                pos.x = min.x;
            }

            if (pos.y < min.y)
            {
                pos.y = max.y;
            }

            if (pos.y > max.y)
            {
                pos.y = min.y;
            }

            //Update the position of the object, possibly based on whether they've moved based on the above
            transform.position = pos;
        }
        void Start()
        {

        }
        void Update()
        {
            UpdatePosition();
        }
    }
}

