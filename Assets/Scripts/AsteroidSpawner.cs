using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // reference to the gameobjects that will be created
    [SerializeField] private GameObject[] asteroidPrefabs;
    // time between asteroid spawns
    [SerializeField] private float secondBtwnAsteroids = 1.5f;
    // force vector will be apply to the instantiated asteroids that randomly valued
    [SerializeField] private Vector2 forceRange;
    // time that should pass before starting to spawn asteroids
    [SerializeField] private float timer = 5;

    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        // time is passing...
        timer -= Time.deltaTime;
        // if it reaches zero or below
        if (timer <= 0)
        {
            // then start to spawn asteroids
            SpawnAsteroid();
            // to continually spawn in a determined time difference
            timer += secondBtwnAsteroids;
        }
    }

    private void SpawnAsteroid()
    {
        // random side of the phone screen where the asteroid is created
        int sideOfScreen = Random.Range(0, 4);

        // asteroid spawn point
        Vector2 spawnPoint = Vector2.zero;
        // direction where the created asteroid headed.
        Vector2 direction = Vector2.zero;

        switch (sideOfScreen)
        {

            // left of the screen
            case 0:
                // left of the screen means x = 0 in ViewPortScreen 
                spawnPoint.x = 0;
                // left of the screen means y can be between 0 and 1 between (0,0) and (0,1)
                spawnPoint.y = Random.value;
                // left of the screen means youur direction should be right-directed
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;

            // up of the screen
            case 1:
                // left of the screen means x = 0 in ViewPortScreen 
                spawnPoint.y = 1;
                // left of the screen means y can be between 0 and 1 between (0,0) and (0,1)
                spawnPoint.x = Random.value;
                // left of the screen means youur direction should be right-directed
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;

            // down of the screen
            case 2:
                // left of the screen means x = 0 in ViewPortScreen 
                spawnPoint.y = 0;
                // left of the screen means y can be between 0 and 1 between (0,0) and (0,1)
                spawnPoint.x = Random.value;
                // left of the screen means youur direction should be right-directed
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;

            // right of the screen
            case 3:
                // left of the screen means x = 0 in ViewPortScreen 
                spawnPoint.x = 1;
                // left of the screen means y can be between 0 and 1 between (0,0) and (0,1)
                spawnPoint.y = Random.value;
                // left of the screen means youur direction should be right-directed
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;

            default:
                break;
        }

        // convert ViewPort to WorldPoint 
        Vector3 worldPoint = mainCam.ViewportToWorldPoint(spawnPoint);
        worldPoint.z = 0;

        // pick a random object from array
        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        // rotate randomly the instantiated object in z axis
        Quaternion rotateRandom = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate with above settings
        GameObject asteroidInstance =  Instantiate(selectedAsteroid, worldPoint, rotateRandom);

        // Get rigidbody of what we instantiated so we can apply force 
        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

        // Random velocity for each instantiated object.
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }



}
