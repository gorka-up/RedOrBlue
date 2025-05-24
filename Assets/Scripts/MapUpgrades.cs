using UnityEngine;
using System.Collections;

public class MapUpgrades : MonoBehaviour
{
    [SerializeField] int UpgradeStat;
    [SerializeField] Transform player;
    public PlayerController playerController;

    public bool respawning = false;
    public RespawnManager respawnManager;

    private WeaponController weaponController;

    private void Start()
    {
        GameObject foundPlayer = GameObject.FindWithTag("Player");
        weaponController = player.GetComponentInChildren<WeaponController>();
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (respawning)
        {
            return;
        }
        else
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < 0.8 && Input.GetKey(KeyCode.E))
            {
                if (UpgradeStat == 2 && weaponController.mode == true)
                {
                    UpgradeStat = 6; 
                }
                if (UpgradeStat == 4 && weaponController.mode == true)
                {
                    UpgradeStat = 7;
                }
                playerController.LevelUp(UpgradeStat);
                gameObject.SetActive(false);
                respawning = true;
                respawnManager.StartCoroutine(respawnManager.Respawn(gameObject));
            }
        }
    }
}
