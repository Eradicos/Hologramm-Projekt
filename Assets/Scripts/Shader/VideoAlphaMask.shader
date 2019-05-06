// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unlit alpha-blended shader.
 // - no lighting
 // - no lightmap support
 // - no per-material color
 
 Shader "Unlit/VideoAlphaMask" {
 Properties {
     _MainTex ("Base (RGB)", 2D) = "white" {}
     _MaskTex ("Base (RGB)", 2D) = "black" {}
     _Alpha ("Additional Alpha Val", float) = 0.5
     _VisibleRegion ("Visible Region", Vector) = (0.0, 0.0, 1.0, 1.0)
 }
 
 SubShader {
     Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
     LOD 100
     
     ZWrite Off
     Blend SrcAlpha OneMinusSrcAlpha 
     
     Pass {  
         CGPROGRAM
             #pragma vertex vert
             #pragma fragment frag
             #pragma multi_compile_fog
             
             #include "UnityCG.cginc"
 
             struct appdata_t {
                 float4 vertex : POSITION;
                 float2 texcoord : TEXCOORD0;
                 float2 maskcoord : TEXCOORD1;
             };
 
             struct v2f {
                 float4 vertex : SV_POSITION;
                 half2 texcoord : TEXCOORD0;
                 half2 maskcoord : TEXCOORD1;
                 float2 uv : TEXCOORD2;
                 //UNITY_FOG_COORDS(1)
             };
 
             sampler2D _MainTex;
             float4 _MainTex_ST;

             sampler2D _MaskTex;
             float4 _MaskTex_ST;

             float4 _VisibleRegion;
             
             float _Alpha;
             
             v2f vert (appdata_t v)
             {
                 v2f o;
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 o.uv = v.texcoord;
                 o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                 o.maskcoord = TRANSFORM_TEX(v.maskcoord, _MaskTex);
                 //UNITY_TRANSFER_FOG(o,o.vertex);
               
                 return o;
             }
             
             fixed4 frag (v2f i) : SV_Target
             {
                 fixed4 col = tex2D(_MainTex, i.texcoord).rgba;
                 //UNITY_APPLY_FOG(i.fogCoord, col);

                 fixed alpha = tex2D(_MaskTex, i.maskcoord).r;
                 if (alpha > 0) {
                    alpha = alpha * _Alpha;
                 }

                 fixed4 result = 0;

                 float2 pos = i.uv;

                 if (pos.x > _VisibleRegion.x && pos.y > _VisibleRegion.y
                     && pos.x < _VisibleRegion.z && pos.y < _VisibleRegion.w) 
                 {
                     result = col * fixed4(1, 1, 1, alpha);
                 }
                
                 return result;
             }
         ENDCG
     }
 }
 
 }