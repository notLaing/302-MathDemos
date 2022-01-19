// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

void setup(){
  size(400, 400);
}
void draw(){
  
  drawBackground();
  
  ///////////////// START YOUR CODE HERE:
  
  //variables
  float time = millis()/1000f;
  PVector coord = new PVector(cos(time) * 150f, sin(time) * 50f);//squashed/stretched circle
  
  //red
  pushMatrix();
  translate(200, 200);
  stroke(255, 100, 100);
  //circle squashed/stretched in variables above
  ellipse(coord.x, coord.y, 10, 10);
  popMatrix();
  
  
  
  //green: pi / 1.5
  pushMatrix();
  translate(200, 200);
  stroke(100, 255, 100);
  
  //r = sqrt(x^2 + y^2)  theta = arctan(y / x)
  float gr = sqrt(pow(coord.x, 2) + pow(coord.y, 2));
  //angle plus tilt
  float gt = atan2(coord.y, coord.x) + (PI / 1.5f);
  
  //polar -> cartesian
  ellipse(gr * cos(gt), gr * sin(gt), 10, 10);
  popMatrix();
  
  
  
  //blue: 2pi / 1.5
  pushMatrix();
  translate(200, 200);
  stroke(100, 100, 255);
  
  //r = sqrt(x^2 + y^2)  theta = arctan(y / x)
  float br = sqrt(pow(coord.x, 2) + pow(coord.y, 2));
  //angle plus tilt
  float bt = atan2(coord.y, coord.x) + (PI / .75f);
  
  //polar -> cartesian
  ellipse(br * cos(bt), br * sin(bt), 10, 10);
  popMatrix();
  
  
  ///////////////// END YOUR CODE HERE
  
}
void drawBackground(){
  background(0);
  noStroke();
  fill(255);
  ellipse(200,200,50,50);
  noFill();
  strokeWeight(5);
  
  pushMatrix();
  translate(200,200);
  stroke(255,100,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(PI/1.5);
  stroke(100,255,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(2*PI/1.5);
  stroke(100,100,255);
  ellipse(0,0,300,100);
  popMatrix();
}
