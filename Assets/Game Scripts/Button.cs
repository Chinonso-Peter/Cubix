using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject FrontText;
    public GameObject LevelText;
    public void Clicker()
    {
        FrontText.SetActive(false);
        LevelText.SetActive(true);
    }

    public void Back ()
    {
        LevelText.SetActive(false);
        FrontText.SetActive(true);
    }
}
