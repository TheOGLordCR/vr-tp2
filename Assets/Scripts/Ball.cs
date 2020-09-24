using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    public Material blackMaterial;
    public Material whiteMaterial;
    public Material player1Material;
    public Material player2Material;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player1":
                SetMaterials(player1Material, whiteMaterial);
                break;
            case "Player2":
                SetMaterials(player2Material, whiteMaterial);
                break;
            case "Net1":
                break;
            case "Net2":
                break;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Invoke(nameof(SetOriginalMaterials), 1);
    }

    private void SetOriginalMaterials()
    {
        SetMaterials(whiteMaterial, blackMaterial);
    }

    private void SetMaterials(Material primaryMaterial, Material secondaryMaterial)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material[] materials = meshRenderer.materials;
        materials[0] = primaryMaterial;
        materials[1] = secondaryMaterial;
        meshRenderer.materials = materials;
    }
}
