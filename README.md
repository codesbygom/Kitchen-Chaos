# Kitchen Chaos

A fast-paced kitchen cooking game built in Unity, made as part of a game development tutorial course. I built this project to learn core Unity systems — player movement, object interaction, cooking mechanics, and UI — by following along with a structured tutorial rather than designing it from scratch.

Grab ingredients, chop, cook, and plate dishes before the timer runs out!

**▶ Play it on itch.io:** [codesnmeshes.itch.io/kitchen-chaos](https://codesnmeshes.itch.io/kitchen-chaos)

## What I built

- **Player controller** — movement and collision handling, counter selection via raycasts, and input through Unity's new Input System, with keyboard and gamepad support and rebindable keys.
- **Counter system** — a `BaseCounter` base class with specialised counters (clear, container, cutting, stove, plates, trash, delivery), built on the `IInteractable`, `IInteractableAlternate`, `IKitchenObjectParent` and `IHasProgress` interfaces.
- **Data-driven recipes** — ingredients, cutting, frying, burning and delivery recipes defined as ScriptableObjects, so new content needs no code changes.
- **Cooking logic** — a stove with a state machine (idle → frying → fried → burned), cutting progress, and plates that accept only valid ingredients.
- **Game flow** — a `GameManager` state machine (countdown → playing → game over), pause, a recipe order queue with delivery validation, and scene loading.
- **Event-driven UI & audio** — C# events decouple gameplay from visuals, UI (progress bars, order list, burn warnings, clock, options menu) and sound/music managers.

## Tech

Unity 6 · C# · Universal Render Pipeline · Input System · TextMesh Pro

## Project structure

```
Assets/Scripts/
├── Counters/           counter types and their visuals
├── GameManagers/       game state, deliveries, sound, music
├── Interfaces/         interaction and progress contracts
├── PlayerScripts/      player movement, animation, sound
├── ScriptableObjects/  item and recipe data definitions
└── UIScripts/          HUD, menus and world-space UI
```

## Running locally

Open the project folder with Unity Hub (use the Unity version in `ProjectSettings/ProjectVersion.txt`), then open `Assets/Scenes/MainMenuScene.unity` and press Play.
