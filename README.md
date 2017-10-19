# Prime Coding Test
This is a small coding test to see how you write code in in a psuedo-realistic sort of environment. The project is setup enough that should you be unfamiliar with some of the technology, you should be able to figure out how it works from reading the existing classes and structures.

## What You're Working With
This is a .Net Core MVC hosted Angular SPA with a fake in memory database that is connected using Entity Framework. It has a home page, a simple counter (not part of the test), and a weather section.

## What You're Trying To Do
1. Update the Weather section to properly set the Summary (chilly, hot, etc.) based on what the temperature is
    * This should be reusable so that if another part of the system dealt with temperatures, it could reuse this
2. Add a way to add new temperature readings.
   * This can be simply an Add button that just randomizes the data and uses `DateTime.Now()`
   * Or it could be a way to enter a specific temperature and time.  Don't worry about adding a datepicker.
3. Update the home page to grab the latest temperature reading and display it in a nice way such as:
> It's a cold day outside as of 5 minutes ago

## What You're Going To Need
1. A https://github.com/ account and a git client
2. An IDE.
   * Well technically you don't need one.  .Net Core is cross platform and runs on the command line so feel free to use vim or notepad++ if you're one of those people
   * Visual Studio Code https://code.visualstudio.com/
     * You may need to add some plugins to support C# and Typescript, but they should automatically be recommended when you open the project
   * Visual Studio 2017 (any edition) https://www.visualstudio.com/vs/community/
     * Either of those are already setup where hitting F5 will run the project and kick open your browser to the app
3. .Net Core SDK https://www.microsoft.com/net/download/core
4. NodeJs https://nodejs.org/en/

## How To Get Started
1. Fork this git repository to your personal account so that you can do a pull request at the end that can be reviewed
2. Clone the repository to your computer
3. Open the folder (visual studio code) or project (visual studio 2017) in your IDE
4. This should kick off a `dotnet restore` automatically, but if not manually run that in a command prompt
5. Hit F5 (or run `ng serve` if you're not in one of the visual studios)
6. You should hopefully be viewing the project in your browser after the build finishes.
   * Client side changes (HTML, TS files) automatically refresh your browser and appear in seconds after hitting save
   * Server side changes (CS files) require a quick reboot of the server.
7. When you're done, submit your changes as a pull request in github.  This will wrap them all up nicely into one section that I can see and comment on no matter how many commits you did
## WTF?
If you run into an error or something that you can't figure out, just ask!  It's entirely possible that I've missed something in the setup steps that was already done on my machine before writing this test.
