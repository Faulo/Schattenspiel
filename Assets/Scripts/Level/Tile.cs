using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level {
    public class Tile {
        public TileType type {
            get; private set;
        }
        public char id {
            get; private set;
        }
        public Tile(TileType type, char id) {
            this.type = type;
            this.id = id;
        }
    }
}
