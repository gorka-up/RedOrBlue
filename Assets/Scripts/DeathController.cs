using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField] GameObject TotalTime;
    [SerializeField] GameObject XP;

    public PlayerController playerController;
    public GameObject deathMenu;
    float startingTime;

    int minutos;
    int segundos;
    string segundosBonito;
    void Start()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1.0f;
        startingTime = Time.time;
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
        minutos = (int)((Time.time - startingTime) / 60);
        segundos = (int)((Time.time - startingTime) % 60);
        segundosBonito = (segundos > 9) ?segundos.ToString():"0" + segundos;
        TotalTime.GetComponent<TMPro.TMP_Text>().text = "Time Alive: " + minutos + ":" + segundosBonito;
        XP.GetComponent<TMPro.TMP_Text>().text = "XP Gained: " + playerController.TotalXP;
    }
}
