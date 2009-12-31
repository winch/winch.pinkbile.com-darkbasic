blox - tetris clone
+++++++++++++++++++
V1.1 - 16 Nov 03 - added a msgbox on gameover
v1.2 - 09 Dec 03 - added sync mode setting and fixed highscore input box backspace problem
v1.3 - 12 Jan 04 - fixed problem with paused time being carried over to next game
v1.4 - 24 Jan 04 - minor source code cleanups
v1.5 - 17 Oct 05 - fixed out of bounds array errors so source works with dbpro 5.8

Requires directx 9.0c

Normal     - normal tetris
40 lines   - complete 40 lines as quickly as possible
highscores - show highscore table
Exit       - exit

up key    - rotate shape anti-clockwise
down key  - instantly drop shape
left key  - move shape left
right key - move shape right
n key     - toggle show next shape
s key     - toggle sync mode, program restart required(see below)

About the sync mode setting

The game uses "sync off" by default, this uses minimal cpu time (only a few % on my system).
Unforntunatly "sync off" appears to behave differnetly on different versions of windows. If
you find the game is running too slowly then you can switch sync modes (s key in game) to
sync on. Sync on will grab as much cpu time as possible but will run the game properly.
You need to restart the program for changes to take effect.

I used info and concepts from this site
http://www.colinfahey.com/2003jan_tetris/tetris_standard_specifications.htm

the_winch
thewinch@gmail.com
http://winch.pinkbile.com/
Permission to copy, use, modify, sell and distribute this software is
granted provided this notice appears un-modified in all copies.
This software is provided as-is without express or implied warranty,
and with no claim as to its suitability for any purpose.