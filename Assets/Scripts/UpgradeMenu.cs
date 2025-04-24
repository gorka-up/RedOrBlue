using JetBrains.Annotations;
using System.Xml.XPath;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeMenu;
    public PlayerController playerController;
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

    private void Start()
    {
        upgradeMenu.SetActive(false);
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

    public void HealthUpgrade()
    {
        if (playerController.XP >= 100 * playerController.HealthLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.HealthLvl;
            playerController.LevelUp(1);
        }
    }

    public void DamageUpgrade()
    {
        if (playerController.XP >= 100 * playerController.DamageLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.DamageLvl;
            playerController.LevelUp(2);
        }
    }

    public void GreedUpgrade()
    {
        if (playerController.XP >= 100 * playerController.GreedLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.GreedLvl;
            playerController.LevelUp(3);
        }
    }

    public void CadenceUpgrade()
    {
        if (playerController.XP >= 100 * playerController.CadenceLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.CadenceLvl;
            playerController.LevelUp(4);
        }
    }

    public void SpeedUpgrade()
    {
        //Aquí va la mejora de velocidad para cuando se ponga la nueva velocidad
    }
}
