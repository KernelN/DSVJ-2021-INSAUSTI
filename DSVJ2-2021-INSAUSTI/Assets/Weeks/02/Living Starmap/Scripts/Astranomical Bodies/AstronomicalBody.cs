using UnityEngine;

namespace LivingStarmap
{
    public class AstronomicalBody : MonoBehaviour
    {
        public static float scale = 0.3f; //scale of the entire solar system
        internal TrailRenderer trail;
        public virtual void Set()
        {
            gameObject.AddComponent<TrailRenderer>();
            trail = gameObject.GetComponent<TrailRenderer>();
        }
    }
}