Shader "Custom/MotionBlur" {
    Properties 
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PrevFrame ("PrevFrame", 2D) = "white" {}
    }
    SubShader 
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
  
        Pass
        {
            CGPROGRAM
 
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"
             
            uniform sampler2D _MainTex;
            uniform sampler2D _PrevFrame;
 
            half4 frag (v2f_img i) : COLOR
            {
                fixed4 c1 = tex2D(_MainTex, i.uv);
                i.uv.y = 1 - i.uv.y;
                fixed4 c2 = tex2D(_PrevFrame, i.uv);
                fixed4 res = (c1 + c2) / 2;
                return res;
            }

            ENDCG
        }
    }

    FallBack "Diffuse"
}