using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] GameObject eaglePrefab;
    [SerializeField] int spawnZpos = 7;
    [SerializeField] Player player;
    [SerializeField] float timeOut = 20f;

    [SerializeField] float timer = 0;
    int playerLastMxTravel = 0;

    private void SpawnEagle(){
        player.enabled = false;
        var post = new Vector3(player.transform.position.x, 1, player.CurrentLevel + spawnZpos);
        var rotate = Quaternion.Euler(0, 180, 0);
        var eagleObjet = Instantiate(eaglePrefab, post, rotate);
        var eagle = eagleObjet.GetComponent<Eagle>();
        eagle.SetupTarget(player);

    }

    private void Update() {
        // jika player bergerak
        if (player.MaxTravel != playerLastMxTravel)
        {
            // reset timer
            timer=0;
            playerLastMxTravel = player.MaxTravel;
            return;
        }

        // jalankan timer jika AFK
        if (timer < timeOut)
        {
            timer += Time.deltaTime;
            return;
        }

        // Timeout tercapai player die
        if (player.IsJump()==false && player.isDie == false)
            SpawnEagle();

    }
}
