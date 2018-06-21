# FreeCell-Challenge
Free Cell Solitaire designed in Unity  

This is an unfinished version of a freecell solitaire game. To go to a finished version with welcome screens and a correct and clean implementation of legal moves, please go to 

https://github.com/AnitaFrakingShah/FreeCell-Personal/


As for this version while I managed to create all of the classes I'd want and the layout for the beginning of the game I have still not implemented all the game rules.  

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

Final note: One may notice looking through this code that there are some unused variables, this is because when this implementation was uploaded I was in the middle of trying to alter my "collision recognition" between cards. Specifically instead of using the numerous box collisions in the column object to capture when a card was being moved into a column, I wanted to use state features of cards to identify when a card was being placed into a column (such as the feature inColumn, or oldParent, etc.). These state features appeared to result in more accurate recognition of collisioning as is seen in my completed implementation of the game at https://github.com/AnitaFrakingShah/FreeCell-Personal/. These state features (and the realization that unity has a scripting API that includes set.parent and transform.parent) was crucial in establishing the movement of multiple cards from column to column, as can be seen feature in https://github.com/AnitaFrakingShah/FreeCell-Personal/. Overall, state features appear to be the better method of collision identification as long as they don't start to impede on memory space.


Start time: 8PM on 6/11/18
Last Github Push 9PM on 6/12/18

https://raw.githubusercontent.com/AnitaFrakingShah/FreeCell-Challenge/master/Capture.PNG
