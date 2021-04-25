Shader "Custom/Vento"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _WindStrength ("Forca_vento", Float) = 0.0
        _masking ("Mascara", Range(0,1)) = 0.0
        _WindFrequency ("Frequencia_vento", Float) = 0.0
        _WindDirection ("Direcao_vento", Vector) = (0,0,0)

    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
        #pragma vertex vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float masking;
        };

        half _Glossiness;
        half _Metallic;
        half _WindFrequency;
        half _WindStrength;
        half _masking;
        float3 _WindDirection;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void vert(inout appdata_full v, out Input o){
            
            UNITY_INITIALIZE_OUTPUT(Input,o);
            float4 localSpaceVertex = v.vertex;
            float4 worldSpaceVertex = mul( unity_ObjectToWorld, localSpaceVertex );
 
            float height = (localSpaceVertex.z/2 + .5) + _masking;
            worldSpaceVertex.x += sin(_Time.x * _WindFrequency * worldSpaceVertex.x ) * height * _WindStrength;
            worldSpaceVertex.y += sin(_Time.x * _WindFrequency * worldSpaceVertex.y) * height * _WindStrength;
            v.vertex = mul(unity_WorldToObject, worldSpaceVertex);

        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
