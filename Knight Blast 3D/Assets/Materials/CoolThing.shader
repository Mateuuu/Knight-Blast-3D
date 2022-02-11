Shader "Unlit/CoolThing"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Texture1 ("Texture", 2D) = "white" {}
        _Texture2 ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Cull Off

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
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;

            sampler2D _Texture1;
            sampler2D _Texture2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv);
                fixed4 col = tex2D(_Texture1, i.uv + _Time[0]);
                fixed4 col2 = tex2D(_Texture2, i.uv);
                fixed4 combination = min(col, col2);
                
                return  tex * (_Color + combination);
            }
            ENDCG
        }
    }
}
