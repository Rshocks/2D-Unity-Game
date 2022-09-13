using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelOne;
    public string Tutorial;

    public GameObject InstScreen;
    public GameObject OptionsScreen;
    public GameObject ChapOne;

    public void StartTutorial()
    {
        SceneManager.LoadScene(Tutorial);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelOne);
    }

    public void OpenChap1()
    {
        InstScreen.SetActive(false);
        ChapOne.SetActive(true);
    }

    public void OpenInst()
    {
        InstScreen.SetActive(true);
    }

    public void CloseInst()
    {
        InstScreen.SetActive(false);   
    }

    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
