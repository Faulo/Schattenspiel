using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBar
{
    float size { get; set; }

    [SerializeField]
    Color color { get; set; }
}
