Shader "Custom/WindyTrees"
{
    Properties
    {
        _WindStrength("Wind Strength", Range(-10, 10)) = 1
        _WindSpeed("Wind Speed", Range(-100, 100)) = 1
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };
        half _WindSpeed;
        half _WindStrength;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        void vert(inout appdata_full data)
        {
            float displacementZ = sin(data.vertex.z * _WindSpeed * _Time[0]);
            data.vertex.x += displacementZ * _WindStrength;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
