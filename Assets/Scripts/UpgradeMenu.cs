using JetBrains.Annotations;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject HealthAmount;
    [SerializeField] GameObject DamageAmount;
    [SerializeField] GameObject GreedAmount;
    [SerializeField] GameObject CadenceAmount;
    [SerializeField] GameObject SpeedAmount;
    [SerializeField] GameObject XPAmount;

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
        SetStats();
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
        SetStats();
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
        if (playerController.XP >= 100 * playerController.moveSpeedLvl && playerController.moveSpeed < 10)
        {
            playerController.moveSpeed = playerController.moveSpeed - 100 * playerController.moveSpeedLvl;
            playerController.LevelUp(5);
        }
    }

    void SetStats()
    {
        HealthAmount.GetComponent<TMPro.TMP_Text>().text = "" + playerController.MaxHealth;
        DamageAmount.GetComponent<TMPro.TMP_Text>().text = "" + playerController.Damage;
        DamageAmount.GetComponent<TMPro.TMP_Text>().text = "" + Mathf.RoundToInt((float)playerController.Damage);
        GreedAmount.GetComponent<TMPro.TMP_Text>().text = "" + playerController.Greed;
        CadenceAmount.GetComponent<TMPro.TMP_Text>().text = "" + Mathf.Round((float)playerController.Cadence);
        SpeedAmount.GetComponent<TMPro.TMP_Text>().text = "" + playerController.moveSpeed;
        XPAmount.GetComponent<TMPro.TMP_Text>().text = "" + playerController.XP;
    }
}
