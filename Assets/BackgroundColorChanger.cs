using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;
    private float cycleSpeed = 0.05f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = sr.color;
        Color.RGBToHSV(currentColor, out float hue, out float saturation, out float value);

        hue += cycleSpeed * Time.deltaTime;
        hue = Mathf.Repeat(hue, 1f);

        Color newColor = Color.HSVToRGB(hue, saturation, value);
        sr.color = newColor;
    }
}
