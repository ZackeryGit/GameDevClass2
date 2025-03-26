using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGolden : MonoBehaviour
{
    public GameObject cookieParent;
    public Color goldenColor = new Color(1f, 0.84f, 0f, 1f); // Gold color

    private MaterialPropertyBlock propertyBlock;
    private static readonly int ColorProperty = Shader.PropertyToID("_Color");

    void Start()
    {
        propertyBlock = new MaterialPropertyBlock();
    }

    public void SetGoldenSkin()
    {
        foreach (MeshRenderer mr in cookieParent.GetComponentsInChildren<MeshRenderer>())
        {
            mr.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(ColorProperty, goldenColor);
            mr.SetPropertyBlock(propertyBlock);
        }
    }

    public void RevertToOriginalSkin()
    {
        foreach (MeshRenderer mr in cookieParent.GetComponentsInChildren<MeshRenderer>())
        {
            mr.GetPropertyBlock(propertyBlock);
            propertyBlock.Clear(); // Reset color
            mr.SetPropertyBlock(propertyBlock);
        }
    }
}
