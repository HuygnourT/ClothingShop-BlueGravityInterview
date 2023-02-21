# Clothing Shop!
Clothing Shop is a features of Open World Pixel 2D RPG Game
Core class reference from Unity 2D Template project , and customize for suitable with project 
# Core
 1. Schedule.cs
	*Schedule class implements the discrete event simulator pattern*
 2. Event.cs
	An event allows execution of some logic to be defferred for a period time*
 3. InstanceRegister.cs
	 Simulation model instance for a class
	 
## Gameplay
 1. CharacterSkin.cs

> CharacterSkin class implements the functions for change skin character
 2. GameModel.cs
> GameModel which control all controllers in game
 3. InventoryItem.cs
> InventoryItem class implements the functions for collectible item ( included sprite , name text and configuration of item )
 4. ItemInShop.cs
> A struct for ItemShop
### Controller
 1. CameraController.cs
> A simple camera follower
 3. CharacterController.cs
> A simple controller 2D Character which control State of Character
 5. GameController.cs
> GameController class which control every tick of schedule , to run event in queue
 7. InputController.cs
> InputController class which control state of game ( included CharacterControl, DialogControl, InventoryControl, ShopControl ) and receive input from keyboard to response in game
 9. ItemController.cs
> ItemController class which contain all configuration of item in game , GameModel can get item configuration through itemCode
 10. NPCController.cs
> NPCController class which contain conversation content so that it can show in UI
 12. NPCShopController.cs
 > NPCShopControllerclass inherits from NPCController which contain ItemInShop so that player can buy / sell item from ItemInShop 
## ScriptableObjects
InventoryItemConfiguration.cs
> InventoryItemConfiguration class , which have information of items ( InventoryItemType, itemCode, spriteItem, nameItem, descriptionItem)
## Events
1. OpenShop.cs
> Excute Event OpenShop
2. ShowConversation.cs
> Excute Event ShowConversation
3. StopTalking.cs
> Excute Event StopTalking

## UI
1. BaseItemUI.cs
> BaseItemUI class which have information about Item to show in UI
2. DialogUIController
> DialogUIController class which control dialog UI can call function from GameModel to switch select option button
3. DialogUILayout
> DialogUILayout contains text about conversation, content options in conversation 
4. EquipmentItemUI
> EquipmentItemUI inherits from BaseItemUI, which call function to unequip item from inventory
5. InventoryItemUI
> InventoryItemUI inherits from BaseItemUI, which call function to equip item from inventory
6. InventoryUIController
> InventoryUIControllerclass which control Inventory UI can call function from GameModel to show Item in inventory 
7. InventoryUILayout
> InventoryUILayout contains InventoryItemUI, EquipmentItemUI to implement Click, Enter and Exit function
8. ShopItemUI
> ShopItemUI inherits from BaseItemUI, which have 
9. ShopUIController
> ShopUIController class which control shop UI can call function from GameModel to buy, sell, setup content from ItemConfiguration to show in UI
10. ShopUILayout
> ShopUILayout contains ShopItemUI and text to show information about Item selected and to implement Click, Enter and Exit function
11. SpriteButton
> SpriteButton class which contain some attributes for button (sprite , text , size and ClickEvent , EnterEvent, ExitEvent)
12. SpriteUIElement
> 
