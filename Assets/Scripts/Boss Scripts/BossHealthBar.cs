using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Transform bossTransform;
    public Vector3 offset = new Vector3(0, 3f, 0);

    void LateUpdate()
    {
        if (bossTransform != null)
            transform.position = bossTransform.position + offset;
        else
            Destroy(gameObject);
    }

    public void SetHealth(float current, float max)
    {
        healthSlider.value = current / max;
    }
}