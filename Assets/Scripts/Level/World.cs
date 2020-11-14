using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level {
    public class World : MonoBehaviour {
        private IEnumerable<Animator> plants {
            get {
                return GameObject.FindGameObjectsWithTag("Plant")
                    .SelectMany(plant => plant.GetComponents<Animator>());
            }
        }
    }
}
