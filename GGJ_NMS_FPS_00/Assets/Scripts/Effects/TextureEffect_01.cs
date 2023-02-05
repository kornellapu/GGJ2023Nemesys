using UnityEngine;

public class TextureEffect_01 : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Animates main texture for fun
        float scaleX = Mathf.Cos(Time.time) * 0.1f + 1;
        float scaleY = Mathf.Sin(Time.time) * 0.1f + 1;
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }
}