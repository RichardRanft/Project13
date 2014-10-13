new ShaderData( basicRibbonShader )
{
   DXVertexShaderFile   = "shaders/ribbons/basicRibbonShaderV.hlsl";
   DXPixelShaderFile    = "shaders/ribbons/basicRibbonShaderP.hlsl";
 
   pixVersion = 2.0;
};
 
 new ShaderData( texRibbonShader )
{
   DXVertexShaderFile   = "shaders/ribbons/texRibbonShaderV.hlsl";
   DXPixelShaderFile    = "shaders/ribbons/texRibbonShaderP.hlsl";
 
   pixVersion = 2.0;
};
 
new GFXSamplerStateData(NyanSampler)
{
   textureColorOp = GFXTOPModulate;
   addressModeU = GFXAddressClamp;
   addressModeV = GFXTextureAddressWrap;
   addressModeW = GFXAddressClamp;
   magFilter = GFXTextureFilterLinear;
   minFilter = GFXTextureFilterLinear;
   mipFilter = GFXTextureFilterLinear;
};
 
singleton GFXStateBlockData( nyanStateBlock )
{
   blendDefined = true;
   blendEnable = true;
   blendSrc = GFXBlendSrcAlpha;
   blendDest = GFXBlendInvSrcAlpha;
   blendOp = GFXBlendOpAdd;
   
   zDefined = true;
   zEnable = true;
   zWriteEnable = false;
   
   cullDefined = true;
   cullMode = "GFXCullNone";
   
   samplersDefined = true;
   samplerStates[0] = NyanSampler;
};

datablock RibbonData(nyanRibbon)
{
   RibbonMaterial = nyanRibbonMat;
   size[0] = 0.5;
   color[0] = "1.0 1.0 1.0 1.0";
   position[0] = 1.0;
 
   size[1] = 0.5;
   color[1] = "1.0 1.0 1.0 1.0";
   position[1] = 0.0;
 
   RibbonLength = 40;
   fadeAwayStep = 0.1;
   UseFadeOut = true;
   tileScale = 20;
   fixedTexCoords = true;
};