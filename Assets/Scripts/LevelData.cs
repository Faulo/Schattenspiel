using Level;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelData
{
    [JsonProperty]
    public string _title {
        set {
            title = value;
        }
    }

    public string title { get; private set; }

        [JsonProperty]
    public Hashtable[] _suns {
        set {
            suns = new Sun[value.Length];
            for (int i = 0; i < value.Length; i++) {
                suns[i] = new Sun(float.Parse(value[i]["radius"].ToString()), int.Parse(value[i]["angle"].ToString()), float.Parse(value[i]["speed"].ToString()));
            }
        }
    }
    public Sun[] suns {
        get;
        private set;
    }

    [JsonProperty]
    public string[] _tiles {
        set {
            tiles = new Tile[value.Length][];
            for (int i = 0; i < value.Length; i++) {
                tiles[i] = new Tile[value[i].Length];
                for (int j = 0; j < value[i].Length; j++) {
                    Tile tile;
                    switch (value[i][j]) {
                        case ' ':
                            tile = new Tile(TileType.Air, '\0');
                            break;
                        case '1':
                            tile = new Tile(TileType.Plant, '\0');
                            break;
                        case '2':
                            tile = new Tile(TileType.Vampire, '\0');
                            break;
                        default:
                            tile = new Tile(TileType.Wall, value[i][j]);
                            break;
                    }
                    tiles[i][j] = tile;
                }
            }
        }
    }
    public Tile[][] tiles {
        get; private set;
    }
    public int flowerCount {
        get {
            return tiles
                .SelectMany(row => row)
                .Where(tile => tile.type == TileType.Plant)
                .Count();
        }
    }
    public int vampireCount {
        get {
            return tiles
                .SelectMany(row => row)
                .Where(tile => tile.type == TileType.Vampire)
                .Count();
        }
    }
}
