using UnityEngine;
using CustomMath;

namespace LivingStarmap
{
    class Planetoid : AstronomicalBody //planetoids orbit around another object
    {
        //internal Material material;
        internal ParametricCircle orbit;

        [SerializeField] internal Transform astralParent;
        [SerializeField] internal float orbitTime;
        [SerializeField] internal float rotationTime;

        [SerializeField] static float orbitSpeedMod = 10;
        [SerializeField] static float rotationSpeedMod = 1;


        #region Constructors
        public void SetPlanetoid(Transform parent, bool isMoon)
        {
            astralParent = parent;
            if (isMoon) { transform.SetParent(parent); }
            GenerateLocalTransform(isMoon);
            GenerateOrbit();
            GenerateRotation();
        }
        internal void GenerateLocalTransform(bool isMoon)
        {
            if (isMoon)
            {
                transform.localScale = new Vector3(1,1,1) * Random.Range(0.2f, 0.3f);
                transform.localPosition = new Vector3(transform.localScale.x + astralParent.localScale.x / 2, 0, 0);
                this.name = astralParent.name + " - Moon" + astralParent.childCount;
            }
            else
            {
                transform.localScale *= Random.Range(0.1f, 2.9f);
                transform.localPosition = new Vector3(astralParent.localScale.x, 0, 0) * Random.Range(1, 10); //minDistance * (1|maxDistance)
            }
        }
        internal void GenerateOrbit()
        {
            orbit.radius = transform.localPosition.x;
            orbitTime = (transform.localScale.x * orbit.radius) * 200 / astralParent.localScale.x;
            orbit.SetAnglePerSecond(360 / orbitTime);
        }
        internal void GenerateRotation()
        {
            rotationTime = Random.Range(-60f, 60f);
        }
        #endregion

        #region Internal Methods
        internal void UpdateOrbit()
        {
            orbit.UpdateAngle(orbitSpeedMod * Time.deltaTime);
            transform.position = astralParent.localPosition + new Vector3(orbit.GetX(), 0, orbit.GetY()); //parametric circle is in 2d, so the Y coordinate becomes the Z coordinate
        }
        internal void UpdateRotation()
        {
            transform.Rotate(0, rotationTime * rotationSpeedMod * Time.deltaTime, 0);
        }
        #endregion

        #region Event Methods
        void Start()
        {
            SetPlanetoid(astralParent, true);    
        }
        void Update()
        {
            UpdateOrbit();
            UpdateRotation();
        }
        #endregion
    }
}