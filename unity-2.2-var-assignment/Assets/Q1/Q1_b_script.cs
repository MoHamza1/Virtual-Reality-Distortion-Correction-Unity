using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1_b_script : MonoBehaviour
{

    public Material mat;
    [Range(-3.0f, 3.0f)]
    public float _strength_corecction = 0.70f;



    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Shader.SetGlobalFloat("_strength_corecction", _strength_corecction);


        Graphics.Blit(src, dest, mat);
    }
}
