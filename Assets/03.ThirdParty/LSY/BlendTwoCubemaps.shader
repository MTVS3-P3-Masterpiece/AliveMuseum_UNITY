Shader "Custom/BlendTwoTextures"
{
    Properties
    {
        _Tex1 ("Texture 1 (LDR)", 2D) = "white" {}
        _Tex2 ("Texture 2 (LDR)", 2D) = "white" {}
        _BlendFactor ("Blend Factor", Range(0, 1)) = 0.5
        _Tint ("Tint Color", Color) = (1, 1, 1, 1)
    }
    SubShader { 
        Tags { "QUEUE"="Background" "RenderType"="Background" "PreviewType"="Skybox" }

        Pass {
            ZWrite Off
            Cull Off
            //////////////////////////////////
            //                              //
            //      Compiled programs       //
            //                              //
            //////////////////////////////////
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0; // UV 좌표로 변경
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0; // UV 좌표로 변경
            };

            sampler2D _Tex1;
            sampler2D _Tex2;
            float _BlendFactor;
            fixed4 _Tint;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv; // UV 좌표를 전달
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 texColor1 = tex2D(_Tex1, i.uv);
                fixed4 texColor2 = tex2D(_Tex2, i.uv);
                
                // 블렌드 팩터에 따라 두 텍스처를 블렌딩
                fixed4 blendedColor = lerp(texColor1, texColor2, _BlendFactor);
                
                // 색상 적용
                blendedColor *= _Tint;

                return blendedColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}