# Rocket Boost (2.5D Precision Platformer)

## 🎥 Game Video
[Watch Gameplay Video](https://youtu.be/kVP1K6R4iCs)

---

## 🎮 Play this game
[Play on itch.io](https://panutatr.itch.io/rocket-boost)

---

## 🚀 Rocket Boost Game
Rocket Boost is a physics-based 2.5D control challenge inspired by classic arcade-style movement games. I built this project while learning, with a focus on precision movement and level design.
You control a rocket that moves only along the X and Y axes — there is no depth movement. Positioning and precision are everything.

<br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/2b1ecdea-78cc-4f09-93e8-3db77536ee8e" />
<br><img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/ffaee704-e2b6-486c-9ceb-692f6b8150c5" />

---

## ⚙️ Technical Highlights
- Engine: Unity 6 (6000.3.6f1)
- Programming Language: C#
- Physics-based movement using Rigidbody (3D)
- Manual thrust force application
- Collision detection with instant fail state
- Scene-based level progression

---

## 🎯 Objective
Launch the rocket from the start platform and reach the goal platform without colliding with any obstacles. The rocket can only touch the start and goal platforms.
There are no health points and no checkpoints — one collision means **GAME OVER**. To succeed, players must rely entirely on:

- Careful navigation through tight spaces
- Accurate rotation

<img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/1392135e-4971-4304-a715-4c39a8b47b76" />
<br><br>
  
- Momentum awareness
- Precise thrust control

<img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/dcf87215-3a9d-4f3e-ae2e-1dd60da18101" />

---

## 🎮 Controls
- **Spacebar** – Apply upward thrust
- **A / D** – Rotate the rocket on the Z axis

<img width="427" height="240" alt="image" src="https://github.com/user-attachments/assets/0f2bc229-06ad-41d8-b7df-9239ab2a847d" />

The rocket moves in the direction its nose is pointing.

---

## 🧠 Core Gameplay Focus
- Physics-based movement  
- Risk vs. control balance  
- Clean, skill-driven level design with increasing difficulty  
- Player mastery through repetition

---

## 🔧 Physics Approach
Although the game restricts movement to the X and Y axes, it intentionally uses Unity's 3D Rigidbody rather than 2D physics. This means the rocket carries real momentum, weight, and rotational inertia — giving the movement a physical weight that pure 2D physics would not replicate as naturally. The constraint to two axes is enforced through code, while the 3D physics engine handles all the feel.

---

## 🪄 Level Challenge
😏 There might be an alternative way to reach the goal in one of the levels. Try looking carefully 👀.

---

This project emphasizes precision control, physics-based movement, and mastery-driven gameplay.
