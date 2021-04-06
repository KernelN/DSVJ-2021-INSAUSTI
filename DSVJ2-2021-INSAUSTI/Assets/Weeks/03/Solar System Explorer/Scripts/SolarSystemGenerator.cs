using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemGenerator : MonoBehaviour
{
    public Transform sun;
    public GameObject planet;
    public GameObject ring;

    public float scaleMultiplier;

    void Start()
    {
        sun.localScale *= scaleMultiplier;
    }
}
