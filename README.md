# Closest_Event_Finder

- The whole project / code is written in C# as requested.
- The project has been created in Visual Studio 2015. Thus, to run, downloading the whole project and running with Visual studio 10 or upper should work.
- As the program is queit small scale my stragety tacling the problem was a simple one: using the 'Random' class create events on the grid, then using manhattan distance select the closest ones.
- How might you change your program if you needed to support multiple events at the same location? Just remove the 'if' condition that's preventing this.
- How would you change your program if you were working with a much larger world size? The creation of the events was made as efficient as possible - O(n) it is a linear process -, but the finding of the closest event is much worse as, each time, it goes through the whole list of events to find the closest one. Here I would think of somehow ordering the list of events and applying divide and conquer techniques to find the closest one. Thus, this would cut down iterations and enhance efficiency.
