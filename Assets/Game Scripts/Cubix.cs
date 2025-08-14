using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cubix : MonoBehaviour
{
    public GameObject cube;
    public TextMeshProUGUI Timer;
    public GameObject winPanel;
    public GameObject loosePanel;
    public GameObject pausePanel;
    public static bool gameOn;
    public GameObject Camera;
    public List<GameObject> cubes = new List<GameObject>();
    public int Level;
    public int NumberOfShots;
    public float ShotTime;
    public Vector3 chaim;

    private BoxCollider boxCollider;

    void Awake()
    {
        Level = PlayerPrefs.GetInt("Level", 1);

        Debug.Log(Level);
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOn = true;
        boxCollider = cube.GetComponent<BoxCollider>();
        NumberOfShots = (int)(10f * (float)GoldenRatioFunction(Level * 2));
        ShotTime = 60 * GoldenRatioFunction(Level) * 3;
        int numberOfDimension = 3 * Level;

        float size = boxCollider.size.x * (float)numberOfDimension * 0.5f;
        chaim = new Vector3(size, size / 2.0f, size + 2 * Level);
        transform.position = chaim;
        Camera.transform.position = new Vector3(chaim.x + ((1.1f * Level) - ((Level * 7.8f) / 7)), chaim.y + ((2.25f * Level) - ((Level * 10.1f) / 7)), chaim.z - (13.85f * Level));

        for (int i = 0; i < numberOfDimension; i += (int)boxCollider.size.x)
        {
            for (int j = 0; j < numberOfDimension; j += (int)boxCollider.size.x)
            {
                for (int k = 0; k < numberOfDimension; k += (int)boxCollider.size.x)
                {
                    GameObject cube1 = Instantiate(cube, new Vector3(i, j, k), transform.rotation);
                    cube1.GetComponent<Cube>().coordinates = new Vector3(cube1.transform.position.x, cube1.transform.position.y, cube1.transform.position.z);
                    cube1.transform.SetParent(transform);
                    cubes.Add(cube1);
                    cube1.name = "Cube " + Convert.ToString(cube1.GetComponent<Cube>().coordinates.x) + Convert.ToString(cube1.GetComponent<Cube>().coordinates.y) + Convert.ToString(cube1.GetComponent<Cube>().coordinates.z);
                }
            }
        }
    }

    void Update()
    {
        if (gameOn)
        {
            Timer.text = $"{Math.Round(ShotTime)}:00";
            ShotTime -= Time.deltaTime;
            GameOver();
        }
    }

    float GoldenRatioFunction(int n)
    {
        float sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += (float)(1 / Math.Pow(2, i));
        }
        return sum;
    }

    public void GoNext()
    {
        Level++;
        if (Level > 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            PlayerPrefs.SetInt("Level", Level);
            SceneManager.LoadScene(1); // Reload current scene for Levels 1-3
        }
    }

    public void panel(bool t)
    {
        pausePanel.SetActive(t);
    }

    public void GameOver()
    {
        GameObject[] GodAbeg = GameObject.FindGameObjectsWithTag("cube");
        if (ShotTime >= 0 && GodAbeg.Length == 0)
        {
            if (Level <= 3)
            {
                Debug.Log("You won");
                StartCoroutine(Sec(15));
                winPanel.SetActive(true);
                PlayerPrefs.SetInt("Level", Level + 1);
                StartCoroutine(Sec(60));
                GoNext();
                gameOn = false;
            }
            else
            {
                PlayerPrefs.SetInt("Level", 0);
                SceneManager.LoadScene(0);
            }
        }
        else if (ShotTime <= 0 && GodAbeg.Length != 0)
        {
            Debug.Log("You lost");
            StartCoroutine(Sec(15));
            loosePanel.SetActive(true);
            gameOn = false;
        }
    }

    IEnumerator Sec(int secs)
    {
        yield return new WaitForSeconds(secs);
    }
}
