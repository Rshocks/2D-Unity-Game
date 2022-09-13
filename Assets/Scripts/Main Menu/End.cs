using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string Mainmenu;

    public void theEnd()
    {
        SceneManager.LoadScene(Mainmenu);
    }
}
