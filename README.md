My solution for technical task listed below:

Using C# language create a console application that can print geometric shapes to the screen or to the file. Shape to print should be chosen by user along with shape dimensions. 

User can choose 
* where to output graphic results into file or to the screen
* which shape to print, could be one of the shapes: triangle, circle, square or rectangle.

User must provide dimensions for shape:
* radius for circle
* 3 lengths of vertices for triangle
* side length for square
* 2 sides lengths for rectangle

Program limitations and potecial upgrades:
  1) Windows only - while using cross platform .net core, this project is configured to run only on windows, because it's relying on windows console handle;
  2) Limited info asked from user - I can see how adding more question for user coud improve user experience (for example allow to select image resolution, drawing line width, color & so on)
  3) Don't close application on incorrect input, and let user to try another one, however, I'm having tough time imagening "rich" user experience in console application that allows to go back and further between options (at least that will take much more time to develop)
  4) Add arguments handling
