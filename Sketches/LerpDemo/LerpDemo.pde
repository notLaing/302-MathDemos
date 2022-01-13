void setup()
{
  size(500, 500);
}

void draw()
{
  background(128);
  
  //calculate percent
  float p = mouseX / (float)width;
  float p2 = mouseY / (float)height;
  float w = lerp(1, 50, p2);
  strokeWeight(w);
  
  //calculate diameter
  float d = lerp(50, 500, p);
  
  ellipse(width/2, height/2, d, d);
}
