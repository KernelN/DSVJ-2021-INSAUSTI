using System.Collections.Generic;
using UnityEngine;

namespace LivingStarmap
{
    public class SolarSystemGenerator : MonoBehaviour
    {
        [SerializeField] Transform sun;
        [SerializeField] GameObject planetoidPrefab; //moon or planet
        [SerializeField] GameObject ringPrefab; //moon or planet
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
            Planet.moonMaterial = moonMaterial;
            Planet.prefabMoon = planetoidPrefab;
            Planet.prefabRing = ringPrefab;
            for (int i = 0; i < Random.Range(3, planetQuantity); i++)
            {
                GeneratePlanet();
            }
        }
        #endregion

        #region Internal Methods
        void GeneratePlanet()
        {
            GameObject planet = Instantiate(planetoidPrefab);
            planet.transform.SetParent(transform);
            planet.name = "Planet" + (transform.childCount - 1); //minus 1 to not count the sun
            planet.GetComponent<MeshRenderer>().material = planetMaterials[Random.Range(0, planetMaterials.Count)];
            planet.AddComponent<Planet>().astralParent = sun; //set planet, with the sun as astral parent
        }
        #endregion
    }
}