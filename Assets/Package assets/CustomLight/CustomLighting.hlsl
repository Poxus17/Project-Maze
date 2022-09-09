#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_LIGHTING_INCLUDED

struct CustomLightingData {
	float3 albedo;
	float3 normalWS;
};

#ifndef SHADERGRAPH_PREVIEW
float3 CustomLightingHandling(CustomLightingData d, Light light) {
	float3 radiance = light.color;

	float3 diffuse = saturate(dot(d.normalWS, light.direction));

	float3 color = d.albedo * radiance * diffuse;

	return color;
}
#endif

float3 CalculateCustomLighting(CustomLightingData d){
#ifdef SHADERGRAPH_PREVIEW
	float3 lightDir = float3(0.5, 0.5, 0);
	float intensity = saturate(dot(d.normalWS, lightDir));
	return d.albedo * intensity;
#else

	Light mainLight = GetMainLight();

	float3 color = 0;

	color += CustomLightingHandling(d, mainLight);

	return d.albedo;
#endif
}

void CalculateCustomLighting_float(float3 Normal, float3 Albedo,
	out float3 Color) {

	CustomLightingData d;
	d.normalWS = Normal;
	d.albedo = Albedo;

	Color = CalculateCustomLighting(d);
}
#endif

