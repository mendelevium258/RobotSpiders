# RobotSpiders
### How to run the file
* Run the program using one of the following commands:
  * dotnet RobotSpiders.dll FilePath
  * dotnet RobotSpiders.dll WallWidth WallHeight SpiderX SpiderY SpiderFacing Movements
  * dotnet RobotSpiders.dll WallWidth WallHeight (SpiderX SpiderY SpiderFacing Movements) (SpiderX SpiderY SpiderFacing Movements) ...
* The result will be written to the console window.  For multiple spiders, they will be written on separate lines

### Notes on my code
* I have created an interface for the wall.  This allows a future possibility where a wall is not rectangular but might have a chunk missing
* I have created an interface for the wallExplorer. This allows a future possibility where the explorer of the wall is not a spider but instead could be a snake(?).
* I have caught the cases where a wall has invalid dimensions or the spider falls off the edge of the wall and returned a friendly message to the users

### Things I would change
* If the spider starts off the wall, but it's first move is onto the wall, the program doesn't error like it should
* There is no tests for the cases where you are entering multiple spiders
* I'm not happy with the Program.cs - it does too much and I would want to simplify it given time
