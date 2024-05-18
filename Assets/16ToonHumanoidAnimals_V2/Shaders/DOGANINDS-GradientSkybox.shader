Shader "DOGANINDS/GradientSkyBox" {
    Properties {
        _TopColor ("Top Color", Color) = (0.25, 1, 1, 1)  // Upper Color
        _BottomColor ("Bottom Color", Color) = (0, 0.35, 1, 1)  // DownColor
    }
 
    SubShader {
        Tags { "Queue"="Background" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata_t {
                float4 vertex : POSITION;
            };
 
            struct v2f {
                float3 pos : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            float4 _TopColor;
            float4 _BottomColor;
 
            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.pos = v.vertex.xyz;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target {
                // Gradient
                half t = (i.pos.y + 1.0) * 0.5; // Y position to [0, 1] 
                half4 gradientColor = lerp(_BottomColor, _TopColor, t);
                return gradientColor;
            }
            ENDCG
        }
    }
}
