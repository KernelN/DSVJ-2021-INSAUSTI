using UnityEngine;

namespace LivingStarmap
{
    class Planet : Planetoid
    {
        public static Material moonMaterial;
        public static GameObject prefabMoon;
        public static GameObject prefabRing;

        #region Constructors
        public void SetPlanet(Transform parent)
        {
            this.astralParent = parent;
            SelectRandomType();
            GenerateLocalTransform(false); //generate pos & scale as a planet
            GenerateOrbit();
            GenerateRotation();
        }
        void SelectRandomType()
        {
            int rand = Random.Range(1, 10);

            if (rand > 5) 
            {
                for (int i = 0; i < Random.Range(1, 3); i++)
                {
                    GameObject moon = Instantiate(prefabMoon);
                    moon.GetComponent<MeshRenderer>().material = moonMaterial;
                    moon.AddComponent<Planetoid>().astralParent = transform; //set moon as child of this planet
                }
            }

            if (rand > 7) 
            { 
                Instantiate(prefabRing).transform.SetParent(this.transform);
            }
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