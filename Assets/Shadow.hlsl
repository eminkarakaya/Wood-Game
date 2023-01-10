HLSINCLUDE
#include "../Packages/Post Processing/PostProcessing/Shaders/stdLib.hlsl"

TEXTURE2D_SAMPLER2D(_MainText, sampler_MainText);
float4 _MainText_TexelSize;
TEXTURE2D_SAMPLER2D(_CameraDepthTexture, sampler_CameraDepthTexture);
float4x4 unity_MatrixMVP;

half _MinDepth;
half _MaxDepth;
half _Thickness;
half _EdgeColor;
