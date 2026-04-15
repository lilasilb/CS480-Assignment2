using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotColdBar : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public Image fillImage;
    public TMP_Text tempText;

    public float maxDistance = 25f;
    public float minDistance = 0.5f;

    public Color hotColor = Color.red;
    public Color coldColor = Color.blue;

    void Start()
    {
        player = GameObject.Find("JohnLemon").transform;
        target = GameObject.Find("EndLocation").transform;
        fillImage = GameObject.Find("Background").GetComponentsInChildren<Image>()[1];
        tempText = GameObject.Find("TemperatureText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (player == null || target == null || fillImage == null) return;
        float distance = Vector3.Distance(player.position, target.position);
        float t = Mathf.Clamp01(Mathf.InverseLerp(maxDistance, minDistance, distance));
        if (t < 0.2f) {
            tempText.text = "cold";
        }
        else if (t < 0.6f)
        {
            tempText.text = "Warm...";
        }
        else
        {
            tempText.text = "HOT!!!";
        }
        Color color = Color.Lerp(coldColor, hotColor, t);
        float pulse = (Mathf.Sin(Time.time * 8f) + 1f) / 2f; // oscillates 0–1
        fillImage.color = Color.Lerp(color, Color.white, pulse * 0.3f);
    }
}