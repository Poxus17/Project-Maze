Shader "Ciconia Studio/CS_Standard/URP/Standard (Specular setup)/Transparent"
{
	Properties
	{

		[Space(35)][Header(Surface Options )]
		[Space(15)][Enum(Off,2,On,0)] _Cull("Double Sided", Float) = 0 //"Back"
		[Enum(Off,0,On,1)] _ZWrite("ZWrite", Float) = 1.0 //"On"
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4 //"LessEqual"

		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[ASEBegin][Space(35)][Header(Main Properties )][Space(15)]_GlobalXYTilingXYZWOffsetXY("Global --> XY(TilingXY) - ZW(OffsetXY)", Vector) = (1,1,0,0)
		_Color("Color", Color) = (1,1,1,0)
		[Toggle]_InvertABaseColor("Invert Alpha", Float) = 0
		_BaseMap("Base Color  -->(Mask A)", 2D) = "white" {}
		_Saturation("Saturation", Float) = 0
		_Brightness("Brightness", Range( 1 , 8)) = 1
		[Space(35)]_BumpMap("Normal Map", 2D) = "bump" {}
		_BumpScale("Normal Intensity", Float) = 0.3
		[Space(35)]_SpecularColor("Specular Color", Color) = (1,1,1,0)
		_SpecGlossMap("Specular Map -->(Smoothness A)", 2D) = "white" {}
		_SpecularIntensity("Specular Intensity", Range( 0 , 2)) = 0.2
		_Smoothness("Smoothness", Range( 0 , 2)) = 0.5
		[Space(10)][KeywordEnum(SpecularAlpha,BaseColorAlpha)] _Source("Source", Float) = 0
		[Space(35)]_ParallaxMap("Height Map", 2D) = "white" {}
		_Parallax("Height Scale", Range( -0.1 , 0.1)) = 0
		[Space(35)]_OcclusionMap("Ambient Occlusion Map", 2D) = "white" {}
		_OcclusionStrength("Ao Intensity", Range( 0 , 2)) = 1
		[HDR][Space(35)]_EmissionColor("Emission Color", Color) = (0,0,0,0)
		_EmissionMap("Emission Map", 2D) = "white" {}
		_EmissionIntensity("Intensity", Range( 0 , 2)) = 1
		[Space(35)][Header(Mask Properties)][Toggle]_EnableDetailMask("Enable", Float) = 0
		[Space(15)][Toggle]_VisualizeMask("Visualize Mask", Float) = 0
		[Space(15)][Toggle]_EnableTriplanarProjection("Enable Triplanar Projection", Float) = 1
		[KeywordEnum(ObjectSpace,WorldSpace)] _TriplanarSpaceProjection("Space Projection", Float) = 0
		_TriplanarFalloff("Falloff", Float) = 20
		_TriplanarXYTilingXYZWOffsetXY("Triplanar --> XY(TilingXY) - ZW(OffsetXY)  ", Vector) = (1,1,0,0)
		[Toggle]_InvertMask("Invert Mask", Float) = 0
		[Space(15)][KeywordEnum(Red,Green,Blue,Alpha)] _ChannelSelectionMask1("Channel Selection", Float) = 0
		_DetailMask("Detail Mask", 2D) = "white" {}
		_IntensityMask("Intensity", Range( 0 , 1)) = 1
		[Space(15)]_ContrastDetailMap("Contrast", Float) = 0
		_SpreadDetailMap("Spread", Float) = 0
		[Space(35)][Header(Detail Properties)][Space(15)][KeywordEnum(None,Overlay)] _Blendmode("Blend mode", Float) = 0
		[Space(35)]_DetailColor("Color", Color) = (1,1,1,0)
		_DetailAlbedoMap("Base Color", 2D) = "white" {}
		_DetailSaturation("Saturation", Float) = 0
		_DetailBrightness("Brightness", Range( 1 , 8)) = 1
		[Space(35)][Toggle]_BlendMainNormal("Blend Main Normal", Float) = 0
		_DetailNormalMap("Normal Map", 2D) = "bump" {}
		_DetailNormalMapScale("Scale", Float) = 0.3
		[Space(35)]_DetailSpecularColor("Specular Color", Color) = (1,1,1,0)
		_DetailSpecGlossMap("Specular Map -->(Smoothness A)", 2D) = "white" {}
		_DetailSpecularIntensity("Specular Intensity", Range( 0 , 2)) = 0.2
		_DetailGlossiness("Smoothness", Range( 0 , 2)) = 0.5
		[Space(10)][KeywordEnum(SpecularAlpha,AlbedoAlpha)] _DetailSource("Source", Float) = 0
		[Space(15)][Toggle]_UseAoFromMainProperties("Use Ao From Main Properties", Float) = 1
		[Toggle]_UseEmissionFromMainProperties("Use Emission From Main Properties", Float) = 1
		[Space(35)][Header(Transparent Properties)][Space(15)][Toggle]_InvertTransparent("Invert ", Float) = 0
		[Toggle]_UseBaseColorAlpha("Use BaseColor Alpha", Float) = 0
		[Space(15)][KeywordEnum(Red,Green,Blue,Alpha)] _ChannelSelection("Channel Selection", Float) = 0
		_TransparentMask("Transparent Mask", 2D) = "white" {}
		_IntensityTransparentMap("Opacity", Range( 0 , 1)) = 0
		[Space(15)]_ContrastTransparentMap("Contrast", Float) = 0
		[ASEEnd]_SpreadTransparentMap("Spread", Float) = 0

		//_TransmissionShadow( "Transmission Shadow", Range( 0, 1 ) ) = 0.5
		//_TransStrength( "Trans Strength", Range( 0, 50 ) ) = 1
		//_TransNormal( "Trans Normal Distortion", Range( 0, 1 ) ) = 0.5
		//_TransScattering( "Trans Scattering", Range( 1, 50 ) ) = 2
		//_TransDirect( "Trans Direct", Range( 0, 1 ) ) = 0.9
		//_TransAmbient( "Trans Ambient", Range( 0, 1 ) ) = 0.1
		//_TransShadow( "Trans Shadow", Range( 0, 1 ) ) = 0.5
		//_TessPhongStrength( "Tess Phong Strength", Range( 0, 1 ) ) = 0.5
		//_TessValue( "Tess Max Tessellation", Range( 1, 32 ) ) = 16
		//_TessMin( "Tess Min Distance", Float ) = 10
		//_TessMax( "Tess Max Distance", Float ) = 25
		//_TessEdgeLength ( "Tess Edge length", Range( 2, 50 ) ) = 16
		//_TessMaxDisp( "Tess Max Displacement", Float ) = 25
	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" }
		Cull[_Cull]
		ZWrite[_ZWrite]
		ZTest [_ZTest]
		AlphaToMask Off
		HLSLINCLUDE
		#pragma target 3.0

		float4 FixedTess( float tessValue )
		{
			return tessValue;
		}
		
		float CalcDistanceTessFactor (float4 vertex, float minDist, float maxDist, float tess, float4x4 o2w, float3 cameraPos )
		{
			float3 wpos = mul(o2w,vertex).xyz;
			float dist = distance (wpos, cameraPos);
			float f = clamp(1.0 - (dist - minDist) / (maxDist - minDist), 0.01, 1.0) * tess;
			return f;
		}

		float4 CalcTriEdgeTessFactors (float3 triVertexFactors)
		{
			float4 tess;
			tess.x = 0.5 * (triVertexFactors.y + triVertexFactors.z);
			tess.y = 0.5 * (triVertexFactors.x + triVertexFactors.z);
			tess.z = 0.5 * (triVertexFactors.x + triVertexFactors.y);
			tess.w = (triVertexFactors.x + triVertexFactors.y + triVertexFactors.z) / 3.0f;
			return tess;
		}

		float CalcEdgeTessFactor (float3 wpos0, float3 wpos1, float edgeLen, float3 cameraPos, float4 scParams )
		{
			float dist = distance (0.5 * (wpos0+wpos1), cameraPos);
			float len = distance(wpos0, wpos1);
			float f = max(len * scParams.y / (edgeLen * dist), 1.0);
			return f;
		}

		float DistanceFromPlane (float3 pos, float4 plane)
		{
			float d = dot (float4(pos,1.0f), plane);
			return d;
		}

		bool WorldViewFrustumCull (float3 wpos0, float3 wpos1, float3 wpos2, float cullEps, float4 planes[6] )
		{
			float4 planeTest;
			planeTest.x = (( DistanceFromPlane(wpos0, planes[0]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[0]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[0]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.y = (( DistanceFromPlane(wpos0, planes[1]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[1]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[1]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.z = (( DistanceFromPlane(wpos0, planes[2]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[2]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[2]) > -cullEps) ? 1.0f : 0.0f );
			planeTest.w = (( DistanceFromPlane(wpos0, planes[3]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos1, planes[3]) > -cullEps) ? 1.0f : 0.0f ) +
						  (( DistanceFromPlane(wpos2, planes[3]) > -cullEps) ? 1.0f : 0.0f );
			return !all (planeTest);
		}

		float4 DistanceBasedTess( float4 v0, float4 v1, float4 v2, float tess, float minDist, float maxDist, float4x4 o2w, float3 cameraPos )
		{
			float3 f;
			f.x = CalcDistanceTessFactor (v0,minDist,maxDist,tess,o2w,cameraPos);
			f.y = CalcDistanceTessFactor (v1,minDist,maxDist,tess,o2w,cameraPos);
			f.z = CalcDistanceTessFactor (v2,minDist,maxDist,tess,o2w,cameraPos);

			return CalcTriEdgeTessFactors (f);
		}

		float4 EdgeLengthBasedTess( float4 v0, float4 v1, float4 v2, float edgeLength, float4x4 o2w, float3 cameraPos, float4 scParams )
		{
			float3 pos0 = mul(o2w,v0).xyz;
			float3 pos1 = mul(o2w,v1).xyz;
			float3 pos2 = mul(o2w,v2).xyz;
			float4 tess;
			tess.x = CalcEdgeTessFactor (pos1, pos2, edgeLength, cameraPos, scParams);
			tess.y = CalcEdgeTessFactor (pos2, pos0, edgeLength, cameraPos, scParams);
			tess.z = CalcEdgeTessFactor (pos0, pos1, edgeLength, cameraPos, scParams);
			tess.w = (tess.x + tess.y + tess.z) / 3.0f;
			return tess;
		}

		float4 EdgeLengthBasedTessCull( float4 v0, float4 v1, float4 v2, float edgeLength, float maxDisplacement, float4x4 o2w, float3 cameraPos, float4 scParams, float4 planes[6] )
		{
			float3 pos0 = mul(o2w,v0).xyz;
			float3 pos1 = mul(o2w,v1).xyz;
			float3 pos2 = mul(o2w,v2).xyz;
			float4 tess;

			if (WorldViewFrustumCull(pos0, pos1, pos2, maxDisplacement, planes))
			{
				tess = 0.0f;
			}
			else
			{
				tess.x = CalcEdgeTessFactor (pos1, pos2, edgeLength, cameraPos, scParams);
				tess.y = CalcEdgeTessFactor (pos2, pos0, edgeLength, cameraPos, scParams);
				tess.z = CalcEdgeTessFactor (pos0, pos1, edgeLength, cameraPos, scParams);
				tess.w = (tess.x + tess.y + tess.z) / 3.0f;
			}
			return tess;
		}
		ENDHLSL

		
		Pass
		{
			
			Name "Forward"
			Tags { "LightMode"="UniversalForward" }
			
			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
			#pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile _ _SHADOWS_SOFT
			#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
			
			#pragma multi_compile _ DIRLIGHTMAP_COMBINED
			#pragma multi_compile _ LIGHTMAP_ON

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_FORWARD

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			
			#if ASE_SRP_VERSION <= 70108
			#define REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
			#endif

			#if defined(UNITY_INSTANCING_ENABLED) && defined(_TERRAIN_INSTANCED_PERPIXEL_NORMAL)
			    #define ENABLE_TERRAIN_PERPIXEL_NORMAL
			#endif

			#define ASE_NEEDS_FRAG_WORLD_TANGENT
			#define ASE_NEEDS_FRAG_WORLD_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_BITANGENT
			#define ASE_NEEDS_FRAG_WORLD_VIEW_DIR
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_NORMAL
			#pragma shader_feature_local _BLENDMODE_NONE _BLENDMODE_OVERLAY
			#pragma multi_compile_instancing
			#pragma shader_feature_local _CHANNELSELECTIONMASK1_RED _CHANNELSELECTIONMASK1_GREEN _CHANNELSELECTIONMASK1_BLUE _CHANNELSELECTIONMASK1_ALPHA
			#pragma shader_feature_local _TRIPLANARSPACEPROJECTION_OBJECTSPACE _TRIPLANARSPACEPROJECTION_WORLDSPACE
			#pragma shader_feature_local _SOURCE_SPECULARALPHA _SOURCE_BASECOLORALPHA
			#pragma shader_feature_local _DETAILSOURCE_SPECULARALPHA _DETAILSOURCE_ALBEDOALPHA
			#pragma shader_feature_local _CHANNELSELECTION_RED _CHANNELSELECTION_GREEN _CHANNELSELECTION_BLUE _CHANNELSELECTION_ALPHA


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 lightmapUVOrVertexSH : TEXCOORD0;
				half4 fogFactorAndVertexLight : TEXCOORD1;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				float4 shadowCoord : TEXCOORD2;
				#endif
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 screenPos : TEXCOORD6;
				#endif
				float4 ase_texcoord7 : TEXCOORD7;
				float4 ase_texcoord8 : TEXCOORD8;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _SpecularColor;
			float4 _Color;
			float4 _GlobalXYTilingXYZWOffsetXY;
			float4 _DetailSpecularColor;
			float4 _TriplanarXYTilingXYZWOffsetXY;
			float4 _DetailColor;
			float _SpecularIntensity;
			float _DetailSpecularIntensity;
			float _Smoothness;
			float _DetailGlossiness;
			float _EmissionIntensity;
			float _UseAoFromMainProperties;
			float _OcclusionStrength;
			float _ContrastTransparentMap;
			float _InvertTransparent;
			float _UseBaseColorAlpha;
			float _InvertABaseColor;
			float _VisualizeMask;
			float _BumpScale;
			float _DetailNormalMapScale;
			float _SpreadTransparentMap;
			float _BlendMainNormal;
			float _IntensityMask;
			float _SpreadDetailMap;
			float _EnableTriplanarProjection;
			float _InvertMask;
			float _ContrastDetailMap;
			float _EnableDetailMask;
			float _DetailSaturation;
			float _DetailBrightness;
			float _Saturation;
			float _Parallax;
			float _Brightness;
			float _UseEmissionFromMainProperties;
			float _IntensityTransparentMap;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _BaseMap;
			sampler2D _ParallaxMap;
			sampler2D _DetailAlbedoMap;
			sampler2D _DetailMask;
			sampler2D _BumpMap;
			sampler2D _DetailNormalMap;
			sampler2D _EmissionMap;
			sampler2D _SpecGlossMap;
			sampler2D _DetailSpecGlossMap;
			sampler2D _OcclusionMap;
			sampler2D _TransparentMask;
			UNITY_INSTANCING_BUFFER_START(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)
				UNITY_DEFINE_INSTANCED_PROP(float4, _BaseMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _ParallaxMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _DetailAlbedoMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _BumpMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _DetailNormalMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _EmissionMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _SpecGlossMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _DetailSpecGlossMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _OcclusionMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _TransparentMask_ST)
				UNITY_DEFINE_INSTANCED_PROP(float, _TriplanarFalloff)
			UNITY_INSTANCING_BUFFER_END(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)


			inline float2 ParallaxOffset( half h, half height, half3 viewDir )
			{
				h = h * height - height/2.0;
				float3 v = normalize( viewDir );
				v.z += 0.42;
				return h* (v.xy / v.z);
			}
			
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}
			inline float4 TriplanarSampling393( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				o.ase_texcoord7.xy = v.texcoord.xy;
				o.ase_texcoord8 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord7.zw = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float3 positionVS = TransformWorldToView( positionWS );
				float4 positionCS = TransformWorldToHClip( positionWS );

				VertexNormalInputs normalInput = GetVertexNormalInputs( v.ase_normal, v.ase_tangent );

				o.tSpace0 = float4( normalInput.normalWS, positionWS.x);
				o.tSpace1 = float4( normalInput.tangentWS, positionWS.y);
				o.tSpace2 = float4( normalInput.bitangentWS, positionWS.z);

				OUTPUT_LIGHTMAP_UV( v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy );
				OUTPUT_SH( normalInput.normalWS.xyz, o.lightmapUVOrVertexSH.xyz );

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					o.lightmapUVOrVertexSH.zw = v.texcoord;
					o.lightmapUVOrVertexSH.xy = v.texcoord * unity_LightmapST.xy + unity_LightmapST.zw;
				#endif

				half3 vertexLight = VertexLighting( positionWS, normalInput.normalWS );
				#ifdef ASE_FOG
					half fogFactor = ComputeFogFactor( positionCS.z );
				#else
					half fogFactor = 0;
				#endif
				o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
				
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				VertexPositionInputs vertexInput = (VertexPositionInputs)0;
				vertexInput.positionWS = positionWS;
				vertexInput.positionCS = positionCS;
				o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				
				o.clipPos = positionCS;
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				o.screenPos = ComputeScreenPos(positionCS);
				#endif
				return o;
			}
			
			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_tangent = v.ase_tangent;
				o.texcoord = v.texcoord;
				o.texcoord1 = v.texcoord1;
				
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				o.texcoord = patch[0].texcoord * bary.x + patch[1].texcoord * bary.y + patch[2].texcoord * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag ( VertexOutput IN , half ase_vface : VFACE ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif

				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float2 sampleCoords = (IN.lightmapUVOrVertexSH.zw / _TerrainHeightmapRecipSize.zw + 0.5f) * _TerrainHeightmapRecipSize.xy;
					float3 WorldNormal = TransformObjectToWorldNormal(normalize(SAMPLE_TEXTURE2D(_TerrainNormalmapTexture, sampler_TerrainNormalmapTexture, sampleCoords).rgb * 2 - 1));
					float3 WorldTangent = -cross(GetObjectToWorldMatrix()._13_23_33, WorldNormal);
					float3 WorldBiTangent = cross(WorldNormal, -WorldTangent);
				#else
					float3 WorldNormal = normalize( IN.tSpace0.xyz );
					float3 WorldTangent = IN.tSpace1.xyz;
					float3 WorldBiTangent = IN.tSpace2.xyz;
				#endif
				float3 WorldPosition = float3(IN.tSpace0.w,IN.tSpace1.w,IN.tSpace2.w);
				float3 WorldViewDirection = _WorldSpaceCameraPos.xyz  - WorldPosition;
				float4 ShadowCoords = float4( 0, 0, 0, 0 );
				#if defined(ASE_NEEDS_FRAG_SCREEN_POSITION)
				float4 ScreenPos = IN.screenPos;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
					ShadowCoords = IN.shadowCoord;
				#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
					ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
				#endif
	
				WorldViewDirection = SafeNormalize( WorldViewDirection );

				float4 _BaseMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_BaseMap_ST);
				float2 uv_BaseMap = IN.ase_texcoord7.xy * _BaseMap_ST_Instance.xy + _BaseMap_ST_Instance.zw;
				float2 break26_g633 = uv_BaseMap;
				float GlobalTilingX11 = ( _GlobalXYTilingXYZWOffsetXY.x - 1.0 );
				float GlobalTilingY8 = ( _GlobalXYTilingXYZWOffsetXY.y - 1.0 );
				float2 appendResult14_g633 = (float2(( break26_g633.x * GlobalTilingX11 ) , ( break26_g633.y * GlobalTilingY8 )));
				float GlobalOffsetX10 = _GlobalXYTilingXYZWOffsetXY.z;
				float GlobalOffsetY9 = _GlobalXYTilingXYZWOffsetXY.w;
				float2 appendResult13_g633 = (float2(( break26_g633.x + GlobalOffsetX10 ) , ( break26_g633.y + GlobalOffsetY9 )));
				float4 _ParallaxMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_ParallaxMap_ST);
				float2 uv_ParallaxMap = IN.ase_texcoord7.xy * _ParallaxMap_ST_Instance.xy + _ParallaxMap_ST_Instance.zw;
				float2 break26_g467 = uv_ParallaxMap;
				float2 appendResult14_g467 = (float2(( break26_g467.x * GlobalTilingX11 ) , ( break26_g467.y * GlobalTilingY8 )));
				float2 appendResult13_g467 = (float2(( break26_g467.x + GlobalOffsetX10 ) , ( break26_g467.y + GlobalOffsetY9 )));
				float4 temp_cast_0 = (tex2D( _ParallaxMap, ( appendResult14_g467 + appendResult13_g467 ) ).g).xxxx;
				float3 tanToWorld0 = float3( WorldTangent.x, WorldBiTangent.x, WorldNormal.x );
				float3 tanToWorld1 = float3( WorldTangent.y, WorldBiTangent.y, WorldNormal.y );
				float3 tanToWorld2 = float3( WorldTangent.z, WorldBiTangent.z, WorldNormal.z );
				float3 ase_tanViewDir =  tanToWorld0 * WorldViewDirection.x + tanToWorld1 * WorldViewDirection.y  + tanToWorld2 * WorldViewDirection.z;
				ase_tanViewDir = normalize(ase_tanViewDir);
				float2 paralaxOffset36_g466 = ParallaxOffset( temp_cast_0.x , _Parallax , ase_tanViewDir );
				float2 switchResult47_g466 = (((ase_vface>0)?(paralaxOffset36_g466):(0.0)));
				float2 Parallaxe368 = switchResult47_g466;
				float4 tex2DNode7_g632 = tex2D( _BaseMap, ( ( appendResult14_g633 + appendResult13_g633 ) + Parallaxe368 ) );
				float clampResult27_g632 = clamp( _Saturation , -1.0 , 100.0 );
				float3 desaturateInitialColor29_g632 = ( _Color * tex2DNode7_g632 ).rgb;
				float desaturateDot29_g632 = dot( desaturateInitialColor29_g632, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar29_g632 = lerp( desaturateInitialColor29_g632, desaturateDot29_g632.xxx, -clampResult27_g632 );
				float4 temp_output_411_0 = CalculateContrast(_Brightness,float4( desaturateVar29_g632 , 0.0 ));
				float4 _DetailAlbedoMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_DetailAlbedoMap_ST);
				float2 uv_DetailAlbedoMap = IN.ase_texcoord7.xy * _DetailAlbedoMap_ST_Instance.xy + _DetailAlbedoMap_ST_Instance.zw;
				float4 tex2DNode7_g468 = tex2D( _DetailAlbedoMap, uv_DetailAlbedoMap );
				float clampResult27_g468 = clamp( _DetailSaturation , -1.0 , 100.0 );
				float3 desaturateInitialColor29_g468 = ( _DetailColor * tex2DNode7_g468 ).rgb;
				float desaturateDot29_g468 = dot( desaturateInitialColor29_g468, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar29_g468 = lerp( desaturateInitialColor29_g468, desaturateDot29_g468.xxx, -clampResult27_g468 );
				float4 AlbedoDetail153 = CalculateContrast(_DetailBrightness,float4( desaturateVar29_g468 , 0.0 ));
				float4 temp_cast_6 = (0.0).xxxx;
				float2 texCoord387 = IN.ase_texcoord7.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode392 = tex2D( _DetailMask, texCoord387 );
				#if defined(_CHANNELSELECTIONMASK1_RED)
				float staticSwitch424 = tex2DNode392.r;
				#elif defined(_CHANNELSELECTIONMASK1_GREEN)
				float staticSwitch424 = tex2DNode392.g;
				#elif defined(_CHANNELSELECTIONMASK1_BLUE)
				float staticSwitch424 = tex2DNode392.b;
				#elif defined(_CHANNELSELECTIONMASK1_ALPHA)
				float staticSwitch424 = tex2DNode392.a;
				#else
				float staticSwitch424 = tex2DNode392.r;
				#endif
				float2 appendResult389 = (float2(_TriplanarXYTilingXYZWOffsetXY.x , _TriplanarXYTilingXYZWOffsetXY.y));
				float _TriplanarFalloff_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TriplanarFalloff);
				#if defined(_TRIPLANARSPACEPROJECTION_OBJECTSPACE)
				float3 staticSwitch386 = IN.ase_texcoord8.xyz;
				#elif defined(_TRIPLANARSPACEPROJECTION_WORLDSPACE)
				float3 staticSwitch386 = WorldPosition;
				#else
				float3 staticSwitch386 = IN.ase_texcoord8.xyz;
				#endif
				float2 appendResult385 = (float2(_TriplanarXYTilingXYZWOffsetXY.z , _TriplanarXYTilingXYZWOffsetXY.w));
				float4 triplanar393 = TriplanarSampling393( _DetailMask, ( staticSwitch386 + float3( appendResult385 ,  0.0 ) ), IN.ase_normal, _TriplanarFalloff_Instance, appendResult389, 1.0, 0 );
				#if defined(_CHANNELSELECTIONMASK1_RED)
				float staticSwitch423 = triplanar393.x;
				#elif defined(_CHANNELSELECTIONMASK1_GREEN)
				float staticSwitch423 = triplanar393.y;
				#elif defined(_CHANNELSELECTIONMASK1_BLUE)
				float staticSwitch423 = triplanar393.z;
				#elif defined(_CHANNELSELECTIONMASK1_ALPHA)
				float staticSwitch423 = triplanar393.w;
				#else
				float staticSwitch423 = triplanar393.x;
				#endif
				float4 temp_cast_12 = ((( _InvertMask )?( ( 1.0 - (( _EnableTriplanarProjection )?( staticSwitch423 ):( staticSwitch424 )) ) ):( (( _EnableTriplanarProjection )?( staticSwitch423 ):( staticSwitch424 )) ))).xxxx;
				float4 clampResult407 = clamp( ( CalculateContrast(( _ContrastDetailMap + 1.0 ),temp_cast_12) + -_SpreadDetailMap ) , float4( 0,0,0,0 ) , float4( 1,1,1,0 ) );
				float MaskIntensity405 = _IntensityMask;
				float4 Mask158 = (( _EnableDetailMask )?( ( clampResult407 * MaskIntensity405 ) ):( temp_cast_6 ));
				float4 lerpResult343 = lerp( temp_output_411_0 , AlbedoDetail153 , Mask158);
				float4 blendOpSrc15_g634 = temp_output_411_0;
				float4 blendOpDest15_g634 = lerpResult343;
				float4 lerpBlendMode15_g634 = lerp(blendOpDest15_g634,(( blendOpDest15_g634 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest15_g634 ) * ( 1.0 - blendOpSrc15_g634 ) ) : ( 2.0 * blendOpDest15_g634 * blendOpSrc15_g634 ) ),Mask158.x);
				#if defined(_BLENDMODE_NONE)
				float4 staticSwitch22_g634 = lerpResult343;
				#elif defined(_BLENDMODE_OVERLAY)
				float4 staticSwitch22_g634 = ( saturate( lerpBlendMode15_g634 ));
				#else
				float4 staticSwitch22_g634 = lerpResult343;
				#endif
				float4 Albedo26 = (( _VisualizeMask )?( Mask158 ):( staticSwitch22_g634 ));
				
				float4 _BumpMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_BumpMap_ST);
				float2 uv_BumpMap = IN.ase_texcoord7.xy * _BumpMap_ST_Instance.xy + _BumpMap_ST_Instance.zw;
				float2 break26_g665 = uv_BumpMap;
				float2 appendResult14_g665 = (float2(( break26_g665.x * GlobalTilingX11 ) , ( break26_g665.y * GlobalTilingY8 )));
				float2 appendResult13_g665 = (float2(( break26_g665.x + GlobalOffsetX10 ) , ( break26_g665.y + GlobalOffsetY9 )));
				float3 unpack4_g664 = UnpackNormalScale( tex2D( _BumpMap, ( ( appendResult14_g665 + appendResult13_g665 ) + Parallaxe368 ) ), _BumpScale );
				unpack4_g664.z = lerp( 1, unpack4_g664.z, saturate(_BumpScale) );
				float3 temp_output_412_0 = unpack4_g664;
				float4 _DetailNormalMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_DetailNormalMap_ST);
				float2 uv_DetailNormalMap = IN.ase_texcoord7.xy * _DetailNormalMap_ST_Instance.xy + _DetailNormalMap_ST_Instance.zw;
				float3 unpack4_g668 = UnpackNormalScale( tex2D( _DetailNormalMap, uv_DetailNormalMap ), _DetailNormalMapScale );
				unpack4_g668.z = lerp( 1, unpack4_g668.z, saturate(_DetailNormalMapScale) );
				float3 NormalDetail155 = unpack4_g668;
				float3 lerpResult137 = lerp( temp_output_412_0 , NormalDetail155 , Mask158.rgb);
				float3 lerpResult205 = lerp( temp_output_412_0 , BlendNormal( temp_output_412_0 , NormalDetail155 ) , Mask158.rgb);
				float3 Normal27 = (( _BlendMainNormal )?( lerpResult205 ):( lerpResult137 ));
				
				float4 _EmissionMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_EmissionMap_ST);
				float2 uv_EmissionMap = IN.ase_texcoord7.xy * _EmissionMap_ST_Instance.xy + _EmissionMap_ST_Instance.zw;
				float2 break26_g667 = uv_EmissionMap;
				float2 appendResult14_g667 = (float2(( break26_g667.x * GlobalTilingX11 ) , ( break26_g667.y * GlobalTilingY8 )));
				float2 appendResult13_g667 = (float2(( break26_g667.x + GlobalOffsetX10 ) , ( break26_g667.y + GlobalOffsetY9 )));
				float4 temp_output_415_0 = ( _EmissionColor * tex2D( _EmissionMap, ( ( appendResult14_g667 + appendResult13_g667 ) + Parallaxe368 ) ) * _EmissionIntensity );
				float4 temp_cast_22 = (0.0).xxxx;
				float4 lerpResult190 = lerp( temp_output_415_0 , temp_cast_22 , Mask158);
				float4 Emission110 = (( _UseEmissionFromMainProperties )?( temp_output_415_0 ):( lerpResult190 ));
				
				float4 _SpecGlossMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_SpecGlossMap_ST);
				float2 uv_SpecGlossMap = IN.ase_texcoord7.xy * _SpecGlossMap_ST_Instance.xy + _SpecGlossMap_ST_Instance.zw;
				float2 break26_g663 = uv_SpecGlossMap;
				float2 appendResult14_g663 = (float2(( break26_g663.x * GlobalTilingX11 ) , ( break26_g663.y * GlobalTilingY8 )));
				float2 appendResult13_g663 = (float2(( break26_g663.x + GlobalOffsetX10 ) , ( break26_g663.y + GlobalOffsetY9 )));
				float4 tex2DNode3_g662 = tex2D( _SpecGlossMap, ( ( appendResult14_g663 + appendResult13_g663 ) + Parallaxe368 ) );
				float4 _DetailSpecGlossMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_DetailSpecGlossMap_ST);
				float2 uv_DetailSpecGlossMap = IN.ase_texcoord7.xy * _DetailSpecGlossMap_ST_Instance.xy + _DetailSpecGlossMap_ST_Instance.zw;
				float4 tex2DNode3_g661 = tex2D( _DetailSpecGlossMap, uv_DetailSpecGlossMap );
				float4 DetailMetallic176 = ( _DetailSpecularColor * tex2DNode3_g661 * _DetailSpecularIntensity );
				float4 lerpResult179 = lerp( ( _SpecularColor * tex2DNode3_g662 * _SpecularIntensity ) , DetailMetallic176 , Mask158);
				float4 Specular41 = lerpResult179;
				
				float BaseColorAlpha46 = (( _InvertABaseColor )?( ( 1.0 - tex2DNode7_g632.a ) ):( tex2DNode7_g632.a ));
				#if defined(_SOURCE_SPECULARALPHA)
				float staticSwitch31_g662 = ( tex2DNode3_g662.a * _Smoothness );
				#elif defined(_SOURCE_BASECOLORALPHA)
				float staticSwitch31_g662 = ( _Smoothness * BaseColorAlpha46 );
				#else
				float staticSwitch31_g662 = ( tex2DNode3_g662.a * _Smoothness );
				#endif
				float DetailBaseColorAlpha170 = tex2DNode7_g468.a;
				#if defined(_DETAILSOURCE_SPECULARALPHA)
				float staticSwitch31_g661 = ( tex2DNode3_g661.a * _DetailGlossiness );
				#elif defined(_DETAILSOURCE_ALBEDOALPHA)
				float staticSwitch31_g661 = ( _DetailGlossiness * DetailBaseColorAlpha170 );
				#else
				float staticSwitch31_g661 = ( tex2DNode3_g661.a * _DetailGlossiness );
				#endif
				float DetailSmoothness175 = staticSwitch31_g661;
				float lerpResult182 = lerp( staticSwitch31_g662 , DetailSmoothness175 , Mask158.r);
				float Smoothness40 = lerpResult182;
				
				float4 _OcclusionMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_OcclusionMap_ST);
				float2 uv_OcclusionMap = IN.ase_texcoord7.xy * _OcclusionMap_ST_Instance.xy + _OcclusionMap_ST_Instance.zw;
				float2 break26_g660 = uv_OcclusionMap;
				float2 appendResult14_g660 = (float2(( break26_g660.x * GlobalTilingX11 ) , ( break26_g660.y * GlobalTilingY8 )));
				float2 appendResult13_g660 = (float2(( break26_g660.x + GlobalOffsetX10 ) , ( break26_g660.y + GlobalOffsetY9 )));
				float blendOpSrc2_g659 = tex2D( _OcclusionMap, ( ( appendResult14_g660 + appendResult13_g660 ) + Parallaxe368 ) ).r;
				float blendOpDest2_g659 = ( 1.0 - _OcclusionStrength );
				float temp_output_414_0 = ( saturate( ( 1.0 - ( 1.0 - blendOpSrc2_g659 ) * ( 1.0 - blendOpDest2_g659 ) ) ));
				float lerpResult185 = lerp( temp_output_414_0 , 1.0 , Mask158.r);
				float AmbientOcclusion94 = (( _UseAoFromMainProperties )?( temp_output_414_0 ):( lerpResult185 ));
				
				float4 _TransparentMask_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TransparentMask_ST);
				float2 uv_TransparentMask = IN.ase_texcoord7.xy * _TransparentMask_ST_Instance.xy + _TransparentMask_ST_Instance.zw;
				float4 tex2DNode8_g642 = tex2D( _TransparentMask, uv_TransparentMask );
				#if defined(_CHANNELSELECTION_RED)
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#elif defined(_CHANNELSELECTION_GREEN)
				float staticSwitch30_g642 = tex2DNode8_g642.g;
				#elif defined(_CHANNELSELECTION_BLUE)
				float staticSwitch30_g642 = tex2DNode8_g642.b;
				#elif defined(_CHANNELSELECTION_ALPHA)
				float staticSwitch30_g642 = tex2DNode8_g642.a;
				#else
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#endif
				float4 temp_cast_27 = ((( _InvertTransparent )?( ( 1.0 - (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ) ):( (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ))).xxxx;
				float4 clampResult24_g642 = clamp( ( CalculateContrast(( _ContrastTransparentMap + 1.0 ),temp_cast_27) + -_SpreadTransparentMap ) , float4( 0,0,0,0 ) , float4( 1,0,0,0 ) );
				float4 Transparent358 = ( clampResult24_g642 * ( 1.0 - _IntensityTransparentMap ) );
				
				float3 Albedo = Albedo26.rgb;
				float3 Normal = Normal27;
				float3 Emission = Emission110.rgb;
				float3 Specular = Specular41.rgb;
				float Metallic = 0;
				float Smoothness = Smoothness40;
				float Occlusion = AmbientOcclusion94;
				float Alpha = Transparent358.r;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;
				float3 BakedGI = 0;
				float3 RefractionColor = 1;
				float RefractionIndex = 1;
				float3 Transmission = 1;
				float3 Translucency = 1;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				InputData inputData;
				inputData.positionWS = WorldPosition;
				inputData.viewDirectionWS = WorldViewDirection;
				inputData.shadowCoord = ShadowCoords;

				#ifdef _NORMALMAP
					#if _NORMAL_DROPOFF_TS
					inputData.normalWS = TransformTangentToWorld(Normal, half3x3( WorldTangent, WorldBiTangent, WorldNormal ));
					#elif _NORMAL_DROPOFF_OS
					inputData.normalWS = TransformObjectToWorldNormal(Normal);
					#elif _NORMAL_DROPOFF_WS
					inputData.normalWS = Normal;
					#endif
					inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);
				#else
					inputData.normalWS = WorldNormal;
				#endif

				#ifdef ASE_FOG
					inputData.fogCoord = IN.fogFactorAndVertexLight.x;
				#endif

				inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
				#if defined(ENABLE_TERRAIN_PERPIXEL_NORMAL)
					float3 SH = SampleSH(inputData.normalWS.xyz);
				#else
					float3 SH = IN.lightmapUVOrVertexSH.xyz;
				#endif

				inputData.bakedGI = SAMPLE_GI( IN.lightmapUVOrVertexSH.xy, SH, inputData.normalWS );
				#ifdef _ASE_BAKEDGI
					inputData.bakedGI = BakedGI;
				#endif
				half4 color = UniversalFragmentPBR(
					inputData, 
					Albedo, 
					Metallic, 
					Specular, 
					Smoothness, 
					Occlusion, 
					Emission, 
					Alpha);

				#ifdef _TRANSMISSION_ASE
				{
					float shadow = _TransmissionShadow;

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );
					half3 mainTransmission = max(0 , -dot(inputData.normalWS, mainLight.direction)) * mainAtten * Transmission;
					color.rgb += Albedo * mainTransmission;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 transmission = max(0 , -dot(inputData.normalWS, light.direction)) * atten * Transmission;
							color.rgb += Albedo * transmission;
						}
					#endif
				}
				#endif

				#ifdef _TRANSLUCENCY_ASE
				{
					float shadow = _TransShadow;
					float normal = _TransNormal;
					float scattering = _TransScattering;
					float direct = _TransDirect;
					float ambient = _TransAmbient;
					float strength = _TransStrength;

					Light mainLight = GetMainLight( inputData.shadowCoord );
					float3 mainAtten = mainLight.color * mainLight.distanceAttenuation;
					mainAtten = lerp( mainAtten, mainAtten * mainLight.shadowAttenuation, shadow );

					half3 mainLightDir = mainLight.direction + inputData.normalWS * normal;
					half mainVdotL = pow( saturate( dot( inputData.viewDirectionWS, -mainLightDir ) ), scattering );
					half3 mainTranslucency = mainAtten * ( mainVdotL * direct + inputData.bakedGI * ambient ) * Translucency;
					color.rgb += Albedo * mainTranslucency * strength;

					#ifdef _ADDITIONAL_LIGHTS
						int transPixelLightCount = GetAdditionalLightsCount();
						for (int i = 0; i < transPixelLightCount; ++i)
						{
							Light light = GetAdditionalLight(i, inputData.positionWS);
							float3 atten = light.color * light.distanceAttenuation;
							atten = lerp( atten, atten * light.shadowAttenuation, shadow );

							half3 lightDir = light.direction + inputData.normalWS * normal;
							half VdotL = pow( saturate( dot( inputData.viewDirectionWS, -lightDir ) ), scattering );
							half3 translucency = atten * ( VdotL * direct + inputData.bakedGI * ambient ) * Translucency;
							color.rgb += Albedo * translucency * strength;
						}
					#endif
				}
				#endif

				#ifdef _REFRACTION_ASE
					float4 projScreenPos = ScreenPos / ScreenPos.w;
					float3 refractionOffset = ( RefractionIndex - 1.0 ) * mul( UNITY_MATRIX_V, WorldNormal ).xyz * ( 1.0 - dot( WorldNormal, WorldViewDirection ) );
					projScreenPos.xy += refractionOffset.xy;
					float3 refraction = SHADERGRAPH_SAMPLE_SCENE_COLOR( projScreenPos ) * RefractionColor;
					color.rgb = lerp( refraction, color.rgb, color.a );
					color.a = 1;
				#endif

				#ifdef ASE_FINAL_COLOR_ALPHA_MULTIPLY
					color.rgb *= color.a;
				#endif

				#ifdef ASE_FOG
					#ifdef TERRAIN_SPLAT_ADDPASS
						color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
					#else
						color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
					#endif
				#endif
				
				return color;
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "ShadowCaster"
			Tags { "LightMode"="ShadowCaster" }

			ZWrite On
			ZTest LEqual
			AlphaToMask Off

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_SHADOWCASTER

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _CHANNELSELECTION_RED _CHANNELSELECTION_GREEN _CHANNELSELECTION_BLUE _CHANNELSELECTION_ALPHA
			#pragma multi_compile_instancing


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _SpecularColor;
			float4 _Color;
			float4 _GlobalXYTilingXYZWOffsetXY;
			float4 _DetailSpecularColor;
			float4 _TriplanarXYTilingXYZWOffsetXY;
			float4 _DetailColor;
			float _SpecularIntensity;
			float _DetailSpecularIntensity;
			float _Smoothness;
			float _DetailGlossiness;
			float _EmissionIntensity;
			float _UseAoFromMainProperties;
			float _OcclusionStrength;
			float _ContrastTransparentMap;
			float _InvertTransparent;
			float _UseBaseColorAlpha;
			float _InvertABaseColor;
			float _VisualizeMask;
			float _BumpScale;
			float _DetailNormalMapScale;
			float _SpreadTransparentMap;
			float _BlendMainNormal;
			float _IntensityMask;
			float _SpreadDetailMap;
			float _EnableTriplanarProjection;
			float _InvertMask;
			float _ContrastDetailMap;
			float _EnableDetailMask;
			float _DetailSaturation;
			float _DetailBrightness;
			float _Saturation;
			float _Parallax;
			float _Brightness;
			float _UseEmissionFromMainProperties;
			float _IntensityTransparentMap;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _TransparentMask;
			sampler2D _BaseMap;
			sampler2D _ParallaxMap;
			UNITY_INSTANCING_BUFFER_START(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)
				UNITY_DEFINE_INSTANCED_PROP(float4, _TransparentMask_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _BaseMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _ParallaxMap_ST)
			UNITY_INSTANCING_BUFFER_END(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)


			inline float2 ParallaxOffset( half h, half height, half3 viewDir )
			{
				h = h * height - height/2.0;
				float3 v = normalize( viewDir );
				v.z += 0.42;
				return h* (v.xy / v.z);
			}
			
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}

			float3 _LightDirection;

			VertexOutput VertexFunction( VertexInput v )
			{
				VertexOutput o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord3.xyz = ase_worldTangent;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				o.ase_texcoord4.xyz = ase_worldNormal;
				float ase_vertexTangentSign = v.ase_tangent.w * unity_WorldTransformParams.w;
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord5.xyz = ase_worldBitangent;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord5.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif
				float3 normalWS = TransformObjectToWorldDir(v.ase_normal);

				float4 clipPos = TransformWorldToHClip( ApplyShadowBias( positionWS, normalWS, _LightDirection ) );

				#if UNITY_REVERSED_Z
					clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
				#else
					clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				o.clipPos = clipPos;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_tangent = v.ase_tangent;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN , half ase_vface : VFACE ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );
				
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 _TransparentMask_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TransparentMask_ST);
				float2 uv_TransparentMask = IN.ase_texcoord2.xy * _TransparentMask_ST_Instance.xy + _TransparentMask_ST_Instance.zw;
				float4 tex2DNode8_g642 = tex2D( _TransparentMask, uv_TransparentMask );
				#if defined(_CHANNELSELECTION_RED)
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#elif defined(_CHANNELSELECTION_GREEN)
				float staticSwitch30_g642 = tex2DNode8_g642.g;
				#elif defined(_CHANNELSELECTION_BLUE)
				float staticSwitch30_g642 = tex2DNode8_g642.b;
				#elif defined(_CHANNELSELECTION_ALPHA)
				float staticSwitch30_g642 = tex2DNode8_g642.a;
				#else
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#endif
				float4 _BaseMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_BaseMap_ST);
				float2 uv_BaseMap = IN.ase_texcoord2.xy * _BaseMap_ST_Instance.xy + _BaseMap_ST_Instance.zw;
				float2 break26_g633 = uv_BaseMap;
				float GlobalTilingX11 = ( _GlobalXYTilingXYZWOffsetXY.x - 1.0 );
				float GlobalTilingY8 = ( _GlobalXYTilingXYZWOffsetXY.y - 1.0 );
				float2 appendResult14_g633 = (float2(( break26_g633.x * GlobalTilingX11 ) , ( break26_g633.y * GlobalTilingY8 )));
				float GlobalOffsetX10 = _GlobalXYTilingXYZWOffsetXY.z;
				float GlobalOffsetY9 = _GlobalXYTilingXYZWOffsetXY.w;
				float2 appendResult13_g633 = (float2(( break26_g633.x + GlobalOffsetX10 ) , ( break26_g633.y + GlobalOffsetY9 )));
				float4 _ParallaxMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_ParallaxMap_ST);
				float2 uv_ParallaxMap = IN.ase_texcoord2.xy * _ParallaxMap_ST_Instance.xy + _ParallaxMap_ST_Instance.zw;
				float2 break26_g467 = uv_ParallaxMap;
				float2 appendResult14_g467 = (float2(( break26_g467.x * GlobalTilingX11 ) , ( break26_g467.y * GlobalTilingY8 )));
				float2 appendResult13_g467 = (float2(( break26_g467.x + GlobalOffsetX10 ) , ( break26_g467.y + GlobalOffsetY9 )));
				float4 temp_cast_0 = (tex2D( _ParallaxMap, ( appendResult14_g467 + appendResult13_g467 ) ).g).xxxx;
				float3 ase_worldTangent = IN.ase_texcoord3.xyz;
				float3 ase_worldNormal = IN.ase_texcoord4.xyz;
				float3 ase_worldBitangent = IN.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
				float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
				float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
				float3 ase_worldViewDir = ( _WorldSpaceCameraPos.xyz - WorldPosition );
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 ase_tanViewDir =  tanToWorld0 * ase_worldViewDir.x + tanToWorld1 * ase_worldViewDir.y  + tanToWorld2 * ase_worldViewDir.z;
				ase_tanViewDir = normalize(ase_tanViewDir);
				float2 paralaxOffset36_g466 = ParallaxOffset( temp_cast_0.x , _Parallax , ase_tanViewDir );
				float2 switchResult47_g466 = (((ase_vface>0)?(paralaxOffset36_g466):(0.0)));
				float2 Parallaxe368 = switchResult47_g466;
				float4 tex2DNode7_g632 = tex2D( _BaseMap, ( ( appendResult14_g633 + appendResult13_g633 ) + Parallaxe368 ) );
				float BaseColorAlpha46 = (( _InvertABaseColor )?( ( 1.0 - tex2DNode7_g632.a ) ):( tex2DNode7_g632.a ));
				float4 temp_cast_2 = ((( _InvertTransparent )?( ( 1.0 - (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ) ):( (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ))).xxxx;
				float4 clampResult24_g642 = clamp( ( CalculateContrast(( _ContrastTransparentMap + 1.0 ),temp_cast_2) + -_SpreadTransparentMap ) , float4( 0,0,0,0 ) , float4( 1,0,0,0 ) );
				float4 Transparent358 = ( clampResult24_g642 * ( 1.0 - _IntensityTransparentMap ) );
				
				float Alpha = Transparent358.r;
				float AlphaClipThreshold = 0.5;
				float AlphaClipThresholdShadow = 0.5;

				#ifdef _ALPHATEST_ON
					#ifdef _ALPHATEST_SHADOW_ON
						clip(Alpha - AlphaClipThresholdShadow);
					#else
						clip(Alpha - AlphaClipThreshold);
					#endif
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif
				return 0;
			}

			ENDHLSL
		}

		
		Pass
		{
			
			Name "DepthOnly"
			Tags { "LightMode"="DepthOnly" }

			ZWrite On
			ColorMask 0
			AlphaToMask Off

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_DEPTHONLY

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#pragma shader_feature_local _CHANNELSELECTION_RED _CHANNELSELECTION_GREEN _CHANNELSELECTION_BLUE _CHANNELSELECTION_ALPHA
			#pragma multi_compile_instancing


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _SpecularColor;
			float4 _Color;
			float4 _GlobalXYTilingXYZWOffsetXY;
			float4 _DetailSpecularColor;
			float4 _TriplanarXYTilingXYZWOffsetXY;
			float4 _DetailColor;
			float _SpecularIntensity;
			float _DetailSpecularIntensity;
			float _Smoothness;
			float _DetailGlossiness;
			float _EmissionIntensity;
			float _UseAoFromMainProperties;
			float _OcclusionStrength;
			float _ContrastTransparentMap;
			float _InvertTransparent;
			float _UseBaseColorAlpha;
			float _InvertABaseColor;
			float _VisualizeMask;
			float _BumpScale;
			float _DetailNormalMapScale;
			float _SpreadTransparentMap;
			float _BlendMainNormal;
			float _IntensityMask;
			float _SpreadDetailMap;
			float _EnableTriplanarProjection;
			float _InvertMask;
			float _ContrastDetailMap;
			float _EnableDetailMask;
			float _DetailSaturation;
			float _DetailBrightness;
			float _Saturation;
			float _Parallax;
			float _Brightness;
			float _UseEmissionFromMainProperties;
			float _IntensityTransparentMap;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _TransparentMask;
			sampler2D _BaseMap;
			sampler2D _ParallaxMap;
			UNITY_INSTANCING_BUFFER_START(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)
				UNITY_DEFINE_INSTANCED_PROP(float4, _TransparentMask_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _BaseMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _ParallaxMap_ST)
			UNITY_INSTANCING_BUFFER_END(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)


			inline float2 ParallaxOffset( half h, half height, half3 viewDir )
			{
				h = h * height - height/2.0;
				float3 v = normalize( viewDir );
				v.z += 0.42;
				return h* (v.xy / v.z);
			}
			
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord3.xyz = ase_worldTangent;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				o.ase_texcoord4.xyz = ase_worldNormal;
				float ase_vertexTangentSign = v.ase_tangent.w * unity_WorldTransformParams.w;
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord5.xyz = ase_worldBitangent;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord5.w = 0;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;
				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				o.clipPos = positionCS;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_tangent = v.ase_tangent;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN , half ase_vface : VFACE ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 _TransparentMask_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TransparentMask_ST);
				float2 uv_TransparentMask = IN.ase_texcoord2.xy * _TransparentMask_ST_Instance.xy + _TransparentMask_ST_Instance.zw;
				float4 tex2DNode8_g642 = tex2D( _TransparentMask, uv_TransparentMask );
				#if defined(_CHANNELSELECTION_RED)
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#elif defined(_CHANNELSELECTION_GREEN)
				float staticSwitch30_g642 = tex2DNode8_g642.g;
				#elif defined(_CHANNELSELECTION_BLUE)
				float staticSwitch30_g642 = tex2DNode8_g642.b;
				#elif defined(_CHANNELSELECTION_ALPHA)
				float staticSwitch30_g642 = tex2DNode8_g642.a;
				#else
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#endif
				float4 _BaseMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_BaseMap_ST);
				float2 uv_BaseMap = IN.ase_texcoord2.xy * _BaseMap_ST_Instance.xy + _BaseMap_ST_Instance.zw;
				float2 break26_g633 = uv_BaseMap;
				float GlobalTilingX11 = ( _GlobalXYTilingXYZWOffsetXY.x - 1.0 );
				float GlobalTilingY8 = ( _GlobalXYTilingXYZWOffsetXY.y - 1.0 );
				float2 appendResult14_g633 = (float2(( break26_g633.x * GlobalTilingX11 ) , ( break26_g633.y * GlobalTilingY8 )));
				float GlobalOffsetX10 = _GlobalXYTilingXYZWOffsetXY.z;
				float GlobalOffsetY9 = _GlobalXYTilingXYZWOffsetXY.w;
				float2 appendResult13_g633 = (float2(( break26_g633.x + GlobalOffsetX10 ) , ( break26_g633.y + GlobalOffsetY9 )));
				float4 _ParallaxMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_ParallaxMap_ST);
				float2 uv_ParallaxMap = IN.ase_texcoord2.xy * _ParallaxMap_ST_Instance.xy + _ParallaxMap_ST_Instance.zw;
				float2 break26_g467 = uv_ParallaxMap;
				float2 appendResult14_g467 = (float2(( break26_g467.x * GlobalTilingX11 ) , ( break26_g467.y * GlobalTilingY8 )));
				float2 appendResult13_g467 = (float2(( break26_g467.x + GlobalOffsetX10 ) , ( break26_g467.y + GlobalOffsetY9 )));
				float4 temp_cast_0 = (tex2D( _ParallaxMap, ( appendResult14_g467 + appendResult13_g467 ) ).g).xxxx;
				float3 ase_worldTangent = IN.ase_texcoord3.xyz;
				float3 ase_worldNormal = IN.ase_texcoord4.xyz;
				float3 ase_worldBitangent = IN.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
				float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
				float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
				float3 ase_worldViewDir = ( _WorldSpaceCameraPos.xyz - WorldPosition );
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 ase_tanViewDir =  tanToWorld0 * ase_worldViewDir.x + tanToWorld1 * ase_worldViewDir.y  + tanToWorld2 * ase_worldViewDir.z;
				ase_tanViewDir = normalize(ase_tanViewDir);
				float2 paralaxOffset36_g466 = ParallaxOffset( temp_cast_0.x , _Parallax , ase_tanViewDir );
				float2 switchResult47_g466 = (((ase_vface>0)?(paralaxOffset36_g466):(0.0)));
				float2 Parallaxe368 = switchResult47_g466;
				float4 tex2DNode7_g632 = tex2D( _BaseMap, ( ( appendResult14_g633 + appendResult13_g633 ) + Parallaxe368 ) );
				float BaseColorAlpha46 = (( _InvertABaseColor )?( ( 1.0 - tex2DNode7_g632.a ) ):( tex2DNode7_g632.a ));
				float4 temp_cast_2 = ((( _InvertTransparent )?( ( 1.0 - (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ) ):( (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ))).xxxx;
				float4 clampResult24_g642 = clamp( ( CalculateContrast(( _ContrastTransparentMap + 1.0 ),temp_cast_2) + -_SpreadTransparentMap ) , float4( 0,0,0,0 ) , float4( 1,0,0,0 ) );
				float4 Transparent358 = ( clampResult24_g642 * ( 1.0 - _IntensityTransparentMap ) );
				
				float Alpha = Transparent358.r;
				float AlphaClipThreshold = 0.5;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				#ifdef LOD_FADE_CROSSFADE
					LODDitheringTransition( IN.clipPos.xyz, unity_LODFade.x );
				#endif
				return 0;
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "Meta"
			Tags { "LightMode"="Meta" }

			Cull Off

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70301

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_META

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_NORMAL
			#pragma shader_feature_local _BLENDMODE_NONE _BLENDMODE_OVERLAY
			#pragma multi_compile_instancing
			#pragma shader_feature_local _CHANNELSELECTIONMASK1_RED _CHANNELSELECTIONMASK1_GREEN _CHANNELSELECTIONMASK1_BLUE _CHANNELSELECTIONMASK1_ALPHA
			#pragma shader_feature_local _TRIPLANARSPACEPROJECTION_OBJECTSPACE _TRIPLANARSPACEPROJECTION_WORLDSPACE
			#pragma shader_feature_local _CHANNELSELECTION_RED _CHANNELSELECTION_GREEN _CHANNELSELECTION_BLUE _CHANNELSELECTION_ALPHA


			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _SpecularColor;
			float4 _Color;
			float4 _GlobalXYTilingXYZWOffsetXY;
			float4 _DetailSpecularColor;
			float4 _TriplanarXYTilingXYZWOffsetXY;
			float4 _DetailColor;
			float _SpecularIntensity;
			float _DetailSpecularIntensity;
			float _Smoothness;
			float _DetailGlossiness;
			float _EmissionIntensity;
			float _UseAoFromMainProperties;
			float _OcclusionStrength;
			float _ContrastTransparentMap;
			float _InvertTransparent;
			float _UseBaseColorAlpha;
			float _InvertABaseColor;
			float _VisualizeMask;
			float _BumpScale;
			float _DetailNormalMapScale;
			float _SpreadTransparentMap;
			float _BlendMainNormal;
			float _IntensityMask;
			float _SpreadDetailMap;
			float _EnableTriplanarProjection;
			float _InvertMask;
			float _ContrastDetailMap;
			float _EnableDetailMask;
			float _DetailSaturation;
			float _DetailBrightness;
			float _Saturation;
			float _Parallax;
			float _Brightness;
			float _UseEmissionFromMainProperties;
			float _IntensityTransparentMap;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _BaseMap;
			sampler2D _ParallaxMap;
			sampler2D _DetailAlbedoMap;
			sampler2D _DetailMask;
			sampler2D _EmissionMap;
			sampler2D _TransparentMask;
			UNITY_INSTANCING_BUFFER_START(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)
				UNITY_DEFINE_INSTANCED_PROP(float4, _BaseMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _ParallaxMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _DetailAlbedoMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _EmissionMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _TransparentMask_ST)
				UNITY_DEFINE_INSTANCED_PROP(float, _TriplanarFalloff)
			UNITY_INSTANCING_BUFFER_END(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)


			inline float2 ParallaxOffset( half h, half height, half3 viewDir )
			{
				h = h * height - height/2.0;
				float3 v = normalize( viewDir );
				v.z += 0.42;
				return h* (v.xy / v.z);
			}
			
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}
			inline float4 TriplanarSampling393( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord3.xyz = ase_worldTangent;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				o.ase_texcoord4.xyz = ase_worldNormal;
				float ase_vertexTangentSign = v.ase_tangent.w * unity_WorldTransformParams.w;
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord5.xyz = ase_worldBitangent;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				o.ase_texcoord6 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord5.w = 0;
				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				o.clipPos = MetaVertexPosition( v.vertex, v.texcoord1.xy, v.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST );
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = o.clipPos;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.texcoord1 = v.texcoord1;
				o.texcoord2 = v.texcoord2;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_tangent = v.ase_tangent;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.texcoord1 = patch[0].texcoord1 * bary.x + patch[1].texcoord1 * bary.y + patch[2].texcoord1 * bary.z;
				o.texcoord2 = patch[0].texcoord2 * bary.x + patch[1].texcoord2 * bary.y + patch[2].texcoord2 * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN , half ase_vface : VFACE ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 _BaseMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_BaseMap_ST);
				float2 uv_BaseMap = IN.ase_texcoord2.xy * _BaseMap_ST_Instance.xy + _BaseMap_ST_Instance.zw;
				float2 break26_g633 = uv_BaseMap;
				float GlobalTilingX11 = ( _GlobalXYTilingXYZWOffsetXY.x - 1.0 );
				float GlobalTilingY8 = ( _GlobalXYTilingXYZWOffsetXY.y - 1.0 );
				float2 appendResult14_g633 = (float2(( break26_g633.x * GlobalTilingX11 ) , ( break26_g633.y * GlobalTilingY8 )));
				float GlobalOffsetX10 = _GlobalXYTilingXYZWOffsetXY.z;
				float GlobalOffsetY9 = _GlobalXYTilingXYZWOffsetXY.w;
				float2 appendResult13_g633 = (float2(( break26_g633.x + GlobalOffsetX10 ) , ( break26_g633.y + GlobalOffsetY9 )));
				float4 _ParallaxMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_ParallaxMap_ST);
				float2 uv_ParallaxMap = IN.ase_texcoord2.xy * _ParallaxMap_ST_Instance.xy + _ParallaxMap_ST_Instance.zw;
				float2 break26_g467 = uv_ParallaxMap;
				float2 appendResult14_g467 = (float2(( break26_g467.x * GlobalTilingX11 ) , ( break26_g467.y * GlobalTilingY8 )));
				float2 appendResult13_g467 = (float2(( break26_g467.x + GlobalOffsetX10 ) , ( break26_g467.y + GlobalOffsetY9 )));
				float4 temp_cast_0 = (tex2D( _ParallaxMap, ( appendResult14_g467 + appendResult13_g467 ) ).g).xxxx;
				float3 ase_worldTangent = IN.ase_texcoord3.xyz;
				float3 ase_worldNormal = IN.ase_texcoord4.xyz;
				float3 ase_worldBitangent = IN.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
				float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
				float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
				float3 ase_worldViewDir = ( _WorldSpaceCameraPos.xyz - WorldPosition );
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 ase_tanViewDir =  tanToWorld0 * ase_worldViewDir.x + tanToWorld1 * ase_worldViewDir.y  + tanToWorld2 * ase_worldViewDir.z;
				ase_tanViewDir = normalize(ase_tanViewDir);
				float2 paralaxOffset36_g466 = ParallaxOffset( temp_cast_0.x , _Parallax , ase_tanViewDir );
				float2 switchResult47_g466 = (((ase_vface>0)?(paralaxOffset36_g466):(0.0)));
				float2 Parallaxe368 = switchResult47_g466;
				float4 tex2DNode7_g632 = tex2D( _BaseMap, ( ( appendResult14_g633 + appendResult13_g633 ) + Parallaxe368 ) );
				float clampResult27_g632 = clamp( _Saturation , -1.0 , 100.0 );
				float3 desaturateInitialColor29_g632 = ( _Color * tex2DNode7_g632 ).rgb;
				float desaturateDot29_g632 = dot( desaturateInitialColor29_g632, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar29_g632 = lerp( desaturateInitialColor29_g632, desaturateDot29_g632.xxx, -clampResult27_g632 );
				float4 temp_output_411_0 = CalculateContrast(_Brightness,float4( desaturateVar29_g632 , 0.0 ));
				float4 _DetailAlbedoMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_DetailAlbedoMap_ST);
				float2 uv_DetailAlbedoMap = IN.ase_texcoord2.xy * _DetailAlbedoMap_ST_Instance.xy + _DetailAlbedoMap_ST_Instance.zw;
				float4 tex2DNode7_g468 = tex2D( _DetailAlbedoMap, uv_DetailAlbedoMap );
				float clampResult27_g468 = clamp( _DetailSaturation , -1.0 , 100.0 );
				float3 desaturateInitialColor29_g468 = ( _DetailColor * tex2DNode7_g468 ).rgb;
				float desaturateDot29_g468 = dot( desaturateInitialColor29_g468, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar29_g468 = lerp( desaturateInitialColor29_g468, desaturateDot29_g468.xxx, -clampResult27_g468 );
				float4 AlbedoDetail153 = CalculateContrast(_DetailBrightness,float4( desaturateVar29_g468 , 0.0 ));
				float4 temp_cast_6 = (0.0).xxxx;
				float2 texCoord387 = IN.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode392 = tex2D( _DetailMask, texCoord387 );
				#if defined(_CHANNELSELECTIONMASK1_RED)
				float staticSwitch424 = tex2DNode392.r;
				#elif defined(_CHANNELSELECTIONMASK1_GREEN)
				float staticSwitch424 = tex2DNode392.g;
				#elif defined(_CHANNELSELECTIONMASK1_BLUE)
				float staticSwitch424 = tex2DNode392.b;
				#elif defined(_CHANNELSELECTIONMASK1_ALPHA)
				float staticSwitch424 = tex2DNode392.a;
				#else
				float staticSwitch424 = tex2DNode392.r;
				#endif
				float2 appendResult389 = (float2(_TriplanarXYTilingXYZWOffsetXY.x , _TriplanarXYTilingXYZWOffsetXY.y));
				float _TriplanarFalloff_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TriplanarFalloff);
				#if defined(_TRIPLANARSPACEPROJECTION_OBJECTSPACE)
				float3 staticSwitch386 = IN.ase_texcoord6.xyz;
				#elif defined(_TRIPLANARSPACEPROJECTION_WORLDSPACE)
				float3 staticSwitch386 = WorldPosition;
				#else
				float3 staticSwitch386 = IN.ase_texcoord6.xyz;
				#endif
				float2 appendResult385 = (float2(_TriplanarXYTilingXYZWOffsetXY.z , _TriplanarXYTilingXYZWOffsetXY.w));
				float4 triplanar393 = TriplanarSampling393( _DetailMask, ( staticSwitch386 + float3( appendResult385 ,  0.0 ) ), IN.ase_normal, _TriplanarFalloff_Instance, appendResult389, 1.0, 0 );
				#if defined(_CHANNELSELECTIONMASK1_RED)
				float staticSwitch423 = triplanar393.x;
				#elif defined(_CHANNELSELECTIONMASK1_GREEN)
				float staticSwitch423 = triplanar393.y;
				#elif defined(_CHANNELSELECTIONMASK1_BLUE)
				float staticSwitch423 = triplanar393.z;
				#elif defined(_CHANNELSELECTIONMASK1_ALPHA)
				float staticSwitch423 = triplanar393.w;
				#else
				float staticSwitch423 = triplanar393.x;
				#endif
				float4 temp_cast_12 = ((( _InvertMask )?( ( 1.0 - (( _EnableTriplanarProjection )?( staticSwitch423 ):( staticSwitch424 )) ) ):( (( _EnableTriplanarProjection )?( staticSwitch423 ):( staticSwitch424 )) ))).xxxx;
				float4 clampResult407 = clamp( ( CalculateContrast(( _ContrastDetailMap + 1.0 ),temp_cast_12) + -_SpreadDetailMap ) , float4( 0,0,0,0 ) , float4( 1,1,1,0 ) );
				float MaskIntensity405 = _IntensityMask;
				float4 Mask158 = (( _EnableDetailMask )?( ( clampResult407 * MaskIntensity405 ) ):( temp_cast_6 ));
				float4 lerpResult343 = lerp( temp_output_411_0 , AlbedoDetail153 , Mask158);
				float4 blendOpSrc15_g634 = temp_output_411_0;
				float4 blendOpDest15_g634 = lerpResult343;
				float4 lerpBlendMode15_g634 = lerp(blendOpDest15_g634,(( blendOpDest15_g634 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest15_g634 ) * ( 1.0 - blendOpSrc15_g634 ) ) : ( 2.0 * blendOpDest15_g634 * blendOpSrc15_g634 ) ),Mask158.x);
				#if defined(_BLENDMODE_NONE)
				float4 staticSwitch22_g634 = lerpResult343;
				#elif defined(_BLENDMODE_OVERLAY)
				float4 staticSwitch22_g634 = ( saturate( lerpBlendMode15_g634 ));
				#else
				float4 staticSwitch22_g634 = lerpResult343;
				#endif
				float4 Albedo26 = (( _VisualizeMask )?( Mask158 ):( staticSwitch22_g634 ));
				
				float4 _EmissionMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_EmissionMap_ST);
				float2 uv_EmissionMap = IN.ase_texcoord2.xy * _EmissionMap_ST_Instance.xy + _EmissionMap_ST_Instance.zw;
				float2 break26_g667 = uv_EmissionMap;
				float2 appendResult14_g667 = (float2(( break26_g667.x * GlobalTilingX11 ) , ( break26_g667.y * GlobalTilingY8 )));
				float2 appendResult13_g667 = (float2(( break26_g667.x + GlobalOffsetX10 ) , ( break26_g667.y + GlobalOffsetY9 )));
				float4 temp_output_415_0 = ( _EmissionColor * tex2D( _EmissionMap, ( ( appendResult14_g667 + appendResult13_g667 ) + Parallaxe368 ) ) * _EmissionIntensity );
				float4 temp_cast_20 = (0.0).xxxx;
				float4 lerpResult190 = lerp( temp_output_415_0 , temp_cast_20 , Mask158);
				float4 Emission110 = (( _UseEmissionFromMainProperties )?( temp_output_415_0 ):( lerpResult190 ));
				
				float4 _TransparentMask_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TransparentMask_ST);
				float2 uv_TransparentMask = IN.ase_texcoord2.xy * _TransparentMask_ST_Instance.xy + _TransparentMask_ST_Instance.zw;
				float4 tex2DNode8_g642 = tex2D( _TransparentMask, uv_TransparentMask );
				#if defined(_CHANNELSELECTION_RED)
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#elif defined(_CHANNELSELECTION_GREEN)
				float staticSwitch30_g642 = tex2DNode8_g642.g;
				#elif defined(_CHANNELSELECTION_BLUE)
				float staticSwitch30_g642 = tex2DNode8_g642.b;
				#elif defined(_CHANNELSELECTION_ALPHA)
				float staticSwitch30_g642 = tex2DNode8_g642.a;
				#else
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#endif
				float BaseColorAlpha46 = (( _InvertABaseColor )?( ( 1.0 - tex2DNode7_g632.a ) ):( tex2DNode7_g632.a ));
				float4 temp_cast_22 = ((( _InvertTransparent )?( ( 1.0 - (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ) ):( (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ))).xxxx;
				float4 clampResult24_g642 = clamp( ( CalculateContrast(( _ContrastTransparentMap + 1.0 ),temp_cast_22) + -_SpreadTransparentMap ) , float4( 0,0,0,0 ) , float4( 1,0,0,0 ) );
				float4 Transparent358 = ( clampResult24_g642 * ( 1.0 - _IntensityTransparentMap ) );
				
				
				float3 Albedo = Albedo26.rgb;
				float3 Emission = Emission110.rgb;
				float Alpha = Transparent358.r;
				float AlphaClipThreshold = 0.5;

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				MetaInput metaInput = (MetaInput)0;
				metaInput.Albedo = Albedo;
				metaInput.Emission = Emission;
				
				return MetaFragment(metaInput);
			}
			ENDHLSL
		}

		
		Pass
		{
			
			Name "Universal2D"
			Tags { "LightMode"="Universal2D" }

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA

			HLSLPROGRAM
			#define _SPECULAR_SETUP 1
			#define _NORMAL_DROPOFF_TS 1
			#pragma multi_compile_instancing
			#pragma multi_compile _ LOD_FADE_CROSSFADE
			#pragma multi_compile_fog
			#define ASE_FOG 1
			#define _EMISSION
			#define _NORMALMAP 1
			#define ASE_SRP_VERSION 70301

			#pragma enable_d3d11_debug_symbols
			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x

			#pragma vertex vert
			#pragma fragment frag

			#define SHADERPASS_2D

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
			
			#define ASE_NEEDS_VERT_NORMAL
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#define ASE_NEEDS_FRAG_POSITION
			#define ASE_NEEDS_FRAG_NORMAL
			#pragma shader_feature_local _BLENDMODE_NONE _BLENDMODE_OVERLAY
			#pragma multi_compile_instancing
			#pragma shader_feature_local _CHANNELSELECTIONMASK1_RED _CHANNELSELECTIONMASK1_GREEN _CHANNELSELECTIONMASK1_BLUE _CHANNELSELECTIONMASK1_ALPHA
			#pragma shader_feature_local _TRIPLANARSPACEPROJECTION_OBJECTSPACE _TRIPLANARSPACEPROJECTION_WORLDSPACE
			#pragma shader_feature_local _CHANNELSELECTION_RED _CHANNELSELECTION_GREEN _CHANNELSELECTION_BLUE _CHANNELSELECTION_ALPHA


			#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A

			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 worldPos : TEXCOORD0;
				#endif
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
				float4 shadowCoord : TEXCOORD1;
				#endif
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 ase_texcoord4 : TEXCOORD4;
				float4 ase_texcoord5 : TEXCOORD5;
				float4 ase_texcoord6 : TEXCOORD6;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			CBUFFER_START(UnityPerMaterial)
			float4 _EmissionColor;
			float4 _SpecularColor;
			float4 _Color;
			float4 _GlobalXYTilingXYZWOffsetXY;
			float4 _DetailSpecularColor;
			float4 _TriplanarXYTilingXYZWOffsetXY;
			float4 _DetailColor;
			float _SpecularIntensity;
			float _DetailSpecularIntensity;
			float _Smoothness;
			float _DetailGlossiness;
			float _EmissionIntensity;
			float _UseAoFromMainProperties;
			float _OcclusionStrength;
			float _ContrastTransparentMap;
			float _InvertTransparent;
			float _UseBaseColorAlpha;
			float _InvertABaseColor;
			float _VisualizeMask;
			float _BumpScale;
			float _DetailNormalMapScale;
			float _SpreadTransparentMap;
			float _BlendMainNormal;
			float _IntensityMask;
			float _SpreadDetailMap;
			float _EnableTriplanarProjection;
			float _InvertMask;
			float _ContrastDetailMap;
			float _EnableDetailMask;
			float _DetailSaturation;
			float _DetailBrightness;
			float _Saturation;
			float _Parallax;
			float _Brightness;
			float _UseEmissionFromMainProperties;
			float _IntensityTransparentMap;
			#ifdef _TRANSMISSION_ASE
				float _TransmissionShadow;
			#endif
			#ifdef _TRANSLUCENCY_ASE
				float _TransStrength;
				float _TransNormal;
				float _TransScattering;
				float _TransDirect;
				float _TransAmbient;
				float _TransShadow;
			#endif
			#ifdef TESSELLATION_ON
				float _TessPhongStrength;
				float _TessValue;
				float _TessMin;
				float _TessMax;
				float _TessEdgeLength;
				float _TessMaxDisp;
			#endif
			CBUFFER_END
			sampler2D _BaseMap;
			sampler2D _ParallaxMap;
			sampler2D _DetailAlbedoMap;
			sampler2D _DetailMask;
			sampler2D _TransparentMask;
			UNITY_INSTANCING_BUFFER_START(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)
				UNITY_DEFINE_INSTANCED_PROP(float4, _BaseMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _ParallaxMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _DetailAlbedoMap_ST)
				UNITY_DEFINE_INSTANCED_PROP(float4, _TransparentMask_ST)
				UNITY_DEFINE_INSTANCED_PROP(float, _TriplanarFalloff)
			UNITY_INSTANCING_BUFFER_END(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent)


			inline float2 ParallaxOffset( half h, half height, half3 viewDir )
			{
				h = h * height - height/2.0;
				float3 v = normalize( viewDir );
				v.z += 0.42;
				return h* (v.xy / v.z);
			}
			
			float4 CalculateContrast( float contrastValue, float4 colorTarget )
			{
				float t = 0.5 * ( 1.0 - contrastValue );
				return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
			}
			inline float4 TriplanarSampling393( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
			{
				float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
				projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
				float3 nsign = sign( worldNormal );
				half4 xNorm; half4 yNorm; half4 zNorm;
				xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
				yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
				zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
				return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
			}
			

			VertexOutput VertexFunction( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord3.xyz = ase_worldTangent;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				o.ase_texcoord4.xyz = ase_worldNormal;
				float ase_vertexTangentSign = v.ase_tangent.w * unity_WorldTransformParams.w;
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord5.xyz = ase_worldBitangent;
				
				o.ase_texcoord2.xy = v.ase_texcoord.xy;
				o.ase_texcoord6 = v.vertex;
				o.ase_normal = v.ase_normal;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord2.zw = 0;
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;
				o.ase_texcoord5.w = 0;
				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3(0, 0, 0);
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal = v.ase_normal;

				float3 positionWS = TransformObjectToWorld( v.vertex.xyz );
				float4 positionCS = TransformWorldToHClip( positionWS );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				o.worldPos = positionWS;
				#endif

				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR) && defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					VertexPositionInputs vertexInput = (VertexPositionInputs)0;
					vertexInput.positionWS = positionWS;
					vertexInput.positionCS = positionCS;
					o.shadowCoord = GetShadowCoord( vertexInput );
				#endif

				o.clipPos = positionCS;
				return o;
			}

			#if defined(TESSELLATION_ON)
			struct VertexControl
			{
				float4 vertex : INTERNALTESSPOS;
				float3 ase_normal : NORMAL;
				float4 ase_texcoord : TEXCOORD0;
				float4 ase_tangent : TANGENT;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct TessellationFactors
			{
				float edge[3] : SV_TessFactor;
				float inside : SV_InsideTessFactor;
			};

			VertexControl vert ( VertexInput v )
			{
				VertexControl o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				o.vertex = v.vertex;
				o.ase_normal = v.ase_normal;
				o.ase_texcoord = v.ase_texcoord;
				o.ase_tangent = v.ase_tangent;
				return o;
			}

			TessellationFactors TessellationFunction (InputPatch<VertexControl,3> v)
			{
				TessellationFactors o;
				float4 tf = 1;
				float tessValue = _TessValue; float tessMin = _TessMin; float tessMax = _TessMax;
				float edgeLength = _TessEdgeLength; float tessMaxDisp = _TessMaxDisp;
				#if defined(ASE_FIXED_TESSELLATION)
				tf = FixedTess( tessValue );
				#elif defined(ASE_DISTANCE_TESSELLATION)
				tf = DistanceBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, tessValue, tessMin, tessMax, GetObjectToWorldMatrix(), _WorldSpaceCameraPos );
				#elif defined(ASE_LENGTH_TESSELLATION)
				tf = EdgeLengthBasedTess(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams );
				#elif defined(ASE_LENGTH_CULL_TESSELLATION)
				tf = EdgeLengthBasedTessCull(v[0].vertex, v[1].vertex, v[2].vertex, edgeLength, tessMaxDisp, GetObjectToWorldMatrix(), _WorldSpaceCameraPos, _ScreenParams, unity_CameraWorldClipPlanes );
				#endif
				o.edge[0] = tf.x; o.edge[1] = tf.y; o.edge[2] = tf.z; o.inside = tf.w;
				return o;
			}

			[domain("tri")]
			[partitioning("fractional_odd")]
			[outputtopology("triangle_cw")]
			[patchconstantfunc("TessellationFunction")]
			[outputcontrolpoints(3)]
			VertexControl HullFunction(InputPatch<VertexControl, 3> patch, uint id : SV_OutputControlPointID)
			{
			   return patch[id];
			}

			[domain("tri")]
			VertexOutput DomainFunction(TessellationFactors factors, OutputPatch<VertexControl, 3> patch, float3 bary : SV_DomainLocation)
			{
				VertexInput o = (VertexInput) 0;
				o.vertex = patch[0].vertex * bary.x + patch[1].vertex * bary.y + patch[2].vertex * bary.z;
				o.ase_normal = patch[0].ase_normal * bary.x + patch[1].ase_normal * bary.y + patch[2].ase_normal * bary.z;
				o.ase_texcoord = patch[0].ase_texcoord * bary.x + patch[1].ase_texcoord * bary.y + patch[2].ase_texcoord * bary.z;
				o.ase_tangent = patch[0].ase_tangent * bary.x + patch[1].ase_tangent * bary.y + patch[2].ase_tangent * bary.z;
				#if defined(ASE_PHONG_TESSELLATION)
				float3 pp[3];
				for (int i = 0; i < 3; ++i)
					pp[i] = o.vertex.xyz - patch[i].ase_normal * (dot(o.vertex.xyz, patch[i].ase_normal) - dot(patch[i].vertex.xyz, patch[i].ase_normal));
				float phongStrength = _TessPhongStrength;
				o.vertex.xyz = phongStrength * (pp[0]*bary.x + pp[1]*bary.y + pp[2]*bary.z) + (1.0f-phongStrength) * o.vertex.xyz;
				#endif
				UNITY_TRANSFER_INSTANCE_ID(patch[0], o);
				return VertexFunction(o);
			}
			#else
			VertexOutput vert ( VertexInput v )
			{
				return VertexFunction( v );
			}
			#endif

			half4 frag(VertexOutput IN , half ase_vface : VFACE ) : SV_TARGET
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				#if defined(ASE_NEEDS_FRAG_WORLD_POSITION)
				float3 WorldPosition = IN.worldPos;
				#endif
				float4 ShadowCoords = float4( 0, 0, 0, 0 );

				#if defined(ASE_NEEDS_FRAG_SHADOWCOORDS)
					#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
						ShadowCoords = IN.shadowCoord;
					#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
						ShadowCoords = TransformWorldToShadowCoord( WorldPosition );
					#endif
				#endif

				float4 _BaseMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_BaseMap_ST);
				float2 uv_BaseMap = IN.ase_texcoord2.xy * _BaseMap_ST_Instance.xy + _BaseMap_ST_Instance.zw;
				float2 break26_g633 = uv_BaseMap;
				float GlobalTilingX11 = ( _GlobalXYTilingXYZWOffsetXY.x - 1.0 );
				float GlobalTilingY8 = ( _GlobalXYTilingXYZWOffsetXY.y - 1.0 );
				float2 appendResult14_g633 = (float2(( break26_g633.x * GlobalTilingX11 ) , ( break26_g633.y * GlobalTilingY8 )));
				float GlobalOffsetX10 = _GlobalXYTilingXYZWOffsetXY.z;
				float GlobalOffsetY9 = _GlobalXYTilingXYZWOffsetXY.w;
				float2 appendResult13_g633 = (float2(( break26_g633.x + GlobalOffsetX10 ) , ( break26_g633.y + GlobalOffsetY9 )));
				float4 _ParallaxMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_ParallaxMap_ST);
				float2 uv_ParallaxMap = IN.ase_texcoord2.xy * _ParallaxMap_ST_Instance.xy + _ParallaxMap_ST_Instance.zw;
				float2 break26_g467 = uv_ParallaxMap;
				float2 appendResult14_g467 = (float2(( break26_g467.x * GlobalTilingX11 ) , ( break26_g467.y * GlobalTilingY8 )));
				float2 appendResult13_g467 = (float2(( break26_g467.x + GlobalOffsetX10 ) , ( break26_g467.y + GlobalOffsetY9 )));
				float4 temp_cast_0 = (tex2D( _ParallaxMap, ( appendResult14_g467 + appendResult13_g467 ) ).g).xxxx;
				float3 ase_worldTangent = IN.ase_texcoord3.xyz;
				float3 ase_worldNormal = IN.ase_texcoord4.xyz;
				float3 ase_worldBitangent = IN.ase_texcoord5.xyz;
				float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
				float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
				float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
				float3 ase_worldViewDir = ( _WorldSpaceCameraPos.xyz - WorldPosition );
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 ase_tanViewDir =  tanToWorld0 * ase_worldViewDir.x + tanToWorld1 * ase_worldViewDir.y  + tanToWorld2 * ase_worldViewDir.z;
				ase_tanViewDir = normalize(ase_tanViewDir);
				float2 paralaxOffset36_g466 = ParallaxOffset( temp_cast_0.x , _Parallax , ase_tanViewDir );
				float2 switchResult47_g466 = (((ase_vface>0)?(paralaxOffset36_g466):(0.0)));
				float2 Parallaxe368 = switchResult47_g466;
				float4 tex2DNode7_g632 = tex2D( _BaseMap, ( ( appendResult14_g633 + appendResult13_g633 ) + Parallaxe368 ) );
				float clampResult27_g632 = clamp( _Saturation , -1.0 , 100.0 );
				float3 desaturateInitialColor29_g632 = ( _Color * tex2DNode7_g632 ).rgb;
				float desaturateDot29_g632 = dot( desaturateInitialColor29_g632, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar29_g632 = lerp( desaturateInitialColor29_g632, desaturateDot29_g632.xxx, -clampResult27_g632 );
				float4 temp_output_411_0 = CalculateContrast(_Brightness,float4( desaturateVar29_g632 , 0.0 ));
				float4 _DetailAlbedoMap_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_DetailAlbedoMap_ST);
				float2 uv_DetailAlbedoMap = IN.ase_texcoord2.xy * _DetailAlbedoMap_ST_Instance.xy + _DetailAlbedoMap_ST_Instance.zw;
				float4 tex2DNode7_g468 = tex2D( _DetailAlbedoMap, uv_DetailAlbedoMap );
				float clampResult27_g468 = clamp( _DetailSaturation , -1.0 , 100.0 );
				float3 desaturateInitialColor29_g468 = ( _DetailColor * tex2DNode7_g468 ).rgb;
				float desaturateDot29_g468 = dot( desaturateInitialColor29_g468, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar29_g468 = lerp( desaturateInitialColor29_g468, desaturateDot29_g468.xxx, -clampResult27_g468 );
				float4 AlbedoDetail153 = CalculateContrast(_DetailBrightness,float4( desaturateVar29_g468 , 0.0 ));
				float4 temp_cast_6 = (0.0).xxxx;
				float2 texCoord387 = IN.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode392 = tex2D( _DetailMask, texCoord387 );
				#if defined(_CHANNELSELECTIONMASK1_RED)
				float staticSwitch424 = tex2DNode392.r;
				#elif defined(_CHANNELSELECTIONMASK1_GREEN)
				float staticSwitch424 = tex2DNode392.g;
				#elif defined(_CHANNELSELECTIONMASK1_BLUE)
				float staticSwitch424 = tex2DNode392.b;
				#elif defined(_CHANNELSELECTIONMASK1_ALPHA)
				float staticSwitch424 = tex2DNode392.a;
				#else
				float staticSwitch424 = tex2DNode392.r;
				#endif
				float2 appendResult389 = (float2(_TriplanarXYTilingXYZWOffsetXY.x , _TriplanarXYTilingXYZWOffsetXY.y));
				float _TriplanarFalloff_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TriplanarFalloff);
				#if defined(_TRIPLANARSPACEPROJECTION_OBJECTSPACE)
				float3 staticSwitch386 = IN.ase_texcoord6.xyz;
				#elif defined(_TRIPLANARSPACEPROJECTION_WORLDSPACE)
				float3 staticSwitch386 = WorldPosition;
				#else
				float3 staticSwitch386 = IN.ase_texcoord6.xyz;
				#endif
				float2 appendResult385 = (float2(_TriplanarXYTilingXYZWOffsetXY.z , _TriplanarXYTilingXYZWOffsetXY.w));
				float4 triplanar393 = TriplanarSampling393( _DetailMask, ( staticSwitch386 + float3( appendResult385 ,  0.0 ) ), IN.ase_normal, _TriplanarFalloff_Instance, appendResult389, 1.0, 0 );
				#if defined(_CHANNELSELECTIONMASK1_RED)
				float staticSwitch423 = triplanar393.x;
				#elif defined(_CHANNELSELECTIONMASK1_GREEN)
				float staticSwitch423 = triplanar393.y;
				#elif defined(_CHANNELSELECTIONMASK1_BLUE)
				float staticSwitch423 = triplanar393.z;
				#elif defined(_CHANNELSELECTIONMASK1_ALPHA)
				float staticSwitch423 = triplanar393.w;
				#else
				float staticSwitch423 = triplanar393.x;
				#endif
				float4 temp_cast_12 = ((( _InvertMask )?( ( 1.0 - (( _EnableTriplanarProjection )?( staticSwitch423 ):( staticSwitch424 )) ) ):( (( _EnableTriplanarProjection )?( staticSwitch423 ):( staticSwitch424 )) ))).xxxx;
				float4 clampResult407 = clamp( ( CalculateContrast(( _ContrastDetailMap + 1.0 ),temp_cast_12) + -_SpreadDetailMap ) , float4( 0,0,0,0 ) , float4( 1,1,1,0 ) );
				float MaskIntensity405 = _IntensityMask;
				float4 Mask158 = (( _EnableDetailMask )?( ( clampResult407 * MaskIntensity405 ) ):( temp_cast_6 ));
				float4 lerpResult343 = lerp( temp_output_411_0 , AlbedoDetail153 , Mask158);
				float4 blendOpSrc15_g634 = temp_output_411_0;
				float4 blendOpDest15_g634 = lerpResult343;
				float4 lerpBlendMode15_g634 = lerp(blendOpDest15_g634,(( blendOpDest15_g634 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest15_g634 ) * ( 1.0 - blendOpSrc15_g634 ) ) : ( 2.0 * blendOpDest15_g634 * blendOpSrc15_g634 ) ),Mask158.x);
				#if defined(_BLENDMODE_NONE)
				float4 staticSwitch22_g634 = lerpResult343;
				#elif defined(_BLENDMODE_OVERLAY)
				float4 staticSwitch22_g634 = ( saturate( lerpBlendMode15_g634 ));
				#else
				float4 staticSwitch22_g634 = lerpResult343;
				#endif
				float4 Albedo26 = (( _VisualizeMask )?( Mask158 ):( staticSwitch22_g634 ));
				
				float4 _TransparentMask_ST_Instance = UNITY_ACCESS_INSTANCED_PROP(CiconiaStudioCS_StandardURPStandardSpecularsetupTransparent,_TransparentMask_ST);
				float2 uv_TransparentMask = IN.ase_texcoord2.xy * _TransparentMask_ST_Instance.xy + _TransparentMask_ST_Instance.zw;
				float4 tex2DNode8_g642 = tex2D( _TransparentMask, uv_TransparentMask );
				#if defined(_CHANNELSELECTION_RED)
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#elif defined(_CHANNELSELECTION_GREEN)
				float staticSwitch30_g642 = tex2DNode8_g642.g;
				#elif defined(_CHANNELSELECTION_BLUE)
				float staticSwitch30_g642 = tex2DNode8_g642.b;
				#elif defined(_CHANNELSELECTION_ALPHA)
				float staticSwitch30_g642 = tex2DNode8_g642.a;
				#else
				float staticSwitch30_g642 = tex2DNode8_g642.r;
				#endif
				float BaseColorAlpha46 = (( _InvertABaseColor )?( ( 1.0 - tex2DNode7_g632.a ) ):( tex2DNode7_g632.a ));
				float4 temp_cast_20 = ((( _InvertTransparent )?( ( 1.0 - (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ) ):( (( _UseBaseColorAlpha )?( BaseColorAlpha46 ):( staticSwitch30_g642 )) ))).xxxx;
				float4 clampResult24_g642 = clamp( ( CalculateContrast(( _ContrastTransparentMap + 1.0 ),temp_cast_20) + -_SpreadTransparentMap ) , float4( 0,0,0,0 ) , float4( 1,0,0,0 ) );
				float4 Transparent358 = ( clampResult24_g642 * ( 1.0 - _IntensityTransparentMap ) );
				
				
				float3 Albedo = Albedo26.rgb;
				float Alpha = Transparent358.r;
				float AlphaClipThreshold = 0.5;

				half4 color = half4( Albedo, Alpha );

				#ifdef _ALPHATEST_ON
					clip(Alpha - AlphaClipThreshold);
				#endif

				return color;
			}
			ENDHLSL
		}
		
	}
	CustomEditor "UnityEditor.ShaderGraph.PBRMasterGUI"
	Fallback "Hidden/InternalErrorShader"
	
}