//exponential slide
//asymptotic easing
//damping

//3 circles' x positions
float x1, x2, x3;

//velocity
float v2;

void setup()
{
  size(500, 500, P2D);
}

void draw()
{
  background(0);
  
  //linear
  if(x1 < mouseX)
  {
    x1 += 5;
    if(x1 > mouseX) x1 = mouseX;
  }
  else
  {
    x1 -= 5;
    if(x1 < mouseX) x1 = mouseX;
  }
  
  
  
  //physics
  if(x2 < mouseX) ++v2;
  else --v2;
  v2 *= .95;//friction
  x2 += v2;//euler integration
  
  
  
  //damping
  //each tick, move 50% to target. Ease out
  //x3 += (mouseX - x3) * .1;//10% to target
  x3 = lerp(x3, mouseX, .1);//equivalent to above line
  
  
  
  ellipse(x1, height * .25, 25, 25);
  ellipse(x2, height * .5, 25, 25);
  ellipse(x3, height * .75, 25, 25);
}
