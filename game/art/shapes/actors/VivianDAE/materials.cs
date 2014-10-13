
singleton Material(Vivian__Eye_trans)
{
   mapTo = "_Eye_trans";
   diffuseColor[0] = "0.09092 0.09092 0.09092 0.8595";
   specular[0] = "0.00854 0.00854 0.00854 1";
   specularPower[0] = "1";
   translucent = "1";
};

singleton Material(Vivian__Body_Mid)
{
   mapTo = "_Body_Mid";
   diffuseMap[0] = "Vivian_color";
   normalMap[0] = "Vivian_mid_nm";
   specular[0] = "0 0 0 1";
   specularPower[0] = "1";
   translucentBlendOp = "None";
};
