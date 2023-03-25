# CG_Kuer

## About the game

This untitled game was created for the class "Computergrafik" at HTW Berlin. I wanted to make a mobile game, so I developed it using the proportions of my own phone - a Moto G8 Power.

Its a 2D merging game featuring 3 levels with increasing difficulty, a small shop and a soundtrack. 
Objects spawn and fall down top to bottom and land at random positions. They can then be dragged around the screen. When players drag objects of the same kind and they overlap by more than 50%, they "merge" and create a new object. For each merge, the player is rewarded with points increasing with each new object level (e.g. 10 points for merging two objects of object level 1, 100 points for merging two objects of object level 2). 

When the player earned 100 points, the shop gets enabled, where they can buy an increase in speed for 100 points. There are three increases available, each costing 100 points more than their predecessor. Also available in the shop is a glitter effect for 1000 points which adds glittering particles to each objects.


## Guides and tutorials 

### Menus

For creating the start menu and the audio settings, I followed tutorials by youtube creator Brackeys.

Start Menu: https://www.youtube.com/watch?v=zc8ac_qUXQY&t=671s&ab_channel=Brackeys

Volume Settings: https://www.youtube.com/watch?v=YOaYQrN1oYQ&ab_channel=Brackeys



### Glitter Effect

In the shop, players can activate a glitter effect, which was created not by script but with the unity editor particle system. For this, I used this youtube tutorial: htps://www.youtube.com/watch?v=tW9EUwiRvIM


### Hover Effect

I added a script to make the buttons increase in size when hovering over them. I encountered a problem and used this resource from the unity forum to fix the issue: https://answers.unity.com/questions/1199251/onmouseover-ui-button-c.html. It turned out you can't use OnMouseOver on UI elements. 


### Multiple sprites in one prefab:

Instead of having a lot of prefabs waiting for their turn and destroying and creating objects constantly, I used this snippet to help me create objects with a dynamic list of different sprites so I can make multiple levels with different amounts of objects, using only the minimum amount of prefabs: https://www.gamedev.net/tutorials/programming/general-and-gameplay-programming/unity-how-to-add-multiple-sprites-to-a-list-in-the-inspector-the-fast-way-r5271/

### Pulse effect on merge

For the pulsing effect on merge, I learned about a new method in Unity called Mathf.Lerp: https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html, which is a mathematical function in C# that performs linear interpolation between two values. By using Mathf.Lerp, I was able to smoothly transition the scale of the  objects between their original size (transform.localScale) and a chosen maximumm value. 

### Saving game progress

It was also the first time I actively used PlayerPrefs: https://docs.unity3d.com/ScriptReference/PlayerPrefs.html. I used SetInt or SetFloat to safe values such as mergeCount or spawn interval and DeleteKey to delete these values from cache when a new game is started.


## Assets used

### 2D Assets

The game uses 2D assets from the free 2D Mega Pack by the creator Brackeys available on the Unity Asset Store: https://assetstore.unity.com/packages/2d/free-2d-mega-pack-177430. This pack includes a variety of sprites and animations of which I used a few to create the sprites of the mergeable objects.

### Music

The song I used is not included in this repository for copyright reasons, but if you want to listen to a nice relaxing song that won't get on your nerve when you have to listen to it on repeat, check out: https://open.spotify.com/track/4MVk79dmYqi7HQs0bMgboy?si=e9ffb2729df34486

