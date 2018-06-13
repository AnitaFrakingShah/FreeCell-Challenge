# FreeCell-Challenge
Free Cell Solitaire designed in Unity  

Unfortunately I have not (as of yet) been able to complete this game. Specifically while I managed to create all of the classes I'd want and the layout for the beginning of the game I have still not implemented all the game rules.  

What I Accomplished:
- Free Cell, Foundation and Individual Column Cards can be moved appropriately.
- Almost all illegal moves unallowed (note it is possible to break this version of the game to allow illegal moves to be made).
- Randomly initiates the game
- Drag and Drop works
- Clicking on the Cards sends it into a Free Cell

What I didn't Accomplish
- JSON I/O integration
- Multiple screens: Welcome and Exit
- Moving multiple cards (organized appropriately) among the columns

What I would Like to work on:
- The design: Specifically reducing the four foundation classes into one. Given the time constraint I was unable to backtrack this feature. I also feel like there has to be a better way to implement the rules than all of the conditionals I ended up having to use.

- Better Collision Identification: As you will soon learn, moving the cards takes MULTIPLE attempts because the collisionboxes don't always register during the ray attack.

-Animations: Having no experience with Unity animations yet, I would have loved to explore this (though I am probably going to keep working on this project after this).



Start time: 8PM on 6/11/18
Last Github Push 9PM on 6/12/18

https://raw.githubusercontent.com/AnitaFrakingShah/FreeCell-Challenge/master/Capture.PNG
