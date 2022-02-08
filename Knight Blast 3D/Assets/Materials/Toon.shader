Shader "Custom/Toon"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        _AmbientColor ("Ambient Color", Color) = (.4, .4, .4, 1)
        _SpecularColor("Specular Color", Color) = (0.9,0.9,0.9,1)
        _Glossiness("Glossiness", Float) = 32
        _RimColor("Rim Color", Color) = (1,1,1,1)
        _RimAmount("Rim Amount", Range(0, 1)) = 0.716
        _RimThreshold("Rim Threshold", Range(0, 1)) = 0.1
    }
    SubShader
    {
        Tags {
            
            "LightMode" = "ForwardBase"
            "PassFlags" = "OnlyDirectional"
        
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float3 worldNormal : NORMAL;
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 viewDir : TEXCOORD1;
            };

            float4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _AmbientColor;
            float _Glossiness;
            float4 _SpecularColor;
            float4 _RimColor;
            float _RimAmount;
            float _RimThreshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.viewDir = WorldSpaceViewDir(v.vertex);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //*Calculate Normals
                float3 normal = normalize(i.worldNormal);

                //* Normal Lighting
                float NdotL = dot(_WorldSpaceLightPos0, normal);
                // float lightIntensity = NdotL > 0 ? 1:0;
                float lightIntensity = smoothstep(0, .05, NdotL);
                float4 light = lightIntensity * _LightColor0;

                //* Specular Highlighting
                float3 viewDir = normalize(i.viewDir);
                float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
                float NdotH = dot(normal, halfVector);
                float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
                float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
                float4 specular = specularIntensitySmooth * _SpecularColor;

                //* Rim Lighting
                // The rim is the surfaces facing away from the camera, so the rim is calculated by taking the dot product of the normal and view direction and inverting it
                float4 rimDot = 1 - dot(viewDir, normal);
                float rimIntensity = rimDot * pow(NdotL, _RimThreshold);
                rimIntensity = smoothstep(_RimAmount - .01, _RimAmount, rimIntensity);
                float4 rim = rimIntensity * _RimColor;

                //* Sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                return col * _Color *(_AmbientColor + light + rim + specular);
            }
            ENDCG
        }
    }
        FallBack "Diffuse"

}
