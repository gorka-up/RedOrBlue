using JetBrains.Annotations;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenu;

    public void Pause()
    { 
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Play();
            }
            else
            {
                Pause();
            }
        }
    }
}
