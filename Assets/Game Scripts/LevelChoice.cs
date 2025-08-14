using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelChoice : MonoBehaviour
{
    public void L1 () 
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);
    }
    public void L2 () 
    {
        Debug.Log("No L2 yet");
    }
    public void L3 () 
    {
        Debug.Log("No L3 yet");
    }
}
