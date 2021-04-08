using UnityEngine;

namespace LivingStarmap
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] float moveSpeedMod;
        [SerializeField] float rotateSpeedMod;

        void Update()
        {
            transform.localPosition += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedMod;
            transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeedMod, 0);
        }
    }
}