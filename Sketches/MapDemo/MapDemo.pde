void setup()
{
  size(500, 500);
}

void draw()
{
  background(128);
  
  float rads = map(mouseX, 0, width, 0, 6.28);
  
  pushMatrix();
  translate(width/2, height/2);
  rotate(rads);
  rect(-200, -200, 400, 400);
  popMatrix();
}
