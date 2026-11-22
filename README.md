# Her Last Knight!

A 2D action-platformer built with **Unity** and **C#** where you stand as the sole surviving knight defending the princess from an onslaught of skeletons.

## Gameplay & Objective
All other knights have fallen, leaving only you to protect the princess. To win the level, you must defeat all **30 skeletons** before either your health (**10 HP**) or the princess's health (**5 HP**) drops to zero.

* **Top-Left HUD:** Survival timer
* **Top-Right HUD:** Kill counter, Knight health, and Princess health

## Controls
| Action | Input |
| :--- | :--- |
| Move Left / Right | `A` / `D` |
| Jump | `Space` |
| Sword Attack | `Left Mouse Click` |

## Technical Highlights & Features
* **Animation Event Combat Lock:** Implemented Unity Animator events so player movement is locked during attack frames, creating deliberate, weighty sword swings.
* **Audio Integration:** Synchronized sound effects (SFX) across movement, jumping, and sword attacks.
* **Cinematic End States:** Added a slow-motion time-scale effect triggered upon reaching the Victory or Game Over screens.

## Built With
* **Engine:** Unity (2D)
* **Language:** C#
* **Art & Assets:** Free 2D background art and character animation sprite sheets sourced from [itch.io](https://itch.io/).

## How to Run
1. Clone this repository:
   ```bash
   git clone [https://github.com/DanaAung/Her-Last-Knight-Game-Project.git](https://github.com/DanaAung/Her-Last-Knight-Game-Project.git)
