using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HotColdBar : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public Image fillImage;

    public float maxDistance = 25f;
    public float minDistance = 0.5f;

    public Color hotColor = Color.red;
    public Color coldColor = Color.blue;

    void Start()
    {
        player = GameObject.Find("JohnLemon").transform;
        target = GameObject.Find("EndLocation").transform;
        fillImage = GameObject.Find("Background").GetComponentsInChildren<Image>()[1];
    }

    void Update()
    {
        if (player == null || target == null || fillImage == null) return;
        float distance = Vector3.Distance(player.position, target.position);
        float t = Mathf.Clamp01(Mathf.InverseLerp(maxDistance, minDistance, distance));
        fillImage.color = Color.Lerp(coldColor, hotColor, t);
        if (t > 0.8f)
        {
            float pulse = (Mathf.Sin(Time.time * 8f) + 1f) / 2f; // oscillates 0–1
            fillImage.color = Color.Lerp(hotColor, Color.white, pulse * 0.3f);
        }
    }
}