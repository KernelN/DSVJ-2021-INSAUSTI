using UnityEngine;

namespace LivingStarmap
{
    class Planet : Planetoid
    {
        enum PlanetType { LONER, MOON, RING };
        [SerializeField] PlanetType type;
        [SerializeField] GameObject prefab;
        //[SerializeField] GameObject prefabMoon;
        [SerializeField] GameObject prefabRing;


        #region Constructors
        public void SetPlanet(Transform parent)
        {
            this.astralParent = parent;
            SelectRandomType();
            GenerateLocalTransform(false); //generate pos & scale as a planet
            GenerateOrbit();
            GenerateRotation();
        }
        void GenerateMoon()
        {
            //GameObject moon;
            //size * 3.6
            //size range between 0.2 & 0.3
        }
        void SelectRandomType()
        {
            int rand = Random.Range(1, 10);

            if (rand <= 5) { type = PlanetType.LONER; }
            else if (rand <= 7) { type = PlanetType.MOON;  }
            else if (rand <= 9) { type = PlanetType.RING; }
        }
        #endregion

        #region Internal Methods
        #endregion

        #region Event Methods
        void Start()
        {
            SetPlanet(astralParent);    
        }
        #endregion
    }
}