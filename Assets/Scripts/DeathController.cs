using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField] GameObject TotalTime;
    [SerializeField] GameObject XP;

    public PlayerController playerController;
    public GameObject deathMenu;
    void Start()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Death()
    {
        deathMenu.SetActive(true);
        StartCoroutine(WaitForDeath());
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SetDeathStats()
    {
        TotalTime.GetComponent<TMPro.TMP_Text>().text = "Time Alive: " + (int)Time.time + " sec";
        XP.GetComponent<TMPro.TMP_Text>().text = "XP Gained: " + playerController.TotalXP;
    }
}
