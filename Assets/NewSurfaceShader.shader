Shader "Custom/DungeonDarkness_Standard"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _LightPos ("Light Position", Vector) = (0,0,0,0)
        _LightRadius ("Light Radius", Float) = 5.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float3 _LightPos;
            float _LightRadius;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float dist = distance(i.worldPos, _LightPos);
                float brightness = saturate(1.0 - dist / _LightRadius);
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb *= brightness; // темнеем вне света
                return col;
            }
            ENDCG
        }
    }
}