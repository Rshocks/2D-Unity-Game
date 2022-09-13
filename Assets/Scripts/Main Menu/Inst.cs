using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public string Tutorial;
    public string LevelOne;
    public string LevelTwo;
    public string LevelThree;
    public string gotoMain;
    public GameObject InstructionsScreen;

    public void RestartTutorial()
    {
        SceneManager.LoadScene(Tutorial);
    }

    public void OpenInstructions()
    {
        InstructionsScreen.SetActive(true);
    }

    public void CloseInstructions()
    {
        InstructionsScreen.SetActive(false);   
    }

    public void RestartLevelOne()
    {
        SceneManager.LoadScene(LevelOne);
    }

    public void RestartLevelTwo()
    {
        SceneManager.LoadScene(LevelTwo);
    }

    public void RestartLevelThree()
    {
        SceneManager.LoadScene(LevelThree);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(gotoMain);
    }
}
