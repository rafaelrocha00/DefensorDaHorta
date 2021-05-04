Shader "Custom/Expressoes"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		_Clip("Clip", Range(0,1)) = 0
		_LinhaDesejada("Linha", Float) = 0
        _ColunaDesejada("Coluna", Float) = 0
        _NumeroDeColunas("NumeroDeColunas", Float) = 0
        _NumeroDeLinhas("NumeroDeLinhas", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		float _LinhaDesejada;
        float _ColunaDesejada;
        float _NumeroDeColunas;
        float _NumeroDeLinhas;
		float _Clip;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 Coord  = float2(IN.uv_MainTex.x + (_ColunaDesejada/_NumeroDeColunas), IN.uv_MainTex.y - (_LinhaDesejada/_NumeroDeLinhas));
            fixed4 c = tex2D (_MainTex, Coord) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
			if(c.a <= _Clip) discard;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
