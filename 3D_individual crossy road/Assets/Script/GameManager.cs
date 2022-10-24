using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject grass;
    [SerializeField] GameObject road;
    [SerializeField] GameObject panelGameOver;
    
    [SerializeField] int extend = 7;
    [SerializeField] int frontDistance = 10;
    [SerializeField] int backDistance = -5; // Posisi grass dan player
    [SerializeField] int maxSameTerrainRandom = 3; // Posisi grass dan player

    Dictionary<int, TerrainBlock> map = new Dictionary<int, TerrainBlock>(50);
    TMP_Text gameOverText;

    private void Start() {
        
        // Setup panel Game Over
        panelGameOver.SetActive(false);
        gameOverText = panelGameOver.GetComponentInChildren<TMP_Text>();

        for (int z = backDistance; z <= 0; z++)
        {
            CreateTerrain(grass, z);
        
        }

        for (int z = 1; z <= frontDistance; z++)
        {
            var prefab = GetNextRandomTerrainInPrefab(z);

            // Intentiate bloknya
            CreateTerrain(prefab, z);

        }
        foreach (var pos in Tree.AllPositions)
        {
            Debug.Log(pos); 
        }

        player.Setup(backDistance, extend);
    }

    private int playerLastMaxTravel;
    private void Update() {
        // Cek player
        if (player.isDie && panelGameOver.activeInHierarchy == false)
            StartCoroutine(GameOver());

        // Infinite Terrain
        if (player.MaxTravel == playerLastMaxTravel)
            return;

        playerLastMaxTravel = player.MaxTravel;

        // Bikin Terrain ke depan
        var randomTbPrefab = GetNextRandomTerrainInPrefab(player.MaxTravel + frontDistance);
        CreateTerrain(randomTbPrefab, player.MaxTravel+frontDistance);

        // Hapus Terrain di belakang
        // var lastTb = map[player.MaxTravel - 1 + backDistance];

        TerrainBlock lastTb = map[player.MaxTravel + frontDistance];
        int lastPost = player.MaxTravel;
        foreach (var (pos, tb) in map)
        {
            if (pos < lastPost)
            {
                lastPost = pos;
                lastTb = tb;
            }
        }

        // Hapus dari daftar list map
        map.Remove(player.MaxTravel - 1 + backDistance);

        // Hilangkan gameObject pada posisi tertentu {player.MaxTravel - 1 + backDistance}
        Destroy(lastTb.gameObject);

        // Setup agar tidak bisa bergerak ke belakang
        player.Setup(player.MaxTravel + backDistance, extend);

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);

        gameOverText.text = "Your Score \n" + player.MaxTravel;
        panelGameOver.SetActive(true);
    }

    private void CreateTerrain(GameObject prefab, int zPos){

        var go = Instantiate(prefab, new Vector3(0,0,zPos), Quaternion.identity);
        var tb = go.GetComponent<TerrainBlock>();
        tb.Build(extend);

        map.Add(zPos, tb);
        
    }

    private GameObject GetNextRandomTerrainInPrefab(int pos){

        bool IsUniform = true;
        var tbRef = map[pos-1];
        for (int i = 2; i <= maxSameTerrainRandom; i++)
        {
            if (map[pos-1].GetType() != tbRef.GetType())
            {
                IsUniform = false;
                break;
            }  
        }

        if (IsUniform)
        {
            if(tbRef is Grass)
                return road;
            else
                return grass;
        }
        // Penentu terrainblok dengan probabilitas 50%
        return Random.value > 0.5f ? road : grass;
        
    }
    
}
