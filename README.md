# ArenaShooter

Unity WebGL Project using Facebook SDK

Launch link:
https://pozmanadam.github.io/ArenaShooter/

Created with:
  - Unity 2019.4.16f1
  - FacebookSDK 8.1.1

Overview:

The main goal is to create a game which is integrated into facebook. Using the Facebook SDK for unity. This means you can only play if you are logged into facebook, and granted permission for it. You can also share the for the game, advertising it. Or to be more direct, you can invite your friends from facebook to try the game out. Pausing the game will display your profile picture, with your current high score.

The game is a simple 2D arena shooter. The only goal is to survive and score points. You can gain points by defeating enemies. There is only a single arena, where enemies spawn infinitely. The tiles of the arena is randomized at every new game, to give it a bit of variety. The spawn points are in the four corners, which they can spawn. Only one can spawn each time, what is every three second. The spawned enemy type is randomized.
There is only two type of enemies:
  - Slime
      - What only has contact damage, to make it easy in the beginning of the game. It's only following the player, and has three points of health.
  - Skeleton
      - What is moving a bit slower than the slime, but it's also shot at the player. Also can deal contact damage, and have four points of health. It's for the later part of the game, to keep being challenging.
      
The slime is relatively easy to defeat, so to increase the difficulty, the skeletons have a lower chance to spawn. In the beginning the chance is 10%, but with each scored point the chance is also increased by it. This means at 90 points there will be only skeletons spawn. 

The player can deal damage by shooting. There are three type of weapons that is accessible:
  - Pistol
      - This is the starting weapon, shot a single bullet, at a moderate speed.
  - Shotgun
      - This is the second weapon for upgrade. Shot four bullets, at slow speed.
  - Machinegun
      - This is the final weapon currently. Shoot a single bullet, at fast speed, and the bullets also fly faster.
 
The weapons are gained after a certain point, and cant change manually between them. They also indicate the current health points of the player. Taking damage will downgrade your weapon thus losing a health point, and your current points will be down to zero. This means that lower tier enemies will spawn, so the difficulty is dynamic. Taking damage with the pistol equipped, will be game over. After the damage the player will be invincible for two seconds, but it has no visual indication. We also keep track of the highest point so taking damage will not reset what you already achieved. The weapons also flip verrticaly if they would turn upside down. This aplies to the enemies, and the player model. 

You can pause the game any time, and can start a new one. 

Used reference:
https://developers.facebook.com/docs/unity


Used in the SDK:
  - Login 
      - For login to facebook, and gain permissions.
  - Game invites
      - To invite your friends to play
  - Share
      - You can share the game on your page, where your friends can see.
  - App Links
      - Used in the share to get the link for the game. So it doesn't matter where it is hosted.

