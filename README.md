# 2D Clothes Shop - Artur Pinheiro

This project uses an architecture based on ScriptableObjects as communication channels between components. This aims to eliminate the use of Singletons and limit the dependency between different components, keeping them as independent as possible and improving maintainability.

The Player has a cross-platform input system and an animation system based on different children playing simultaneously to support different types of clothing.

The shopping system is used simultaneously by both the player and the shopkeeper. Depending on the player's option (buy or sell) one or another displays their items in the same interface window that receives information about available items and the current money of the player. Subsequently triggering an item sale event that will notify the player and the store seller to update their respective inventories.

All items are ScriptableObjects with relevant information like icon, name, type, animator, etc.

The player can view their inventory through the UI and select which item they want to equip. An event is activated and is received by the player's inventory controller, animation controller and the inventory interface itself through the corresponding event channel. Each component updates its own information.

The flow of interface windows is exposed through UnityEvents present in each window and that activate each other in order to facilitate the construction of interfaces and keep them designer friendly.

The player equips their items based on a multiple animator system that requires each individual item to have a series of animations, which can be a very laborious process.

Given more time, a more effective system could be designed. In addition some updates could be implemented to improve game feel and performance, such as: using a pooling system for the items displayed in the store, making the player's movement more fluid, adding more dialog lines to the shopkeeper depending on the player's actions.
