using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGen02 : MonoBehaviour
{
    [SerializeField] private GameObject leafPrefab;
    //[SerializeField] private GameObject leafCenter;
    //[SerializeField] private GameObject plantCenter;
    [SerializeField] private int numOfLeaves;
    [SerializeField] private float plantHieght = 0.974f;
    [SerializeField] private float leafRotation = 0f;
    [SerializeField] private SphereCollider sphereCol;

    void Start()
    {
        GenerateLayer();
    }

    private void GenerateLayer()
    {
        Debug.Log("generate layer funct fires");

        var radius = sphereCol.radius;

        for (int i = 0; i <= numOfLeaves; i++)
        {
            float angle = i * Mathf.PI * 2f / numOfLeaves;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, plantHieght, Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(leafPrefab, newPos, Quaternion.Euler(0f, leafRotation, 0f));
            leafRotation -= 360 / numOfLeaves;
        }
    }
}
