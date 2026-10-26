# Unity Player Info and Preferences

## How the scripts work

- `Assets/ScriptableObjects/PlayerInfo_SO.cs` defines a ScriptableObject with a
  player's name, level, and health. The sample asset is
  `Assets/ScriptableObjects/PlayerInfo_SO.asset`.
- `Assets/ScriptableObjects/SO_Manager.cs` displays those three fields in
  TextMeshPro UI when the scene starts. It also initializes and listens to a
  volume slider.
- The slider ranges from `0.01` to `1`. `SO_Manager` converts its value to an
  integer percentage with `Mathf.RoundToInt(sliderValue * 100)`, clamps the
  result to `1`–`100`, updates the volume label, and saves it under the
  `Volume` key in `PlayerPrefs`.
- On startup, the saved integer volume is read (default `50`) and divided by
  `100` to set the slider without triggering its change listener. The current
  value is then displayed and saved.
- The player-name and sensitivity labels read the `PlayerName` and
  `Sensitivity` keys from `PlayerPrefs`, using `Larry` and `1.0` as defaults.
  This project currently reads those two keys but does not provide UI to
  change or save them.
- `OnDestroy` removes the slider listener when the manager is destroyed.

`PlayerPrefs` is local to the running platform/user 

## Test the features

1. Open `Assets/Scenes/SampleScene.unity` and press **Play**.
2. Move the volume slider. The volume label should update immediately to an
   integer from `1` to `100`.
3. Stop and restart Play mode. The slider and label should retain the last
   saved volume.

