using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Properties of each cube
    public Vector3 coordinates;
    public Color color;

    private Color[] colors;

    private MeshRenderer mR;

    void Start ()
    {
        colors = new Color[] {DarkenColor(Color.red), DarkenColor(Color.blue), DarkenColor(Color.green), DarkenColor(Color.white), DarkenColor(Color.magenta)};
        color = colors[Random.Range(0, colors.Length)];
        mR = GetComponent<MeshRenderer>();
        mR.material.color = color;
    }

    Color DarkenColor (Color color) 
    {
        Color newColor = color;
        newColor.r *= 0.5f;
        newColor.g *= 0.5f;
        newColor.b *= 0.5f;

        return newColor;
    }

    public void Mover (float speed)
    {
        Vector3 Rnd = new Vector3(Random.Range(0,2), Random.Range(0,2), Random.Range(0,2));
        transform.Translate(speed * Rnd);
    }
}
