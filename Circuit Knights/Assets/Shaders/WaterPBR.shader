// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32720,y:32712,varname:node_2865,prsc:2|diff-3393-OUT,spec-9988-OUT,gloss-1813-OUT,normal-9682-OUT,emission-5840-OUT;n:type:ShaderForge.SFN_Slider,id:1813,x:32142,y:32797,ptovrint:False,ptlb:Glossiness,ptin:_Glossiness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.95,max:1;n:type:ShaderForge.SFN_Color,id:9875,x:31801,y:32444,ptovrint:False,ptlb:Colour (Deep),ptin:_ColourDeep,varname:node_9875,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.3,c3:0.2,c4:1;n:type:ShaderForge.SFN_Color,id:1057,x:31801,y:32624,ptovrint:False,ptlb:Colour (Shallow),ptin:_ColourShallow,varname:node_1057,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4,c2:0.8,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:3393,x:32022,y:32519,varname:node_3393,prsc:2|A-9875-RGB,B-1057-RGB,T-590-OUT;n:type:ShaderForge.SFN_Fresnel,id:590,x:31801,y:32798,varname:node_590,prsc:2|NRM-3946-OUT,EXP-3549-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:3549,x:31811,y:32999,varname:node_3549,prsc:2,min:0,max:1|IN-359-OUT;n:type:ShaderForge.SFN_NormalVector,id:3946,x:31561,y:32742,prsc:2,pt:True;n:type:ShaderForge.SFN_Tex2d,id:9365,x:31404,y:33710,varname:node_9365,prsc:2,ntxv:0,isnm:False|UVIN-8885-OUT,TEX-2496-TEX;n:type:ShaderForge.SFN_Tex2d,id:5502,x:31404,y:33907,varname:node_5502,prsc:2,ntxv:0,isnm:False|UVIN-9325-OUT,TEX-2496-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2496,x:30891,y:33739,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_2496,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Time,id:1773,x:29673,y:33529,varname:node_1773,prsc:2;n:type:ShaderForge.SFN_FragmentPosition,id:5097,x:30423,y:32339,varname:node_5097,prsc:2;n:type:ShaderForge.SFN_Append,id:1616,x:30648,y:32353,varname:node_1616,prsc:2|A-5097-X,B-5097-Z;n:type:ShaderForge.SFN_Divide,id:4812,x:30902,y:32361,varname:node_4812,prsc:2|A-1616-OUT,B-5740-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5740,x:30666,y:32526,ptovrint:False,ptlb:UV Scale,ptin:_UVScale,varname:node_5740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Set,id:3000,x:31081,y:32361,varname:_worldUV,prsc:2|IN-4812-OUT;n:type:ShaderForge.SFN_Set,id:6023,x:30519,y:32965,varname:_UV1,prsc:2|IN-6593-OUT;n:type:ShaderForge.SFN_Set,id:2076,x:30544,y:33332,varname:_UV2t,prsc:2|IN-7855-OUT;n:type:ShaderForge.SFN_Vector4Property,id:7435,x:29674,y:32835,ptovrint:False,ptlb:UV 1 Animator,ptin:_UV1Animator,varname:node_7435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:4456,x:29673,y:33360,ptovrint:False,ptlb:UV 2 Animator,ptin:_UV2Animator,varname:node_4456,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_ComponentMask,id:3998,x:29910,y:33038,varname:node_3998,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-61-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1828,x:29910,y:33190,varname:node_1828,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7075-OUT;n:type:ShaderForge.SFN_Multiply,id:558,x:29910,y:32766,varname:node_558,prsc:2|A-7435-X,B-1773-TSL;n:type:ShaderForge.SFN_Multiply,id:9429,x:29910,y:32902,varname:node_9429,prsc:2|A-7435-Y,B-1773-TSL;n:type:ShaderForge.SFN_Add,id:6724,x:30115,y:32855,varname:node_6724,prsc:2|A-558-OUT,B-3998-R;n:type:ShaderForge.SFN_Add,id:8712,x:30115,y:32989,varname:node_8712,prsc:2|A-9429-OUT,B-3998-G;n:type:ShaderForge.SFN_Append,id:6593,x:30343,y:32929,varname:node_6593,prsc:2|A-6724-OUT,B-8712-OUT;n:type:ShaderForge.SFN_Multiply,id:6751,x:29910,y:33336,varname:node_6751,prsc:2|A-4456-X,B-1773-TSL;n:type:ShaderForge.SFN_Multiply,id:265,x:29910,y:33467,varname:node_265,prsc:2|A-4456-Y,B-1773-TSL;n:type:ShaderForge.SFN_Add,id:4637,x:30115,y:33225,varname:node_4637,prsc:2|A-6751-OUT,B-1828-R;n:type:ShaderForge.SFN_Add,id:4716,x:30115,y:33359,varname:node_4716,prsc:2|A-265-OUT,B-1828-G;n:type:ShaderForge.SFN_Append,id:7855,x:30356,y:33296,varname:node_7855,prsc:2|A-4637-OUT,B-4716-OUT;n:type:ShaderForge.SFN_Multiply,id:61,x:29380,y:33038,varname:node_61,prsc:2|A-3288-OUT,B-6523-OUT;n:type:ShaderForge.SFN_Multiply,id:7075,x:29380,y:33179,varname:node_7075,prsc:2|A-3288-OUT,B-6523-OUT;n:type:ShaderForge.SFN_Get,id:3288,x:28978,y:33145,varname:node_3288,prsc:2|IN-3000-OUT;n:type:ShaderForge.SFN_Get,id:8885,x:31077,y:33688,varname:node_8885,prsc:2|IN-6023-OUT;n:type:ShaderForge.SFN_Get,id:9325,x:31078,y:33981,varname:node_9325,prsc:2|IN-2076-OUT;n:type:ShaderForge.SFN_Slider,id:359,x:31461,y:32962,ptovrint:False,ptlb:Colour (Fresnel),ptin:_ColourFresnel,varname:node_359,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.336,max:1.336;n:type:ShaderForge.SFN_Slider,id:9988,x:32142,y:32708,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_9988,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:6813,x:31996,y:34125,varname:node_6813,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:9682,x:32214,y:33939,varname:node_9682,prsc:2|A-3112-OUT,B-6276-OUT,T-6813-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5251,x:31596,y:33710,varname:node_5251,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9365-RGB;n:type:ShaderForge.SFN_ComponentMask,id:3978,x:31596,y:33897,varname:node_3978,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5502-RGB;n:type:ShaderForge.SFN_Multiply,id:6287,x:31778,y:33710,varname:node_6287,prsc:2|A-5251-OUT,B-6449-OUT;n:type:ShaderForge.SFN_Multiply,id:2939,x:31778,y:33907,varname:node_2939,prsc:2|A-3978-OUT,B-6449-OUT;n:type:ShaderForge.SFN_Append,id:3112,x:31932,y:33707,varname:node_3112,prsc:2|A-6287-OUT,B-8302-OUT;n:type:ShaderForge.SFN_Append,id:6276,x:31932,y:33907,varname:node_6276,prsc:2|A-2939-OUT,B-8302-OUT;n:type:ShaderForge.SFN_Slider,id:6449,x:31383,y:34085,ptovrint:False,ptlb:Normal Map Strength,ptin:_NormalMapStrength,varname:node_6449,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:8302,x:31660,y:34141,varname:node_8302,prsc:2,v1:1;n:type:ShaderForge.SFN_Panner,id:7881,x:33375,y:32946,varname:node_7881,prsc:2,spu:1,spv:0.05|UVIN-529-OUT;n:type:ShaderForge.SFN_Tex2d,id:3602,x:33558,y:32946,ptovrint:False,ptlb:Noise G,ptin:_NoiseG,varname:node_3602,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7881-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:9842,x:33749,y:32929,varname:node_9842,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-3602-G;n:type:ShaderForge.SFN_Add,id:305,x:33950,y:32947,varname:node_305,prsc:2|A-9842-OUT,B-2889-OUT;n:type:ShaderForge.SFN_Vector1,id:8647,x:33431,y:33199,varname:node_8647,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Multiply,id:2889,x:33605,y:33155,varname:node_2889,prsc:2|A-529-OUT,B-8647-OUT;n:type:ShaderForge.SFN_Tex2d,id:2552,x:34187,y:32932,varname:node_2552,prsc:2,ntxv:0,isnm:False|UVIN-305-OUT,TEX-9069-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:9069,x:34130,y:32733,ptovrint:False,ptlb:Caustics,ptin:_Caustics,varname:node_9069,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Subtract,id:5964,x:34391,y:32932,varname:node_5964,prsc:2|A-2552-RGB,B-3709-OUT;n:type:ShaderForge.SFN_OneMinus,id:3709,x:34235,y:33120,varname:node_3709,prsc:2|IN-9014-OUT;n:type:ShaderForge.SFN_Slider,id:9014,x:33869,y:33240,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_9014,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7,max:1;n:type:ShaderForge.SFN_Slider,id:8578,x:33980,y:33340,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_Multiply,id:9920,x:34542,y:33086,varname:node_9920,prsc:2|A-5964-OUT,B-8578-OUT;n:type:ShaderForge.SFN_VertexColor,id:9932,x:34491,y:33231,varname:node_9932,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4630,x:34693,y:33133,varname:node_4630,prsc:2|A-9920-OUT,B-9932-A;n:type:ShaderForge.SFN_Set,id:2173,x:34956,y:33288,varname:_Caustics,prsc:2|IN-4630-OUT;n:type:ShaderForge.SFN_Get,id:5840,x:32319,y:32926,varname:node_5840,prsc:2|IN-2173-OUT;n:type:ShaderForge.SFN_Vector1,id:6523,x:28819,y:33302,varname:node_6523,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:5515,x:32935,y:32989,varname:node_5515,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:529,x:33136,y:33045,varname:node_529,prsc:2|A-5515-UVOUT,B-9649-OUT;n:type:ShaderForge.SFN_Get,id:9649,x:33015,y:33297,varname:node_9649,prsc:2|IN-3000-OUT;proporder:9875-1057-359-9988-1813-2496-5740-7435-4456-6449-3602-9069-9014-8578;pass:END;sub:END;*/

Shader "Shader Forge/WaterPBR" {
    Properties {
        _ColourDeep ("Colour (Deep)", Color) = (0,0.3,0.2,1)
        _ColourShallow ("Colour (Shallow)", Color) = (0.4,0.8,1,1)
        _ColourFresnel ("Colour (Fresnel)", Range(0, 1.336)) = 1.336
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Glossiness ("Glossiness", Range(0, 1)) = 0.95
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _UVScale ("UV Scale", Float ) = 1
        _UV1Animator ("UV 1 Animator", Vector) = (0,0,0,0)
        _UV2Animator ("UV 2 Animator", Vector) = (0,0,0,0)
        _NormalMapStrength ("Normal Map Strength", Range(0, 1)) = 0
        _NoiseG ("Noise G", 2D) = "white" {}
        _Caustics ("Caustics", 2D) = "white" {}
        _Thickness ("Thickness", Range(0, 1)) = 0.7
        _Opacity ("Opacity", Range(0, 1)) = 0.4
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Glossiness;
            uniform float4 _ColourDeep;
            uniform float4 _ColourShallow;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _UVScale;
            uniform float4 _UV1Animator;
            uniform float4 _UV2Animator;
            uniform float _ColourFresnel;
            uniform float _Metallic;
            uniform float _NormalMapStrength;
            uniform sampler2D _NoiseG; uniform float4 _NoiseG_ST;
            uniform sampler2D _Caustics; uniform float4 _Caustics_ST;
            uniform float _Thickness;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_1773 = _Time + _TimeEditor;
                float2 _worldUV = (float2(i.posWorld.r,i.posWorld.b)/_UVScale);
                float2 node_3288 = _worldUV;
                float node_6523 = 1.0;
                float2 node_3998 = (node_3288*node_6523).rg;
                float2 _UV1 = float2(((_UV1Animator.r*node_1773.r)+node_3998.r),((_UV1Animator.g*node_1773.r)+node_3998.g));
                float2 node_8885 = _UV1;
                float3 node_9365 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_8885, _NormalMap)));
                float node_8302 = 1.0;
                float2 node_1828 = (node_3288*node_6523).rg;
                float2 _UV2t = float2(((_UV2Animator.r*node_1773.r)+node_1828.r),((_UV2Animator.g*node_1773.r)+node_1828.g));
                float2 node_9325 = _UV2t;
                float3 node_5502 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_9325, _NormalMap)));
                float3 normalLocal = lerp(float3((node_9365.rgb.rg*_NormalMapStrength),node_8302),float3((node_5502.rgb.rg*_NormalMapStrength),node_8302),0.5);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float perceptualRoughness = 1.0 - _Glossiness;
                float roughness = perceptualRoughness * perceptualRoughness;
/////// GI Data:
                UnityLight light; // Dummy light
                light.color = 0;
                light.dir = half3(0,1,0);
                light.ndotl = max(0,dot(normalDirection,light.dir));
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = 1;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
////// Specular:
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 diffuseColor = lerp(_ColourDeep.rgb,_ColourShallow.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),clamp(_ColourFresnel,0,1))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
////// Emissive:
                float4 node_1049 = _Time + _TimeEditor;
                float2 node_529 = (i.uv0*_worldUV);
                float2 node_7881 = (node_529+node_1049.g*float2(1,0.05));
                float4 _NoiseG_var = tex2D(_NoiseG,TRANSFORM_TEX(node_7881, _NoiseG));
                float2 node_305 = ((_NoiseG_var.g*0.1+0.0)+(node_529*0.9));
                float4 node_2552 = tex2D(_Caustics,TRANSFORM_TEX(node_305, _Caustics));
                float3 _Caustics = (((node_2552.rgb-(1.0 - _Thickness))*_Opacity)*i.vertexColor.a);
                float3 emissive = _Caustics;
/// Final Color:
                outDiffuse = half4( diffuseColor, 1 );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( _Caustics, 1 );
                outEmission.rgb += indirectSpecular * 1;
                outEmission.rgb += indirectDiffuse * diffuseColor;
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Glossiness;
            uniform float4 _ColourDeep;
            uniform float4 _ColourShallow;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _UVScale;
            uniform float4 _UV1Animator;
            uniform float4 _UV2Animator;
            uniform float _ColourFresnel;
            uniform float _Metallic;
            uniform float _NormalMapStrength;
            uniform sampler2D _NoiseG; uniform float4 _NoiseG_ST;
            uniform sampler2D _Caustics; uniform float4 _Caustics_ST;
            uniform float _Thickness;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_1773 = _Time + _TimeEditor;
                float2 _worldUV = (float2(i.posWorld.r,i.posWorld.b)/_UVScale);
                float2 node_3288 = _worldUV;
                float node_6523 = 1.0;
                float2 node_3998 = (node_3288*node_6523).rg;
                float2 _UV1 = float2(((_UV1Animator.r*node_1773.r)+node_3998.r),((_UV1Animator.g*node_1773.r)+node_3998.g));
                float2 node_8885 = _UV1;
                float3 node_9365 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_8885, _NormalMap)));
                float node_8302 = 1.0;
                float2 node_1828 = (node_3288*node_6523).rg;
                float2 _UV2t = float2(((_UV2Animator.r*node_1773.r)+node_1828.r),((_UV2Animator.g*node_1773.r)+node_1828.g));
                float2 node_9325 = _UV2t;
                float3 node_5502 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_9325, _NormalMap)));
                float3 normalLocal = lerp(float3((node_9365.rgb.rg*_NormalMapStrength),node_8302),float3((node_5502.rgb.rg*_NormalMapStrength),node_8302),0.5);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float perceptualRoughness = 1.0 - _Glossiness;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 diffuseColor = lerp(_ColourDeep.rgb,_ColourShallow.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),clamp(_ColourFresnel,0,1))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_9585 = _Time + _TimeEditor;
                float2 node_529 = (i.uv0*_worldUV);
                float2 node_7881 = (node_529+node_9585.g*float2(1,0.05));
                float4 _NoiseG_var = tex2D(_NoiseG,TRANSFORM_TEX(node_7881, _NoiseG));
                float2 node_305 = ((_NoiseG_var.g*0.1+0.0)+(node_529*0.9));
                float4 node_2552 = tex2D(_Caustics,TRANSFORM_TEX(node_305, _Caustics));
                float3 _Caustics = (((node_2552.rgb-(1.0 - _Thickness))*_Opacity)*i.vertexColor.a);
                float3 emissive = _Caustics;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Glossiness;
            uniform float4 _ColourDeep;
            uniform float4 _ColourShallow;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _UVScale;
            uniform float4 _UV1Animator;
            uniform float4 _UV2Animator;
            uniform float _ColourFresnel;
            uniform float _Metallic;
            uniform float _NormalMapStrength;
            uniform sampler2D _NoiseG; uniform float4 _NoiseG_ST;
            uniform sampler2D _Caustics; uniform float4 _Caustics_ST;
            uniform float _Thickness;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_1773 = _Time + _TimeEditor;
                float2 _worldUV = (float2(i.posWorld.r,i.posWorld.b)/_UVScale);
                float2 node_3288 = _worldUV;
                float node_6523 = 1.0;
                float2 node_3998 = (node_3288*node_6523).rg;
                float2 _UV1 = float2(((_UV1Animator.r*node_1773.r)+node_3998.r),((_UV1Animator.g*node_1773.r)+node_3998.g));
                float2 node_8885 = _UV1;
                float3 node_9365 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_8885, _NormalMap)));
                float node_8302 = 1.0;
                float2 node_1828 = (node_3288*node_6523).rg;
                float2 _UV2t = float2(((_UV2Animator.r*node_1773.r)+node_1828.r),((_UV2Animator.g*node_1773.r)+node_1828.g));
                float2 node_9325 = _UV2t;
                float3 node_5502 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_9325, _NormalMap)));
                float3 normalLocal = lerp(float3((node_9365.rgb.rg*_NormalMapStrength),node_8302),float3((node_5502.rgb.rg*_NormalMapStrength),node_8302),0.5);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float perceptualRoughness = 1.0 - _Glossiness;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 diffuseColor = lerp(_ColourDeep.rgb,_ColourShallow.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),clamp(_ColourFresnel,0,1))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Glossiness;
            uniform float4 _ColourDeep;
            uniform float4 _ColourShallow;
            uniform float _UVScale;
            uniform float _ColourFresnel;
            uniform float _Metallic;
            uniform sampler2D _NoiseG; uniform float4 _NoiseG_ST;
            uniform sampler2D _Caustics; uniform float4 _Caustics_ST;
            uniform float _Thickness;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_65 = _Time + _TimeEditor;
                float2 _worldUV = (float2(i.posWorld.r,i.posWorld.b)/_UVScale);
                float2 node_529 = (i.uv0*_worldUV);
                float2 node_7881 = (node_529+node_65.g*float2(1,0.05));
                float4 _NoiseG_var = tex2D(_NoiseG,TRANSFORM_TEX(node_7881, _NoiseG));
                float2 node_305 = ((_NoiseG_var.g*0.1+0.0)+(node_529*0.9));
                float4 node_2552 = tex2D(_Caustics,TRANSFORM_TEX(node_305, _Caustics));
                float3 _Caustics = (((node_2552.rgb-(1.0 - _Thickness))*_Opacity)*i.vertexColor.a);
                o.Emission = _Caustics;
                
                float3 diffColor = lerp(_ColourDeep.rgb,_ColourShallow.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),clamp(_ColourFresnel,0,1)));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Glossiness;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
