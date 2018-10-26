// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33820,y:32586,varname:node_4013,prsc:2|emission-7165-RGB,alpha-7099-OUT;n:type:ShaderForge.SFN_TexCoord,id:9948,x:33048,y:32821,varname:node_9948,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8515,x:33232,y:32821,varname:node_8515,prsc:2,spu:0,spv:-0.07|UVIN-9948-UVOUT;n:type:ShaderForge.SFN_VertexColor,id:3241,x:33048,y:32978,varname:node_3241,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7099,x:33600,y:32828,varname:node_7099,prsc:2|A-342-R,B-3241-A;n:type:ShaderForge.SFN_Tex2d,id:342,x:33406,y:32704,ptovrint:False,ptlb:Foam,ptin:_Foam,varname:node_342,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8515-UVOUT;n:type:ShaderForge.SFN_Color,id:7165,x:33600,y:32617,ptovrint:False,ptlb:node_7165,ptin:_node_7165,varname:node_7165,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;proporder:342-7165;pass:END;sub:END;*/

Shader "Shader Forge/Water" {
    Properties {
        _Foam ("Foam", 2D) = "white" {}
        _node_7165 ("node_7165", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float4 _node_7165;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float3 emissive = _node_7165.rgb;
                float3 finalColor = emissive;
                float4 node_9870 = _Time + _TimeEditor;
                float2 node_8515 = (i.uv0+node_9870.g*float2(0,-0.07));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_8515, _Foam));
                fixed4 finalRGBA = fixed4(finalColor,(_Foam_var.r*i.vertexColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
