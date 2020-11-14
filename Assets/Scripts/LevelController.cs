using Level;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelController : MonoBehaviour {
    [SerializeField]
    private GameObject worldPrefab;

    [SerializeField]
    private GameObject groundPrefab;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject wallContainerPrefab;

    [SerializeField]
    private GameObject plantPrefab;

    [SerializeField]
    private GameObject vampirePrefab;

    [SerializeField]
    private GameObject sunPrefab;

    [SerializeField]
    private GameObject barrierPrefab;

    private LevelData levelData;
    private Transform world;

    private void Start() {
    }
    public void LoadLevel() {
        if (world != null) {
            throw new System.Exception("world already loaded");
        }

        var levelData = SessionData.currentLevelData;

        world = Instantiate(worldPrefab, Vector3.zero, Quaternion.identity, transform).transform;

        var width = levelData.tiles[0].Length;
        var height = levelData.tiles.Length;
        var offsetX = (width - 1) / 2f;
        var offsetY = (height - 1) / 2f;

        CreateGround(width, height, world);

        CreateBarrier((width + 1) / 2f, 0, true, world);
        CreateBarrier((width + 1) /-2f, 0, true, world);
        CreateBarrier(0, (height + 1) / 2f, false, world);
        CreateBarrier(0, (height + 1) /-2f, false, world);



        for (int y = 0; y < levelData.tiles.Length; y++) {
            for (int x = 0; x < levelData.tiles[y].Length; x++) {
                var tile = levelData.tiles[y][x];
                switch (tile.type) {
                    case TileType.Wall:
                        var containerId = tile.id.ToString();
                        var container = world.Find(containerId);
                        if (container == null) {
                            container = Instantiate(wallContainerPrefab, Vector3.zero, Quaternion.identity, world).transform;
                            container.name = containerId;
                        }
                        var wall = Instantiate(wallPrefab, new Vector3(x - offsetX, 1, -1 * (y - offsetY)), Quaternion.identity, container);
                        wall.GetComponent<Renderer>().material.color = Color.HSVToRGB((tile.id - 'A') / 27f, 1, 1);
                        break;
                    case TileType.Plant:
                        var plant = Instantiate(plantPrefab, new Vector3(x - offsetX, 0.25f, -1 * (y - offsetY)), Quaternion.identity, world);
                        break;
                    case TileType.Vampire:
                        var vampire = Instantiate(vampirePrefab, new Vector3(x - offsetX, 0.25f, -1 * (y - offsetY)), Quaternion.identity, world);
                        break;
                }
            }
        }

        foreach (var sunData in levelData.suns) {
            var sun = Instantiate(sunPrefab, new Vector3(0, 0, 0), Quaternion.identity, world);
            var ras = sun.GetComponent<RiseAndSet>();
            ras.radius = sunData.radius;
            ras.speed = sunData.speed;
            //sun.transform.position = new Vector3(-sunData.radius, 0, 0);
        }
    }
    public void UnloadLevel() {
        if (world == null) {
            throw new System.Exception("no world loaded");
        }
        Destroy(world.gameObject);
        world = null;
    }

    private void CreateGround(int width, int height, Transform parent) {
        var ground = Instantiate(groundPrefab, Vector3.zero, Quaternion.identity, parent);
        ground.transform.localScale = new Vector3(width, 1, height);
    }

    private void CreateBarrier(float centerX, float centerY, bool isHorizontal, Transform parent) {
        var barrier = Instantiate(barrierPrefab, new Vector3(centerX, 0, centerY), isHorizontal ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 90, 90), parent);
    }

    void Update()
    {
        
    }
}
