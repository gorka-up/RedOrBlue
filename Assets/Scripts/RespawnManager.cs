using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] float respawnTimer;

    public IEnumerator Respawn(GameObject obj)
    {
        yield return new WaitForSeconds(respawnTimer);

        obj.SetActive(true);
        obj.GetComponent<MapUpgrades>().respawning = false;
    }

}
