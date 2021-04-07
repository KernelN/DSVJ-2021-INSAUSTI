using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LivingStarmap
{
    public class SolarSystemGenerator : MonoBehaviour
    {
        //inspector variables
        [SerializeField] Transform sun;
        [SerializeField] GameObject planetPrefab;
        [SerializeField] GameObject ringPregab;
        [SerializeField] Material[] planetsMaterials;
        [SerializeField] float scaleMultiplier;
        [SerializeField] short planetQuantity;

        //fully private variables
        const short minPlanetDistance = 28;
        const float maxPlanetDistance = minPlanetDistance * 77.78f;

        #region Event Methods
        void Start()
        {
            sun.localScale *= scaleMultiplier;
        }
        #endregion

        #region Internal Methods
        #endregion
    }
}