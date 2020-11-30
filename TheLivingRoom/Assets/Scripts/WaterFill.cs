using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour
{
    void Update()
    {
        GetComponent<MeshRenderer>().material.SetVector("_Pos", transform.position);
    }
}
