using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        Debug.Log("ola");
    }
    public void Play()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
