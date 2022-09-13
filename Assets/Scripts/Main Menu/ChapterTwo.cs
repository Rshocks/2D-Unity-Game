using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterTwo : MonoBehaviour
{
    public string LevelTwo;

    public void Resume()
    {
        SceneManager.LoadScene(LevelTwo);
    }
}
