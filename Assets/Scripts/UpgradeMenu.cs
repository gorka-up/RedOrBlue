using JetBrains.Annotations;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject HealthAmount;
    [SerializeField] GameObject GreedAmount;
    [SerializeField] GameObject XPAmount;

    [SerializeField] GameObject Red_DamageAmount;
    [SerializeField] GameObject Red_CadenceAmount;

    [SerializeField] GameObject Blue_DamageAmount;
    [SerializeField] GameObject Blue_CadenceAmount;

    [SerializeField] GameObject HealthPrice;
    [SerializeField] GameObject GreedPrice;

    [SerializeField] GameObject Red_DamagePrice;
    [SerializeField] GameObject Red_CadencePrice;

    [SerializeField] GameObject Blue_DamagePrice;
    [SerializeField] GameObject Blue_CadencePrice;


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

    public void RedDamageUpgrade()
    {
        if (playerController.XP >= 100 * playerController.Red_DamageLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.Red_DamageLvl;
            playerController.LevelUp(2);
        }
    }

    public void BlueDamageUpgrade()
    {
        if (playerController.XP >= 100 * playerController.Blue_DamageLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.Blue_DamageLvl;
            playerController.LevelUp(6);
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

    public void RedCadenceUpgrade()
    {
        if (playerController.XP >= 100 * playerController.Red_CadenceLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.Red_CadenceLvl;
            playerController.LevelUp(4);
        }
    }

    public void BlueCadenceUpgrade()
    {
        if (playerController.XP >= 100 * playerController.Blue_CadenceLvl)
        {
            playerController.XP = playerController.XP - 100 * playerController.Blue_CadenceLvl;
            playerController.LevelUp(7);
        }
    }

    void SetStats()
    {
        HealthAmount.GetComponent<TMPro.TMP_Text>().text = "Health: " + playerController.Health + "/" + playerController.MaxHealth;
        GreedAmount.GetComponent<TMPro.TMP_Text>().text = "Greed: " + playerController.Greed;

        Red_DamageAmount.GetComponent<TMPro.TMP_Text>().text = "Red Damage: " + playerController.Red_Damage;
        Red_DamageAmount.GetComponent<TMPro.TMP_Text>().text = "Red Damage: " + Mathf.RoundToInt((float)playerController.Red_Damage);
        Red_CadenceAmount.GetComponent<TMPro.TMP_Text>().text = "Red Cadence: " + playerController.Red_Cadence;
        Red_CadenceAmount.GetComponent<TMPro.TMP_Text>().text = "Red Cadence: " + Mathf.RoundToInt((float)playerController.Red_Cadence);

        Blue_DamageAmount.GetComponent<TMPro.TMP_Text>().text = "Blue Damage: " + playerController.Blue_Damage;
        Blue_DamageAmount.GetComponent<TMPro.TMP_Text>().text = "Blue Damage: " + Mathf.RoundToInt((float)playerController.Blue_Damage);
        Blue_CadenceAmount.GetComponent<TMPro.TMP_Text>().text = "Blue Cadence: " + playerController.Blue_Cadence;
        Blue_CadenceAmount.GetComponent<TMPro.TMP_Text>().text = "Blue Cadence: " + Mathf.RoundToInt((float)playerController.Blue_Cadence);
        
        XPAmount.GetComponent<TMPro.TMP_Text>().text = "XP: " + playerController.XP;

        HealthPrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.HealthLvl;
        GreedPrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.GreedLvl;

        Red_DamagePrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.Red_DamageLvl;
        Red_CadencePrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.Red_CadenceLvl;

        Blue_DamagePrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.Red_DamageLvl;
        Blue_CadencePrice.GetComponent<TMPro.TMP_Text>().text = "" + 100 * playerController.Red_CadenceLvl;
    }
}
