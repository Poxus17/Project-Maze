#ifndef UNITY_DECALPROPERTIES_INCLUDED
#define UNITY_DECALPROPERTIES_INCLUDED

TEXTURE2D(_BaseColorMap);
SAMPLER(sampler_BaseColorMap);
TEXTURE2D(_NormalMap);
SAMPLER(sampler_NormalMap);
TEXTURE2D(_MaskMap);
SAMPLER(sampler_MaskMap);
TEXTURE2D(_EmissiveColorMap);
SAMPLER(sampler_EmissiveColorMap);

CBUFFER_START(UnityPerMaterial)

float _NormalBlendSrc;
float _MaskBlendSrc;
float _DecalBlend;
float4 _BaseColor;
float3 _EmissiveColor;
float _EmissiveExposureWeight;
int   _DecalMeshBiasType;
float _DecalMeshDepthBias;
float _DecalMeshViewBias;
float _MetallicRemapMin;
float _MetallicRemapMax;
float _SmoothnessRemapMin;
float _SmoothnessRemapMax;
float _AORemapMin;
float _AORemapMax;
float _DecalMaskMapBlueScale;

float _Smoothness;
float _AO;
float _Metallic;

//---
float4 _MyLightPosition;
float4 _MyLightDirection;
float  _MyLightAngle;
float _MyLightRange;
int _LightType;

CBUFFER_END

// Following three variables are feeded by the C++ Editor for Scene selection
#ifdef SCENEPICKINGPASS
float4 _SelectionID;
#endif

#endif
