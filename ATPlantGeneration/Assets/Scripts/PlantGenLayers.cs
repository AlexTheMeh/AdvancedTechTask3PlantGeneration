using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGenLayers : MonoBehaviour
{
    [SerializeField] private GameObject layerPrefab;
    [SerializeField] private Transform plantCenter;

    [SerializeField] private float numberOfLayers = 0f;
    [SerializeField] private float leafPitchStart = -11.825f;
    [SerializeField] private float leafPitchIncrements = -11.825f;
    //[SerializeField] private float layerScale = 0f;


    void Start()
    {
        genPlant();
    }

    void genPlant()
    {
        //Debug.Log("generate plant funct fires");
        Vector3 layerHeight = new Vector3(0f, 0.834f, 0f);
        Vector3 layerScale = new Vector3(1f, 1f, 1f);

        for (int i = 1; i <= numberOfLayers; i++)
        {
            Debug.Log(i);
            
            if(i == 2 || i == 4 || i == 6 || i == 8 || i == 10)
            {              
                GameObject LeafLayer = Instantiate(layerPrefab, layerHeight, Quaternion.Euler(0f,30f,0f));
                LeafLayer.transform.localScale = layerScale;

                foreach(Transform leaf in LeafLayer.transform)
                {
                    leaf.transform.Rotate(leafPitchStart, 0f, 0f);
                    //Debug.Log(leaf.transform.name);
                }
            }
            else
            {
                GameObject LeafLayer = Instantiate(layerPrefab, layerHeight, Quaternion.identity);
                LeafLayer.transform.localScale = layerScale;

                if(i != 1)
                {
                    foreach (Transform leaf in LeafLayer.transform)
                    {
                        leaf.transform.Rotate(leafPitchStart, 0f, 0f);
                    }
                }
            }

            layerScale.x -= 0.2f;
            layerScale.y -= 0.2f;
            layerScale.z -= 0.2f;

            leafPitchStart += leafPitchIncrements;

            layerHeight.y += 0.005f;
        }
    }
}
