## IsaFrayedKnot
Top-down roguelike dungeon crawler made to get used to working together online.

## TO DO
# character
 Add character attack. Short range, relatively slow-moving shots. 
 Changeable variables include: 
  shot frequency.
  shot range (how far a shot goes before degrading.
  shot speed (how fast shots travel.
  shot damage/size.
  
# level
  create single room design with up to four doors.
  create trap/spike tile that damages the player when they stand on it.
  create rock tile that is impassible to any non-flying entity.
  generate random level at runtime from single room template before adding more rooms.
  
# enemies
  create single enemy
    damages player when they touch it
    takes damage when player shots touch it
    follows player when they're in line of sight (finite state AI)
