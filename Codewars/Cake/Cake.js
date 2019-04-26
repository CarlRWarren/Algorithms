// Constructor (your Captain Obivious)
function Player(){}
// Decide who move first - player or opponent (true if player)
Player.prototype.firstmove = function(cakes){
  return (cakes>2&&cakes % 4 != 2);
}
// Decide your next move
Player.prototype.move = function(cakes, last){
  if (cakes % 4 == 0) {
    return last == 3 ? 2 : 3;
  }
  else {
    if (cakes % 4 == 3) {
      return last == 1 ? 2 : 1;
    } 
    else if (cakes % 4 == 1 && cakes > 1) {
      return last == 3 ? 1 : 3;
    }
    else {
      return last == 2 ? 1 : 2;
    }
  }
}