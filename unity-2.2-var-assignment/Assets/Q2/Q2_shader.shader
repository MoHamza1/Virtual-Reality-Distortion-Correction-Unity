Shader "Custom/Q2_shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            uniform float _rx;
            uniform float _ry;
            uniform float _gx;
            uniform float _gy;
            uniform float _bx;
            uniform float _by;
           

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {

                float4 col = tex2D(_MainTex, i.uv);

                col.r = tex2D(_MainTex, float2(i.uv + float2(_rx, _ry))).r;
                col.g = tex2D(_MainTex, float2(i.uv + float2(_gx, _gy))).g;
                col.b = tex2D(_MainTex, float2(i.uv + float2(_bx, _by))).b;

                return col;
            }
            ENDCG
        }
    }
}
