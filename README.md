# Burnout

A 2D top-down shooter game satirizing Hong Kong's work culture.  
Developed as a solo project for COMP3329 (Game Development).

## 📖 Story
The player is "burned out" by endless work and absurd policies.  
Using a **briefcase** (bomb projectile) and a **seatbelt** (melee whip), you fight through enemies, upgrade stats, and defeat the boss.

## 🎮 How to Play
- **WASD** – Move  
- **Mouse** – Aim  
- **Left Click** – Attack (current weapon)  
- **1 / 2** – Switch weapons (Briefcase / Seatbelt)  
- **E** – Interact with shop  
- **ESC** – Pause menu  

Defeat all enemies in a room → door unlocks.  
Collect gold → buy stat upgrades (damage, speed, health).  
Defeat the final boss to win.

## 🛠️ Setup (for developers)
1. **Unity version**: 2022.3 LTS or newer (2D URP not required).  
2. Clone the repository.  
3. Open the project in Unity.  
4. Open `Assets/Scenes/MainMenu.unity` (or the main scene).  
5. Press Play in the Editor.

## 📦 Building the game
- Go to `File > Build Settings`.  
- Add both `MainMenu` and `GameScene` to **Scenes in Build**.  
- Select `PC, Mac & Linux Standalone`.  
- Click `Build` and choose a destination.

## 🎨 Credits
- **Game Design & Code**: [Andy-lwk]  
- **Graphics**: AI‑generated (DALL‑E / Midjourney)  
- **Audio**: [freesound.org](https://freesound.org) + AI  
- **Inspiration**: *Enter the Gungeon* (Dodge Roll)

## ⚠️ Known Limitations
- Only one level (room1 → shop → boss).  
- No enemy/boss walk animations (only damage flash).  
- Basic enemy AI (no flanking).  
- Limited sound effects.

## 📄 License
For educational use only (COMP3329).

---
*Made with frustration and love for HK satire.*
