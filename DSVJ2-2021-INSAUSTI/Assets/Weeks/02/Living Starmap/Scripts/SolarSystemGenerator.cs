using System.Collections.Generic;
using UnityEngine;

namespace LivingStarmap
{
    public class SolarSystemGenerator : MonoBehaviour
    {
        public GameObject planetPrefab; //moon or planet
        
        [SerializeField] Transform sun;
        [SerializeField] List<Material> planetMaterials;
        [SerializeField] Material moonMaterial; //also asteroid material
        [SerializeField] float scaleMultiplier;
        [SerializeField] short planetQuantity;

        //fully private variables
        const short minPlanetDistance = 28;
        const float maxPlanetDistance = minPlanetDistance * 77.78f;

        #region Event Methods
        void Start()
        {
            sun.localScale *= scaleMultiplier;
            for (int i = 0; i < Random.Range(3, planetQuantity); i++)
            {
                GeneratePlanet();
            }
        }
        #endregion

        #region Internal Methods
        void GeneratePlanet()
        {
            GameObject planet = Instantiate(planetPrefab);
            planet.GetComponent<MeshRenderer>().material = planetMaterials[Random.Range(0, planetMaterials.Count)];
            planet.AddComponent<Planet>().SetPlanet(sun); //set planet, with the sun as astral parent
        }
        #endregion
    }
}