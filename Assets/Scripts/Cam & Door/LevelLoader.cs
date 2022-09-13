using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string mylevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            NextLvl();
        }
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(mylevel);
    }
}
