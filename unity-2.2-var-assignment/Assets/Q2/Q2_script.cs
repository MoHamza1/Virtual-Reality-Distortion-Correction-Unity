using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q2_script : MonoBehaviour
{
    public Material mat;
    [Range(-0.1f, 0.1f)]
    public float _bx = 0.02f;
    [Range(-0.1f, 0.1f)]
    public float _by = 0.005f;
    [Range(-0.1f, 0.1f)]
    public float _rx = -0.008f;
    [Range(-0.1f, 0.1f)]
    public float _ry = -0.002f;
    [Range(-0.1f, 0.1f)]
    public float _gx = 0.004f;
    [Range(-0.1f, 0.1f)]
    public float _gy = -0.012f;


    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Shader.SetGlobalFloat("_bx", _bx);
        Shader.SetGlobalFloat("_by", _by);
        Shader.SetGlobalFloat("_rx", _rx);
        Shader.SetGlobalFloat("_ry", _ry);
        Shader.SetGlobalFloat("_gx", _gx);
        Shader.SetGlobalFloat("_gy", _gy);

        Graphics.Blit(src, dest, mat);
    }
}
