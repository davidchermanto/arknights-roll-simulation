# Arknights Roll Screen Simulation

## Disclaimer

This is an unofficial fan project for Arknights, a game developed by Hypergryph. This project is created by a fan and is not affiliated with, endorsed by, or connected to Hypergryph or any of its affiliated entities. All intellectual property rights, including but not limited to characters, artwork, and trademarks, are owned by their respective owners, namely Hypergryph. The purpose of this fan project is solely for education, entertainment, and community engagement.

## Description

This is a small project aimed to recreate the gacha roll screen from Arknights using Unity.

An example of the original screen:
![](https://github.com/davidchermanto/arknights-roll/blob/master/Samples/OriginalSim.gif)

The recreation using this tool:
![](https://github.com/davidchermanto/arknights-roll/blob/master/Samples/SampleSim.gif)

## Setting Up

There are no dependencies; setting up is extremely simple.

* Open up MainScene.unity.
* Hit Play.

Almost all aspects of this is customizable. The GameObjects are located as follows:

* **Name, Class Icon, Class Name:** Canvas/MovingGroup/...
* **Rarity / Star Count:** Canvas/Stars/...
* **Voiceline Description:** Canvas/TextBox/...
* **Character Image / Faction Logo:** Perm Components/MovingGroupSlow/...

Various other effects such as the random lighting and particles can be tuned with scripts attached to them, such as in Canvas/MovingGroup/RepeatingFlash in order to control the random "glitches" that appear on-screen.

## Future Direction

A GUI is to be added to manually be able to upload images and text in order to be able to generate the animations on a compiled version of this project.

## Issues

Description text occassionally does not wrap correctly to the next line, which does not happen in the original animations.
