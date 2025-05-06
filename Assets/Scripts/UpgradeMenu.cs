using JetBrains.Annotations;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject HealthAmount;
    [SerializeField] GameObject DamageAmount;
    [SerializeField] GameObject GreedAmount;
    [SerializeField] GameObject CadenceAmount;
    [SerializeField] GameObject XPAmount;

    [SerializeField] GameObject HealthPrice;
    [SerializeField] GameObject DamagePrice;
    [SerializeField] GameObject GreedPrice;
    [SerializeField] GameObject CadencePrice;


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

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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

    void SetStats()
    {
        HealthAmount.GetComponent<TMPro.TMP_Text>().text = "Health: " + playerController.Health + "/" + playerController.MaxHealth;
        DamageAmount.GetComponent<TMPro.TMP_Text>().text = "Damage: " + playerController.Damage;
        DamageAmount.GetComponent<TMPro.TMP_Text>().text = "Damage: " + Mathf.RoundToInt((float)playerController.Damage);
        GreedAmount.GetComponent<TMPro.TMP_Text>().text = "Greed: " + playerController.Greed;
        CadenceAmount.GetComponent<TMPro.TMP_Text>().text = "Cadence: " + playerController.Cadence;
        XPAmount.GetComponent<TMPro.TMP_Text>().text = "XP: " + playerController.XP;

        HealthPrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.HealthLvl;
        DamagePrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.DamageLvl;
        GreedPrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.GreedLvl;
        CadencePrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.CadenceLvl;
    }
}
