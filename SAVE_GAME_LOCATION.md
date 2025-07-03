# Save Game Storage Location

## Where are save games stored?

Your game save data is stored using Unity's PlayerPrefs system, which saves data to the Windows Registry on Windows machines.

### Windows Registry Location:
- **Registry Path**: `HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\[CompanyName]\[ProductName]`
- **Default Path**: `HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\DefaultCompany\2D_topdown_shooter`

### Save Data Keys:
- `CurrentScore`: The player's current score when the game was saved
- `PlayerPosX`, `PlayerPosY`, `PlayerPosZ`: The player's position coordinates
- `HighScore`: The highest score achieved

## How to view save data:

1. **Using Registry Editor (regedit.exe)**:
   - Press `Windows + R`, type `regedit` and press Enter
   - Navigate to `HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\DefaultCompany\2D_topdown_shooter`
   - You'll see your save data as registry entries

2. **Using PowerShell**:
   ```powershell
   Get-ItemProperty -Path "HKCU:\SOFTWARE\Unity\UnityEditor\DefaultCompany\2D_topdown_shooter"
   ```

## How to manually clear save data:

1. **In-game**: Use the "Reset High Score" button in the pause menu
2. **Registry**: Delete the registry key mentioned above
3. **PowerShell**:
   ```powershell
   Remove-Item -Path "HKCU:\SOFTWARE\Unity\UnityEditor\DefaultCompany\2D_topdown_shooter" -Recurse
   ```

## Important Notes:

- Save data persists between game sessions
- The continue button will only work if save data exists
- Starting a new game will clear any existing save data
- Save data is specific to the current Windows user account
