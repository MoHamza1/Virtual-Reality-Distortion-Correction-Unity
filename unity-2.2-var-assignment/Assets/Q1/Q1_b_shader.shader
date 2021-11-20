Shader "Custom/Q1_b_shader"
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

			uniform float _strength_corecction =0.5f;
            sampler2D _MainTex;

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


            fixed4 frag (v2f i) : SV_Target
            {
				float2 temp = i.uv;
				float2 centre = temp.xy - float2(0.5, 0.5);
				float radius = pow(centre.x,2) + pow(centre.y,2) ;
				float transform =  ((_strength_corecction + (0.4f * sqrt(radius))) *  radius) + 1.0 ;
				float2 res = 0.5 + (transform * 1.0f * centre);
                return tex2D(_MainTex, res);
            }
            ENDCG
        }
    }
}

