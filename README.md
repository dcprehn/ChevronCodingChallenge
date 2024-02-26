# ChevronCodingChallenge

As part of Chevron’s first virtual coding competition at Colorado School of 
Mines, this project is a Unity game about emerging renewable energies, directed
towards younger audiences to teach them about these technologies and how they 
can be utilized to make the world a better place. The game is a world
simulation spanning the next 5 years, and revolves around the creation of
energy powerplants.

## Table of Contents

- [Authors](#authors)
- [Setup](#setup)
- [Contents](#contents)
- [References](#references)
- [Submission](#submission)

## Authors

- [Rafael Rubin de Celis Urias](https://github.com/rafitarcu)
- [Devin Prehn](https://github.com/dcprehn)

## Setup

This game utilizes Unity Game Engine; go through the following steps to play:

1. Install [Unity Hub](https://unity.com/download) and your desired [Unity
Editor](https://unity.com/releases/editor/archive) if you haven't already. We
used Unity 2021.3.35 and would recommend this version to prevent any 
unintended side effects.

2. Clone the repository to the desired directory:

   ```bash
   git clone git@github.com:dcprehn/ChevronCodingChallenge.git
   ```

3. Open the project in Unity and hit play!

*This shouldn't be necessary, but if SharpGUI doesn't work you may need to
install a dependency for it: [UniRX](https://github.com/neuecc/UniRx)*

## Contents

Below is a visualization of the project file structure:

```
project
│   README.md
│   .gitignore
│
└───Assets
    └───Resources
    |   └───Prefabs
    |   └───Sprites
    |   └───ScriptableObjects
    |   └───Tech Tree
    |   └─── ...
    └───Scenes

```

Almost all of the game files are found in the `Assets` folder. The `Scenes`
folder contains the Scene that our game is played from. All `Prefabs`, 
`Sprites`, `ScriptableObjects`, and `GameObjectScripts` can be found in their
corresponding subfolders in the `Assets` folder.

## References

### Asset List

* World Map image: [File:Mercator-projection.jpg - Wikipedia](https://en.wikipedia.org/wiki/File:Mercator-projection.jpg)
* Bubble Sprites: [Glossy Bubbles | 2D Icons | Unity Asset Store](https://assetstore.unity.com/packages/2d/gui/icons/glossy-bubbles-114601)
* GUI Bars and Dialogs: [SharpUI GUI | 2D GUI | Unity Asset Store](https://assetstore.unity.com/packages/2d/gui/sharpui-gui-195933)

## Submission

### Presentation Slides

* PDF: Can be found at `SubmissionFiles/FinalPresentation.pdf`
* Tome Link: https://tome.app/chevron-coding-challenge/chevron-coding-challenge-clsxi8xyq00xhmx65ckud5toi

*Formatting looks better through the Tome website than it does as a PDF*

### Youtube Video:
https://youtu.be/CjjJ2IvgBhI?feature=shared

### Additional Materials
If you'd like to see some of our preliminary plans/brainstorming sessions, check out `SubmissionFiles/OneNoteFiles.pdf`!