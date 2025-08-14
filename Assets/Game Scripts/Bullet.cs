using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 originalBulletPos;
    public Vector3 chai;
    public bool canShoot = true;
    public Color color;
    public GameObject porque;
    public Color[] colors;
    public MeshRenderer mR;
    private Cube cube;

    private Vector3 GunBullet;
    private Vector3 GunCam;

    [SerializeField] private GameObject bull;
    void Start ()
    {
        GunBullet = new Vector3 (0.002f, -0.02f, -1.4f);
        GunCam = new Vector3 (-0.005714f, -0.507143f, -1.05f);
        bullet = GameObject.FindGameObjectWithTag("bullet");
        transform.position = Camera.main.transform.position + GunCam;
        bullet.transform.position = transform.position - GunBullet;
        chai = new Vector3();
        originalBulletPos = bullet.transform.position;
        colors = new Color[] {DarkenColor(Color.red), DarkenColor(Color.blue), DarkenColor(Color.green), DarkenColor(Color.white), DarkenColor(Color.magenta)};
        color = colors[Random.Range(0, colors.Length)];
        mR = GetComponent<MeshRenderer>();
        mR.material.color = color;
        bullet.GetComponent<MeshRenderer>().material.color = color;

    }
    void Update ()
    {
        if (Cubix.gameOn) {
            bullet.transform.position += chai* porque.GetComponent<Cubix>().Level;
            
            if (bullet.transform.position.z >= 10 * porque.GetComponent<Cubix>().Level) 
            {
                bullet.transform.position = originalBulletPos;
                canShoot = true;
                chai = new Vector3();
                color = colors[Random.Range(0, colors.Length)];
                mR.material.color = color;
                bullet.GetComponent<MeshRenderer>().material.color = color;
            }

            Debug.DrawRay(bullet.transform.position, Vector3.forward*500, Color.black);
        }
        
    }

    void OnMouseDown() {
        if (canShoot && Cubix.gameOn)
        {
            chai = Vector3.forward;
            canShoot = false;
            bull.GetComponent<Cubix>().NumberOfShots--; 
            MouseCubixRotation.isDragging = false;
        }
    }

    Color DarkenColor (Color color) 
    {
        Color newColor = color;
        newColor.r *= 0.5f;
        newColor.g *= 0.5f;
        newColor.b *= 0.5f;

        return newColor;
    }
}
