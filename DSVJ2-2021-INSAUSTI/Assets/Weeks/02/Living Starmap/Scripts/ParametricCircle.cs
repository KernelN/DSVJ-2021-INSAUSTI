using UnityEngine;

namespace CustomMath
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
}