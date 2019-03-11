using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidManager : MonoBehaviour
    {
        public GameObject[] asteroidPrefabs;
        public float maxVelocity = 3f;
        public float spawnRate = 1f;
        public float spawnPadding = 2f;

        // Create a colour to draw the wire sphere in Unity's scene viewer
        public Color debugColor = Color.cyan;

        public void Spawn(GameObject prefab, Vector3 position)
        {
            // Randomise a rotation for the asteroid
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // Spawn random asteroid at random position and default Quaternion rotation
            GameObject asteroid = Instantiate(prefab, position, randomRotation, transform);

            // Get Rigidbody2D from the asteroid
            Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();

            // Apply random force to the attached Rigidbody2D
            Vector2 randomforce = Random.insideUnitCircle * maxVelocity;
             rb.AddForce(randomforce, ForceMode2D.Impulse);
        }

        // Function to spawn a random asteroid (fromm the asteroidPrefabs array) at a random position
        void SpawnLoop()
        {
            Bounds cambounds = Camera.main.GetBounds(spawnPadding);
            Vector2 randomPos = cambounds.GetRandomPosOnBounds();

            // !!!We ain't using this anymore!!!Generate random position inside a sphere of radius spawnPadding
            // Vector3 randomPos = Random.insideUnitSphere * spawnPadding;
            
            // Generate a random index number somewhere between 0 and the number of objects in the asteroidPrefabs array
            int randomIndex = Random.Range(0, asteroidPrefabs.Length);

            // Generate a random asteroid from the array using the index we generated above
            GameObject randomAsteroid = asteroidPrefabs[randomIndex];

            // Spawn the random asteroid using the random position we generated above
            Spawn(randomAsteroid, randomPos);
        }
        void Start()
        {
            InvokeRepeating("SpawnLoop", 0f, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            // Call the camera bounds 
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);
            // Picks the colour for the drawn gizmos based on the 
            Gizmos.color = debugColor;
            // Draws a wire sphere at the transform position of the attached object, with radius of SpawnPadding
            Gizmos.DrawWireCube(camBounds.center, camBounds.size);
        }
    }
}

