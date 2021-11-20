using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1_a_script : MonoBehaviour
{
    public Material mat;

    [Range(-3.0f, 3.0f)]
    public float _strength_pre_distortion = -0.70f;


    void OnRenderImage(RenderTexture src,RenderTexture dest)
    {
        Shader.SetGlobalFloat("_strength_pre_distortion", _strength_pre_distortion);

        Graphics.Blit(src, dest, mat);
    }
}
