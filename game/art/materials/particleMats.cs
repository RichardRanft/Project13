singleton CustomMaterial( basicRibbonGlow )
{
   shader = basicRibbonShader;
   version = 2.0;
   
   emissive[0] = true;
   glow[0] = true;
   
   doubleSided = true;
   translucent = true;
   BlendOp = AddAlpha;
   translucentBlendOp = AddAlpha;
   
   preload = true;
};
  
singleton CustomMaterial( texRibbonGlow : basicRibbonGlow )
{
   shader = texRibbonShader;
   version = 2.0;
   
   sampler["ribTex"] = "art/particles/ribTex.png";
};

singleton CustomMaterial( nyanRibbonMat : basicRibbonGlow )
{
   shader = texRibbonShader;
   version = 2.0;
   
   sampler["ribTex"] = "art/particles/nyanRibbon.png";
   
   stateBlock = nyanStateBlock;
};
 
