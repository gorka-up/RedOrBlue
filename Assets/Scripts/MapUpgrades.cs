using UnityEngine;
using System.Collections;

public class MapUpgrades : MonoBehaviour
{
    [SerializeField] int UpgradeStat;
    [SerializeField] Transform player;
    public PlayerController playerController;

    public bool respawning = false;
    public RespawnManager respawnManager;

    // Update is called once per frame
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
                playerController.LevelUp(UpgradeStat);
                gameObject.SetActive(false);
                respawning = true;
                respawnManager.StartCoroutine(respawnManager.Respawn(gameObject));
            }
        }
    }
}
