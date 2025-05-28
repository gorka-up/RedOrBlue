using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject creditsMenu1;
    [SerializeField] GameObject creditsMenu2;

    private void Start()
    {
        creditsMenu1.SetActive(false);
        creditsMenu2.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
