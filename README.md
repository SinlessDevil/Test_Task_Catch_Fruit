# Test Task - Catch Fruit
Gameplay: The player clicks on the product moving along the conveyor (i.e. can be in 
any part of the screen) - the character reaches for the product with one hand, then 
puts it in the basket. After moving the food to the basket, the text appears above it 
"+1". The text object flies up for 1 second and then animatedly disappears.
On the UI, above the character, the task of the current level is written in the format 
"Collect 3 Apples". The task is generated randomly (for example, "5 Bananas", "4
Oranges", etc.) The range of the number of products is from 1 to 5.

The final scene: When the player has collected the required number of products, the conveyor disappears, 
the camera moves closer to the character. The character starts dancing. On the UI, at the 
"Level Passed" appears at the top of the screen and the "Next Level" button 
button appears at the bottom. When you click the button, the level reloads.

---
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/GamePlay_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/GamePlay_2.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/GamePlay_3.png)
# Game logic
>Button through action

I made all the buttons on the stage through Action. It's quite convenient to subscribe to buttons + buttons don't know what they are responsible for, and this is its main advantage. This script generally complies with the SRP principle, so it can be used in other projects.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Button_Event.png)
---
>Language

this script is responsible for changing the language in the CurrentLanguage is set to the initial language. Everything is stored through PlayerPrefs because these are actually normal settings that can be safely stored in the registry, Localize is used as a component that we hang on the object. This whole module follows the SRP principle, it can be used anywhere, and you can add as many languages as you want.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Language.png)
---
>Script Level, Patter Mediator

This is the central script through which important information is exchanged. Through the Put and PickUp scripts, we change information about the current task and then pass the information to the Interface.

Pattern Mediator is a behavioral design pattern that reduces coupling between components of a program by making them communicate indirectly, through a special mediator object.

The Mediator makes it easy to modify, extend and reuse individual components because they’re no longer dependent on the dozens of other classes.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFilePatten_Mediator_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFilePatten_Mediator_2.png)
>Factory - Pattern Factory

an ordinary abstract factory,
+ The good thing is that we can create any factory and easily change it as needed.
- This factory uses instantiate. And this is not good, because it clogs up the memory. 
In action games, it is better to use Pool Object.

Abstract Factory is a creational design pattern, which solves the problem of creating entire product families without specifying their concrete classes.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Factory.png)
---
>Audio Clips, Pattern Singletone

This script is responsible for the sounds in the game. Briefly, it adds Audio components to the array, and with the help of Singletone I can play sounds from anywhere. But there is a drawback here, it's that I search by name, and this is very bad, because if you change the name of the component, the script will not work. But I haven't had any other option yet.

Singleton is a creational design pattern, which ensures that only one object of its kind exists and provides a single point of access to it for any other code.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Singletone.png)
---
>Save System - Player Prefs

I saved the game settings with the help of PlayerPrefs

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Player_Prefs.png)
---
>PickUp, Put, Fruit - Pattern Visitor

Made a hierarchy of fruits.
The PickUp script is responsible for grabbing products.
The Put script is responsible for putting the character in the cart or throwing it out.
Here I used the Visitor pattern to add some other game objects, but I didn't have time.

Visitor is a behavioral design pattern that allows adding new behaviors to existing class hierarchy without altering any existing code.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Visitor_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Visitor_2.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Visitor_3.png)
---
>Animation - Pattern State

I implemented the animations using the State

State is a behavioral design pattern that allows an object to change the behavior when its internal state changes.

The pattern extracts state-related behaviors into separate state classes and forces the original object to delegate the work to an instance of these classes, instead of acting on its own.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_State_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_State_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_State_1.png)
---
>Interface - Pattern Observer

All the information that is displayed, I passed through Action, i.e. I used Pattern Observer

Observer is a behavioral design pattern that allows some objects to notify other objects about changes in their state.
The Observer pattern provides a way to subscribe and unsubscribe to and from these events for any object that implements a subscriber interface.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Observer_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Observer_1.png)
---
>Task - Pattern Observer and StringBuilder

Here I just want to point out that I used Action to pass the information to the interface, also used StringBuilder, because there is quite a lot of string whitening and it clogs up the memory.

![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Flyweight%2BObserver_1.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Flyweight%2BObserver_2.png)
![Image alt](https://github.com/SinlessDevil/Test_Task_Catch_Fruit/blob/fixed/Screenshots%20For%20ReadMeFile/Pattern_Flyweight%2BObserver_3.png)
---

That's all
