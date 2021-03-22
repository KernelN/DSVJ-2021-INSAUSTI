using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    public Transform parent;
    public float orbitTime;

    const float speedMod = 1;
    public float anglePerSecond;
    public float radius;
    public float angle;

    private void Start()
    {
        radius = this.transform.localPosition.x;
        anglePerSecond = 360 / orbitTime;
    }

    // Update is called once per frame
    void Update()
    {
        angle += anglePerSecond * Time.deltaTime;
        this.transform.localPosition = new Vector3(GetX(), 0, GetZ());
    }

    float GetX()
    {
        return radius * Mathf.Cos(angle);
    }
    float GetZ()
    {
        return radius * Mathf.Sin(angle);
    }
}
