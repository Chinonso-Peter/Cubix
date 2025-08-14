using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNS : MonoBehaviour
{
    public GameObject rub;
    public void Replay ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit ()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void PauseGame ()
    {
        Cubix.gameOn = false;
        rub.GetComponent<Cubix>().panel(true);
    }
    public void ResumeGame ()
    {
        Cubix.gameOn = true;
        rub.GetComponent<Cubix>().panel(false);
    }
}
