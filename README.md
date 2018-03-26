# VR-Subway-Platform-Scene
Developed for the CNIB for the CAVE VR setup at the Toronto Hub, for orientation and mobility training usage.

### Setup
Setup: 4 rear-throw projectors and screens arranged in U formation, two front screens and two lateral screens (8' by 10' ea);
Resolution: 1920x1080;
Display order: Left 2, front left 3, front right 4, right 1;
Surround sound audio system 

### Simulation development notes:
multidisplay.cs : initializes and assigns 4 cameras to displays, for projection on CAVE screens.

PerspectiveShiftR.cs/PerspectiveShiftL.cs : adjusts camera projection matrix to allow front 2 screens to project image with correct perspective (vanishing point adjustment).

train2.cs : master subway train movement script. Includes sound triggers and activation of door movement script.

openDoors.cs : uses leftdoor and rightdoor tags to control door movements for subway train

### Assets:
All modelling was done in SketchUp and Blender. Model of subway station based on St. Clair station in Toronto, Canada, using plan provided by TTC and photographs of the station.
Sound clips from freesound or recorded using Zoom H4n.
