# prefabs_triggers_master

## How to Play

- First - Click on the game screen.
- Move the spaceship using the **arrow keys** (Up, Down, Left, Right).
- Hold the **Space** key to shoot continuously.
- Avoid enemy objects entering from **above**.
- The score is always displayed at the **top-left** corner of the screen.
- The spaceship cannot leave the world vertically (top and bottom are closed).
- The world is open horizontally: when leaving the **right** side, the spaceship appears on the **left**, and when leaving the **left** side, it appears on the **right**.

---

## Summary of Code Changes  
These changes were implemented inside:  
**Scenes → 4-levels**

Below is a clear summary of the four modifications I made to the project, including which scripts were changed and the method used.

---

### 1. Fixing the player score in a constant UI position  
**Goal:** Keep the player’s score in a fixed UI position on the screen (instead of following the spaceship).

**What I changed:**  
- The score TextMeshPro object was moved into the **Canvas** as UI text.
- The `NumberField` script was updated to use `TMP_Text` instead of 3D TextMeshPro.

**Modified scripts:**  
- `NumberField.cs`  
- `LaserShooter.cs`

**Method:**  
- Linking the UI score object directly using `SerializeField` in the Inspector.  
- Updating the script so it supports TextMeshPro UI elements.

---

### 2. Creating a round world on the X-axis and closed world on the Y-axis  
**Goal:**  
- On the X-axis: the player appears on the opposite side when exiting the screen.  
- On the Y-axis: the player cannot leave the vertical limits.

**What I changed:**  
- Used **WorldLimits** colliders (Right, Left, Top, Bottom) to represent world limits.
- Added a script named **LimitsY** to stop the player from leaving the top or bottom limits (based on the player's center — half height).
- Added a script named **MoveX** to move the player from one side of the screen to the other horizontally.

**New scripts:**  
- `LimitsY.cs`   
- `MoveX.cs` 

**Method:**  
Checking the player's position each frame and adjusting it when passing the world limits.

---

### 3. Continuous shooting while holding the Space key  
**Goal:** Allow the player to shoot continuously by holding the Space key.

**What I changed:**  
- In `ClickSpawner`, replaced the single-press detection with `IsPressed()`.

**Modified script:**  
- `ClickSpawner.cs`

**Method:**  
- Detecting whether the action is currently pressed.  
- Introducing a small delay based on the current time and a predefined interval so the shooting rate stays controlled.

---

### 4. Changing the spaceship color based on movement direction  
**Goal:** Give the player visual feedback when moving left or right.

**What I changed:**  
- Added a `SpriteRenderer` reference in `InputMover`.
- Color change rules:  
  - Moving right → **Red**  
  - Moving left → **Blue**  
  - Standing still → original color

**Modified script:**  
- `InputMover.cs`

**Method:**  
Reading the movement vector (`moveDirection.x`) every frame and updating the sprite’s color accordingly.

---

**itch.io link:** [Play the game](https://raz-oununu.itch.io/prefabs-triggers-master)

