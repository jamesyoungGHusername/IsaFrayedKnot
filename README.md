## IsaFrayedKnot
Top-down roguelike dungeon crawler made to get used to working together online.

## TO DO
# character
* Add character attack. Short range, relatively slow-moving shots. 
* Changeable variables include: 
	* shot frequency.
	* shot range (how far a shot goes before degrading.
	* shot speed (how fast shots travel.
	* shot damage/size.
	* Shot vector should add the player's movement vector. (If the player is moving to the side the shot should move forward AND to the side).
* Adjust character movement and attack controls.
	* WASD to move and arrow keys to attack.
 	* Character factes attacking direction while an arrow key is pressed, after a they key is released the character faces back in the direction of 
movement.

# level
 * create single room design with up to four doors.
 * create trap/spike tile that damages the player when they stand on it.
 * create rock tile that is impassible to any non-flying entity.
 * generate random level at runtime from single room template before adding more rooms.
  
# enemies
 * create single enemy
 	* damages player when they touch it
 	* takes damage when player shots touch it
 	* follows player when they're in line of sight (finite state AI)
