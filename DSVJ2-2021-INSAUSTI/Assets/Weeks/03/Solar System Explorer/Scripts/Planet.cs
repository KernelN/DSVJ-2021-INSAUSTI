using UnityEngine;

namespace LivingStarmap
{
    struct ParametricCircle
    {
        float anglePerSecond;
        float angle;
        public float radius;

        public void SetAnglePerSecond(float num)
        {
            anglePerSecond = num;
        }
        public void UpdateAngle(float timePassed)
        {
            angle += anglePerSecond * timePassed;
        }
        public float GetX()
        {
            return radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        }
        public float GetY()
        {
            return radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        }
    }

    class Planet : MonoBehaviour
    {
        enum PlanetType { LONER, MOON, RING };
        [SerializeField] PlanetType type;
        [SerializeField] Transform parent;
        [SerializeField] float orbitTime;
        [SerializeField] float rotationTime;

        public static float orbitSpeedMod = 10;
        public static float rotationSpeedMod = 10;
        ParametricCircle orbit;

        #region Constructors
        Planet(Transform parent, float rotationTime) 
        {
            //this.type = type;
            this.parent = parent;
            SelectRandomType();
            GenerateOrbit();
            this.rotationTime = rotationTime;
        }
        Planet(Transform parent, PlanetType type, float rotationTime)
        {
            //this.type = type;
            this.parent = parent;
            this.type = type;
            GenerateOrbit();
            this.rotationTime = rotationTime;
        }
        void SelectRandomType()
        {
            int rand = Random.Range(1, 10);

            if (rand <= 5) { type = PlanetType.LONER; }
            else if (rand <= 7) { type = PlanetType.MOON; }
            else if (rand <= 9) { type = PlanetType.RING; }
        }
        void GenerateOrbit()
        {
            orbit.radius = Vector3.Magnitude(transform.localPosition - parent.localPosition);
            orbitTime = Vector3.Magnitude(transform.localScale) / orbit.radius;
            orbit.SetAnglePerSecond(360 / orbitTime);
        }
        #endregion

        #region Internal Methods
        void UpdateOrbit()
        {
            orbit.UpdateAngle(orbitSpeedMod * Time.deltaTime);
            transform.localPosition = new Vector3(orbit.GetX(), 0, orbit.GetY());
        }
        void UpdateRotation()
        {
            transform.Rotate(0, rotationTime * rotationSpeedMod * Time.deltaTime, 0);
        }
        #endregion

        #region External Methods
        public void UpdatePlanet()
        {
            UpdateOrbit();
            UpdateRotation();
        }
        #endregion
    }
}