using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level {
    public class Sun {
        public float radius { get; private set; }
        public int angle { get; private set; }
        public float speed { get; private set; }
        public Sun(float radius, int angle, float speed) {
            this.radius = radius;
            this.angle = angle;
            this.speed = speed;
        }
    }
}