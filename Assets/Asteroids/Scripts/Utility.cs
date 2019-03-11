using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // Making this a static class is how we make it an extension method, which is what our Utility script is
    public static class Utility
    {
        public static Vector3 GetRandomPosOnBounds(this Bounds bounds)
        {
            Vector3 result = Vector3.zero; // Result to return at the end of this function
            // We'll abbreviate the variable names for bounds.min and bounds.max
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;
            // The below bools are just abbreviated here in the variables section, the > symbol turns the whole sequence after the = into a condition
            bool topOrBottom = Random.Range(0, 2) > 0; // 50% chance this will run bool top or bool right
            bool top = Random.Range(0, 2) > 0; // 50% chance it'll be top or bottom
            bool right = Random.Range(0, 2) > 0; // 50% chance it's left or right

            // Run top?
            if (topOrBottom)
            {
                result.x = Random.Range(min.x, max.x);
                // The below is a ternary operator, it's basically a condensed version of a single, returning if statement
                // The format is: if statement <?> then <method> else <:> <otherMethod> 
                result.y = top ? max.y : min.y;
            }

            // Run right?
            else
            {
                result.x = right ? max.x : min.x;
                result.y = Random.Range(min.y, max.y);
            }
            return result;
        }

        public static Bounds GetBounds(this Camera cam, float padding = 1f)
        {
            // Define two floats for our camera dimensions
            float camHeight, camWidth;
            // Create the vector 3 with the position our camera called 'camPos'
            Vector3 camPos = cam.transform.position;
            // Calculate the height and width of our camera
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            // Apply padding
            camHeight += padding;
            camWidth += padding;
            // Create the camera bounds using the information we wrote above
            return new Bounds(camPos, new Vector3(camWidth, camHeight, 100));
        }
    }
}

