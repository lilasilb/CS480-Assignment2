# CS480-Assignment2
## Group Members: Lila, Makena, Daphne
### Add at least one gameplay element that uses a dot product in some way (e.g., calculate length, distance, angle, facing direction) (Daphne)
Used dot products to calculate the direction of vision and signal an exclamation mark to appear over the player's head whenever an enemy, specifically a ghost, was looking at them.

### Add at least one gameplay element that uses linear interpolation in some way (e.g., calculate intermediate position, orientation, color).' (Lila)
Used linear interpolation to calculate a color value based off of the player's distance to the endpoint of the game.

### Add at least one new particle effect with trigger(s). (Makena)
Added particle system component to the Ghost prefab. 
- enabled collision in the world so the particles bounce off other objects
- changed the settings of the system so it appears from the back of the object and does not rotate with the object
- altered the velocity to make a slowing effect
- created a new material and changed the color of lifetime to create a gradient

Added a script to Ghost which triggers a color change when the player comes in sight of a Ghost

### Add at least one new sound effect with trigger(s). (Daphne)
Added a trigger that causes a warning audio to play when an enemy comes into proximity with the player.
