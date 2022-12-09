using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ViewSolarSystem()
    {
        SceneManager.LoadScene(1);
    }

    public void BuildSolarSystem()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayQuiz()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Back2()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame2()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
