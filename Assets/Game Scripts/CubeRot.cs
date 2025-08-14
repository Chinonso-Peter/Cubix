using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRot : MonoBehaviour
{
    private Vector3 chai;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> Axes = new List<Vector3> {
            Vector3.up, Vector3.right, Vector3.forward
        };
        chai = Axes[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(chai, UnityEngine.Random.Range(100, 500) * Time.deltaTime);
    }
}
