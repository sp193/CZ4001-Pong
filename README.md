# CZ4001-Pong
CZ4001 Virtual and Augmented Reality (Part II)

Tentative functional requirements:
* Enhanced version of the classic pong game.
* The game ends when the player misses the ball.
* Player can move the flipper by moving the AR marker.

Scoring:
* Player scores points for deflecting the ball.

Additional instructions for setting up the source code:
* Add the custom merge rules from .gitconfig with this command: git config --local include.path ..\.gitconfig
* Edit Program Files\Unity\Editor\Data\Tools\mergespecfile.txt to point to your favourite diff tool.
	For me, it is WinMerge:
```	# WinMerge
	* use "%programs%\WinMerge\WinMergeU.exe" "%l" "%r" "%d"
```

When dealing with merge conflicts:
* Run git mergetool first!
