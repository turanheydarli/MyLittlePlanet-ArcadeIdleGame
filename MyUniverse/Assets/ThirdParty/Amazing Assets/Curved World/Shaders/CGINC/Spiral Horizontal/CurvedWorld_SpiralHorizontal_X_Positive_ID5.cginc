#ifndef CURVEDWORLD_SPIRALHORIZONTAL_X_POSITIVE_ID5_CGINC
#define CURVEDWORLD_SPIRALHORIZONTAL_X_POSITIVE_ID5_CGINC

uniform float3 CurvedWorld_SpiralHorizontal_X_Positive_ID5_PivotPoint;
uniform float3 CurvedWorld_SpiralHorizontal_X_Positive_ID5_RotationCenter;
uniform float CurvedWorld_SpiralHorizontal_X_Positive_ID5_BendAngle;
uniform float CurvedWorld_SpiralHorizontal_X_Positive_ID5_BendMinimumRadius;

                 
#include "../../Core/Core.cginc"                           
             
      
////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                Main Method                                 //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
void CurvedWorld_SpiralHorizontal_X_Positive_ID5(inout float4 vertexOS)
{
    CurvedWorld_SpiralHorizontal_X_Positive(vertexOS, 
							CurvedWorld_SpiralHorizontal_X_Positive_ID5_PivotPoint,
	                        CurvedWorld_SpiralHorizontal_X_Positive_ID5_RotationCenter,                            
							CurvedWorld_SpiralHorizontal_X_Positive_ID5_BendAngle,
							CurvedWorld_SpiralHorizontal_X_Positive_ID5_BendMinimumRadius);
}

void CurvedWorld_SpiralHorizontal_X_Positive_ID5(inout float4 vertexOS, inout float3 normalOS, float4 tangent)
{
    CurvedWorld_SpiralHorizontal_X_Positive(vertexOS, 
                            normalOS, 
                            tangent,
							CurvedWorld_SpiralHorizontal_X_Positive_ID5_PivotPoint,
                            CurvedWorld_SpiralHorizontal_X_Positive_ID5_RotationCenter,                            
							CurvedWorld_SpiralHorizontal_X_Positive_ID5_BendAngle,
							CurvedWorld_SpiralHorizontal_X_Positive_ID5_BendMinimumRadius);
}

void CurvedWorld_SpiralHorizontal_X_Positive_ID5(inout float3 vertexOS)
{
    float4 vertex = float4(vertexOS, 1);
    CurvedWorld_SpiralHorizontal_X_Positive_ID5(vertex);

    vertexOS.xyz = vertex.xyz;
}

void CurvedWorld_SpiralHorizontal_X_Positive_ID5(inout float3 vertexOS, inout float3 normalOS, float4 tangent)
{
    float4 vertex = float4(vertexOS, 1);
    CurvedWorld_SpiralHorizontal_X_Positive_ID5(vertex, normalOS, tangent);

    vertexOS.xyz = vertex.xyz;
} 

////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                               SubGraph Methods                             //
//                                                                            // 
////////////////////////////////////////////////////////////////////////////////
void CurvedWorld_SpiralHorizontal_X_Positive_ID5_float(float3 vertexOS, out float3 retVertex)
{
    CurvedWorld_SpiralHorizontal_X_Positive_ID5(vertexOS); 	

    retVertex = vertexOS.xyz;
}

void CurvedWorld_SpiralHorizontal_X_Positive_ID5_half(half3 vertexOS, out half3 retVertex)
{
    CurvedWorld_SpiralHorizontal_X_Positive_ID5(vertexOS); 	

    retVertex = vertexOS.xyz;
}

void CurvedWorld_SpiralHorizontal_X_Positive_ID5_float(float3 vertexOS, float3 normalOS, float4 tangent, out float3 retVertex, out float3 retNormal)
{
	CurvedWorld_SpiralHorizontal_X_Positive_ID5(vertexOS, normalOS, tangent); 	

    retVertex = vertexOS.xyz;
    retNormal = normalOS.xyz;
}

void CurvedWorld_SpiralHorizontal_X_Positive_ID5_half(half3 vertexOS, half3 normalOS, half4 tangent, out half3 retVertex, out float3 retNormal)
{
	CurvedWorld_SpiralHorizontal_X_Positive_ID5(vertexOS, normalOS, tangent); 	

    retVertex = vertexOS.xyz;
    retNormal = normalOS.xyz;	
}     

#endif
