using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduce : MonoBehaviour
{
    private Cubix cubix;
    private GameObject bullet;
    private HashSet<GameObject> processedCubes = new HashSet<GameObject>();

    void Start()
    {
        // Get references
        cubix = FindObjectOfType<Cubix>();
        bullet = GameObject.Find("Bullet");
    }

    void OnTriggerEnter(Collider other) 
    {
        // Reset processed cubes for new collision
        processedCubes.Clear();
        
        // Start detonation chain
        Detenate(other.gameObject);

        // Reset bullet position and properties
        transform.position = bullet.GetComponent<Bullet>().originalBulletPos ;
        bullet.GetComponent<Bullet>().canShoot = true;
        bullet.GetComponent<Bullet>().chai = new Vector3();
        bullet.GetComponent<Bullet>().color = bullet.GetComponent<Bullet>().colors[UnityEngine.Random.Range(0, bullet.GetComponent<Bullet>().colors.Length)];
        bullet.GetComponent<Bullet>().mR.material.color = bullet.GetComponent<Bullet>().color;
        bullet.GetComponent<MeshRenderer>().material.color = bullet.GetComponent<Bullet>().color;
    }

    void Detenate(GameObject cube)
    {
        // Check if cube is valid and hasn't been processed
        if (cube == null || processedCubes.Contains(cube))
            return;

        // Compare colors
        Color hitColor = GetComponent<MeshRenderer>().material.color;
        MeshRenderer cubeRenderer = cube.GetComponent<MeshRenderer>();
        
        if (cubeRenderer == null || cubeRenderer.material.color != hitColor)
            return;

        // Mark as processed
        processedCubes.Add(cube);

        // Get coordinates
        Cube cubeComponent = cube.GetComponent<Cube>();
        if (cubeComponent == null)
            return;

        Vector3 coord = cubeComponent.coordinates;

        // Check all adjacent positions
        Vector3[] adjacentOffsets = new Vector3[]
        {
            Vector3.right,   // X + 1
            Vector3.left,    // X - 1
            Vector3.up,      // Y + 1
            Vector3.down,    // Y - 1
            Vector3.forward, // Z + 1
            Vector3.back     // Z - 1
        };

        foreach (Vector3 offset in adjacentOffsets)
        {
            Vector3 adjacentCoord = coord + offset;
            
            // Find adjacent cube in the list
            GameObject adjacentCube = cubix.cubes.Find(c => 
                c != null && 
                c.GetComponent<Cube>() != null &&
                Vector3.Distance(c.GetComponent<Cube>().coordinates, adjacentCoord) < 0.1f);

            if (adjacentCube != null)
            {
                Detenate(adjacentCube);
            }
        }

        // Remove and destroy the cube
        cubix.cubes.Remove(cube);
        Destroy(cube);
    }
}