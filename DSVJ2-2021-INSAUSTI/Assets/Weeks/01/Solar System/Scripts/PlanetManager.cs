using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public Transform sun;
    public Transform mercury;
    public Transform venus;
    public Transform earth;
    public Transform mars;
    public Transform jupiter;
    public Transform saturn;
    public Transform uranus;
    public Transform neptune;

    public float scaleMultiplier;

    void Awake()
    {
        sun.localScale *= scaleMultiplier;
        mercury.localPosition *= scaleMultiplier;
        venus.position = new Vector3(mercury.localPosition.x * 1.86f, 0, 0);
        earth.position = new Vector3(mercury.localPosition.x * 2.58f, 0, 0);
        mars.position = new Vector3(mercury.localPosition.x * 3.93f, 0, 0);
        jupiter.position = new Vector3(mercury.localPosition.x * 13.44f, 0, 0);
        saturn.position = new Vector3(mercury.localPosition.x * 24.68f, 0, 0);
        uranus.position = new Vector3(mercury.localPosition.x * 49.57f, 0, 0);
        neptune.position = new Vector3(mercury.localPosition.x * 77.78f, 0, 0);
    }
}
