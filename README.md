# Sorting Layer Puzzle

A puzzle mechanic prototype for my game Painted Hearts: drag the layers of a picture into the right order to reveal it.

## How it works

- **Drag to reorder.** Layers are UI elements you drag up and down; the stack reorders as you move them.
- **Right order, right picture.** Each layer knows its correct position and pushes its important items to the matching sorting order, so the picture looks right only when the stack is right.
- **Solve it.** When every layer is in place the puzzle shows "You Passed".
- **Data-driven.** Each layer's correct index and its key items live in a ScriptableObject, so new puzzles need no code.

Scripts: `DragController`, `Layer`, `LayerManager`, `LayerScriptableObject`.

## Status

An early prototype of the mechanic, not a finished level.

## Running it

Open the project in Unity and press Play.
