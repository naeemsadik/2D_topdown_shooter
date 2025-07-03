# 2D Top-Down Shooter Game

## Overview

This project is a 2D top-down shooter game built with Unity. Below are instructions on how to set up and connect scripts to specific scenes in the game.

## Prerequisites

- Unity Engine installed on your system.
- Basic understanding of Unity'''s interface and workflow.

## Project Structure

- **Scenes**
  - `Assets/Scenes/Game.unity`: Main game scene.
  - `Assets/Scenes/Main Menu.unity`: Main menu scene.
  - `Assets/Scenes/GameOver.unity`: Game over screen.

- **Scripts**
  - **Game Control**
    - `GameStateManager.cs`: Manages persistent game data like high scores.
    - `MainMenuController.cs`: Handles interactions in the Main Menu scene.
  - **Player Control**
    - `PlayerMovement.cs`: Controls player movement.
    - `PlayerShoot.cs`: Manages player shooting mechanics.
  - **Enemy Control**
    - `EnemySpawner.cs`: Spawns enemies in the game.
- **UI Management**
    - `PauseMenuUI.cs`: Manages the pause menu UI elements.
    - `GameMenu.cs`: Controls game UI and interactions.
    - `LevelProgressionUI.cs`: Manages level progression congratulations messages.

## Connecting Scripts to Scenes

### Main Menu Scene

1. **Scene Setup**
   - Scene file: `Main Menu.unity`
   - Attach `MainMenuController.cs` to the main menu UI GameObject.
   - Ensure the `highScoreText` field is connected to a `TMP_Text` element displaying the high score.

2. **Functionality**
   - **Play Game**: Calls `StartGame()` to load game scene.
   - **Continue Game**: Calls `ContinueGame()` to load saved state, if available.

### Game Scene

1. **Scene Setup**
   - Scene file: `Game.unity`
   - Ensure player GameObject has `PlayerMovement.cs` and `PlayerShoot.cs` attached.
   - Attach `EnemySpawner.cs` to any GameObject to handle enemy spawning.

2. **UI Setup**
   - Attach `GameMenu.cs` to a UI manager GameObject.
   - Ensure `pauseMenuUI` and `highScoreText` are linked to their respective UI elements.
   - Attach `LevelProgressionUI.cs` to a UI Canvas GameObject.
   - Create a congratulations panel with:
     - A Panel GameObject (for background)
     - A TMP_Text element for congratulations message
     - (Optional) A Continue button to dismiss the message

3. **Script Interactions**
   - `PlayerMovement`: Controls player velocity and screen edge limitations.
   - `EnemySpawner`: Randomly spawns enemies based on defined intervals.

### Game Over Scene

1. **Scene Setup**
   - Scene file: `GameOver.unity`
   - Manage game end conditions and return to Main Menu.

## Common Functions

- **Saving and Loading**: 
  - Use `GameStateManager.SaveGame()` and `LoadGame()` to handle game state persistence.
  
- **Pause and Resume**: 
  - Call `PauseGame()` and `ResumeGame()` in `GameMenu.cs`.

## Additional Notes

- Ensure all serialized fields in scripts are linked within the Unity editor.
- Scripts may have specific dependencies; be careful to attach them to the required GameObjects.

## Troubleshooting

- Verify that all component references in the scripts are correctly assigned in the Unity Editor.
- Use Unity'''s debugging tools to test game mechanics in play mode.

This documentation should help connect your scripts with the respective Unity scenes!

