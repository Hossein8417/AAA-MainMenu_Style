# 🎮 Simple Game Main Menu

A modular Unity UI system built with C# using a State-based architecture.

The project uses a central UIManager, Registry, and IState interface to manage independent UI states such as Main Menu, Story, Extras, Options, Controls, Display, Graphics, Audio, Language, and Credits.

UI panel visibility and interaction are handled through a dedicated PanelsController, while navigation logic is being separated from individual UI states.

The project is also being migrated to Unity’s New Input System, with dedicated UI actions for navigation, submission, cancellation, pointer input, clicking, and scrolling.

The architecture is designed to keep UI navigation, UI presentation, input handling, and game systems separated and maintainable as the project grows.


---

## 📌 Project Goal

The purpose of this project is to build a complete, modern, and reusable **AAA-Style Main Menu System** similar to those used in AAA and indie games.

Instead of creating a full game, this project focuses on implementing the systems that players interact with before entering gameplay.

---

## ✨ Features

### 🏠 Main Menu
- Story Button
- Extras Button
- Options Button
- Exit Button

### ⚙️ Settings
- Audio Settings
  - World Volume
  - Music Volume
  - Effects Volume
- Graphics Settings
  - Resolution
  - Quality Levels
  - VSync
- Controls
  - Key Rebinding
  - Mouse Sensitivity
- Gameplay Settings
  - Difficulty
  - Language
  - Camera Options

### 💾 Save & Load
- Save Slots
- Auto Save Display
- Save Information Preview

### 🎨 UI
- Smooth Menu Transitions
- Keyboard & Controller Navigation

---

## 🛠 Technologies

- Unity
- C#
- Unity UI (UGUI)
- TextMesh Pro
- PlayerPrefs
- Animator (DOTween pro)
- Event System
- Localization
- Input System Support
---


## 🎯 Purpose

This project is intended for portfolio purposes and showcases:

- Clean C# architecture
- Modular UI design
- Reusable menu systems
- Animation workflows
- Data persistence
- User experience design
- Professional project organization

---

## 🚀 Future Improvements
- Optimizing Code and Scene
- Addressables Integration
