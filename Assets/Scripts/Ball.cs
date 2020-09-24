using UnityEngine;

public class Ball : MonoBehaviour
{
    public Material blackMaterial;
    public Material whiteMaterial;
    public Material player1Material;
    public Material player2Material;

    private int player1Goals;
    private int player2Goals;

    private void Start()
    {
        SetOriginalMaterials();
        player1Goals = 0;
        player2Goals = 0;
    }

    private void Reset()
    {
        SetOriginalMaterials();
        transform.position = new Vector3(0, 20, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void Update()
    {
        GetComponent<Rigidbody>().WakeUp();
    }

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
                player2Goals++;
                UpdateScore();
                Reset();
                break;
            case "Net2":
                player1Goals++;
                UpdateScore();
                Reset();
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Invoke(nameof(SetOriginalMaterials), 1);
    }

    private void UpdateScore()
    {
        Debug.Log("[P1] " + player1Goals + " - " + player2Goals + "[P2]");
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
