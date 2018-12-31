# Keyboard Unchatter
Application to fix the keyboard chattering of mechanical switches

## Overview

This application fix the repeated keys in damaged Mechanical Switches by filtering all repeated keystrokes that were done in a certain timespan. If two or more keypresses were done inside that time, just the first keypress will be send to other applications.

# Releases

[Version 1.0.1](https://github.com/ZoserLock/keyboard-unchatter/releases/tag/v1.0.1)


# Known Issues

While this tool works well while typing, the method used is not fully reliable, in some cases the **Key Up** event is not registered because was blocked by the app, that results in bad output if the running application is for example a game. 

There is no way to know if the **Key Up** event  

I don't recomend to use this tool while playing games. In future released, an option to disable the application if selected process is running will be added, since the chattering problem does not affect games that much.

# To Do List

* Add the option to disable all statistics.
* Add a list of applications to disable the action of this tool. (ex: Games)

# Screenshots

![Example](https://github.com/ZoserLock/keyboard-unchatter/raw/master/Images/example.gif)