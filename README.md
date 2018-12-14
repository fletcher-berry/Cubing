# Rubik's cube alg trainer

## info:
This application allows a user to practice various subsets of algorithms for the Rubik's cube such as OLL, COLL, ZBLL and even 1LLL. The user selects a subset to practice and clicks one of the run buttons.  A new screen pops up with a cube on it.  
The user, on a physical cube, exexutes the algorithm to solve the position on the screen, and then presses the spacebar to go to the next position.  To see the algorithm to solve the displayed position, the user can press 'z'.

## Selecting subsets of algorithms:
The drop down on the left allows for selection of the set of algorithms to take a subset of.
The subsets are organized into groups, and selecting a group will show the subsets in that group.  A subset can be selected and added to input.  Some groups are divided into subgroups, and selecting a subgroup will filter the list of subsets.  The 'view' button will show all the positions in the inputed set.

### Custom subsets:
Custom subsets can be created from already existing subsets.  Add any desired combination of subsets to input, click 'create custom subset', give it a name, and now it can be easily used in the future.

### Recent subsets:
The last 10 subsets used for each algorithm set will be saved for easy reuse.

### Acceptable input:
Sets can be combined in the input with union or intercection.  The operator for union is '+' and the operator for intersection is '*'.  ',' can also be used for union. A single position can be added by its unique position number. (unique to the Set)  Ranges of positions can also be used (eg 10-30) with the lower bound being inclusive, and the upper bound being exclusive. 

### Run modes: 
 - Random: Random positions of the set indefinately
 - Single cycle: Runs through each postition of the set once, then ends.
 - Fixed: Runs through a fixed number of random positions, then ends.
 - Sequential: Runs through a set of positions in order.  
 
## Changing/writing algorithms:
If you know the position number of the position for which you wish to change the algorithm, enter it in the 'set up position' input and click 'go'.  You will then be able to change the algorithm.  (only algorithms with valid moves will be accepted).
If you do not know the position, click 'construct position' and you will be able to create the desired position.


## To run the program: 
- Open cubing.sln in visual studio
- Build 'Cubing' project
- Build 'ZbllDemo' project
- Add all contents of the "necessary files" directory to the bin directory in 'ZbllDemo'
- Run the exe! (or set ZbllDemo as the startup project in Visual studio, then run in Visual Studio)


