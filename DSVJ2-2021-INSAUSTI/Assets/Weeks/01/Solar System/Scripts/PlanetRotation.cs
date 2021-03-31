using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    public Transform parent;
    public float orbitTime;

    float speedMod = 10;
    float anglePerSecond;
    float radius;
    float angle;

    private void Start()
    {
        radius = this.transform.localPosition.x;
        anglePerSecond = 360 / orbitTime;
    }

    // Update is called once per frame
    void Update()
    {
        angle += anglePerSecond * speedMod * Time.deltaTime;
        this.transform.localPosition = new Vector3(GetX(), 0, GetZ());
    }

    float GetX()
    {
        return radius * Mathf.Cos(angle * Mathf.Deg2Rad);
    }
    float GetZ()
    {
        return radius * Mathf.Sin(angle * Mathf.Deg2Rad);
    }
}
