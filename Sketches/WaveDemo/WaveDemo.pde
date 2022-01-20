void setup()
{
  size(800, 500);
  stroke(150, 0, 255);
}
void draw()
{
  background(64);
  
  float t = 11 +  (9 * sin((millis() / 1000.0) * 2f));//from [-1, 1] to [2, 20]
  strokeWeight(t);
  
  ellipse(width/2, height/2, 400, 400);
}
