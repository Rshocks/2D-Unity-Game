using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterThree : MonoBehaviour
{
    public string LevelThree;

    public void Resume()
    {
        SceneManager.LoadScene(LevelThree);
    }
}
