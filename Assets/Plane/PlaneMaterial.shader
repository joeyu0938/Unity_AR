Shader "Unlit/PlaneMaterial"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _lightNum("lights", Int) = 1
    }
        SubShader
        {
            Pass
            {
                Name "FORWARD"
                Tags {"LightMode" = "ForwardBase"}
                Blend SrcAlpha OneMinusSrcAlpha
                ZWrite On

                CGPROGRAM
                #pragma target 3.0
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
                #include "Lighting.cginc"
                #include "AutoLight.cginc"
                #pragma multi_compile_fwdbase
                uint _lightNum;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                SHADOW_COORDS(2)
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.screenPos = ComputeScreenPos(o.pos);
                TRANSFER_SHADOW(o);
                return o;
            }

            sampler2D _MainTex;
            //uint _lightNum;

            fixed4 frag(v2f i) : SV_Target
            {
                // 1 / NumLight, should be fed by program.
                float scale = 1 / _lightNum;
                float2 uv = i.screenPos.xy / i.screenPos.w;
                fixed3 color = scale * tex2D(_MainTex, uv).rgb;
                float inShadow = SHADOW_ATTENUATION(i);
                if (inShadow > 0.5)
                    return fixed4(color, 1);
                else
                    return fixed4(color * 0.7, 1);
            }
            ENDCG
        }
        Pass
        {
            Name "FORWARD_DELTA"
            Tags {"LightMode" = "ForwardAdd"}

            Blend One One
            ZWrite Off
            ZTest LEqual

            CGPROGRAM
            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            uint _lightNum;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                SHADOW_COORDS(2)
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.screenPos = ComputeScreenPos(o.pos);
                TRANSFER_SHADOW(o);
                return o;
            }

            sampler2D _MainTex;
            //uint _lightNum;

            fixed4 frag(v2f i) : SV_Target
            {
                // 1 / NumLight, should be fed by program.
                float scale = 1 / _lightNum;
                float2 uv = i.screenPos.xy / i.screenPos.w;;
                fixed3 color = scale * tex2D(_MainTex, uv).rgb;
                float inShadow = SHADOW_ATTENUATION(i);
                if (inShadow > 0.5)
                    return fixed4(color, 1);
                else
                    return fixed4(color * 0.7, 1);
            }
            ENDCG
        }
    }
        Fallback "Diffuse"
}
