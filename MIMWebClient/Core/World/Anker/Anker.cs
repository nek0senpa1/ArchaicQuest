﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIMWebClient.Core.Item;

namespace MIMWebClient.Core.World.Anker
{
    using MIMWebClient.Core.Player;
    using MIMWebClient.Core.PlayerSetup;
    using MIMWebClient.Core.Room;

    public static class Anker
    {
        public static Room VillageSquare()
        {

            /*
             *  Region: the province the area is in
             *  Area : Name of area in Region
             *  AreaId: Must be unique and used to for finding the room. Entering a room using Region + area + id
             *  Title: Title of room
             *  description: Description of room can use HTML (No defined classes yet for colour output)
             *  exits = new List<Exit>(), 
                items = new List<Item.Item>(),
                mobs = new List<Player>(),
                terrain = Room.Terrain.Field,
                keywords = new List<RoomObject>(),
                corpses = new List<Player>(),
                players = new List<Player>(),
                fighting = new List<string>(),
                clean = true, sets the room as untouched. gets set to false with interation like get, mob death etc
             * 
             * 
             */

            var room = new Room
            {
                region = "Anker",
                area = "Anker",
                areaId = 0,
                title = "Village Square",
                description = "<p>A wide open space stretches out here at the centre point of Anker. " +
                              "A few trees dot the green space but the village well dominates the middle" +
                              " of the square and is used frequently by villagers and passers-by, a dirt track " +
                              "forged by hundreds of feet forms a central square with paths leading in all cardinal " +
                              "directions back to Square walk. Benches sit either side of the pathways facing the inner square.</p>" +
                              "<p> A tall wooden signpost stands near to the well showing directions to key places of Anker. " +
                              "The village notice board has been hammered into a large oak tree near the path to the centre.</p>",

                //Defaults
                exits = new List<Exit>(),
                items = new List<Item.Item>(),
                mobs = new List<Player>(),
                terrain = Room.Terrain.Field,
                keywords = new List<RoomObject>(),
                corpses = new List<Player>(),
                players = new List<Player>(),
                fighting = new List<string>(),
                clean = true,
                

            };

            //Room Keywords

            /*
             *  All items mentioned in the description should have keywords
             *  name: name of object, this is used to find the object.
             *  look: basic description
             *  examine: more in depth description
             *  touch: touch description
             *  smell: smell description
             * 
             */

            var well = new RoomObject
            {
                name = "Stone well",
                look = "A well used wooden bucket hangs lopsided by a rope swinging over the well. On the side of the well is a handle used for lowering and lifting the bucket.",
                examine = "Inscribed in one of the stone blocks of the well is IX-XXVI, MMXVI",
                touch = "The stone fills rough to touch",
                smell = "The water from the well smells somewhat fresh and pleasant"
            };

            var signpost = new RoomObject
            {
                name = "Signpost",
                look = "The signpost points:<br /> " +
                       "<span class='RoomExits'>North</span><br /> The Drunken Sailor<br />" +
                       "<span class='RoomExits'>North East</span><br />  General Store <br /> Black smith<br />" +
                       "<span class='RoomExits'>East</span><br />Village hall<br />" +
                       "<span class='RoomExits'>South East</span><br />Church<br />" +
                       "<span class='RoomExits'>North West</span><br /> Stables.",
                examine = "The signpost points:<br /> " +
                       "<span class='RoomExits'>North</span><br /> The Drunken Sailor<br />" +
                       "<span class='RoomExits'>North East</span><br />  General Store <br /> Black smith<br />" +
                       "<span class='RoomExits'>East</span><br />Village hall<br />" +
                       "<span class='RoomExits'>South East</span><br />Church<br />" +
                       "<span class='RoomExits'>North West</span><br /> Stables.",
                touch = "The signpost is finely crafted and smooth to touch",
                smell = "The signpost has no obvious smell"
            };



            var bucket = new RoomObject
            {
                name = "Bucket",
                look ="A well used wooden bucket hangs lopsided over the well. On the side is a handle used for lowering and lifting the bucket.",
                examine = "Inside the bucket you see some gold coins",
                touch = "The bucket is wet to touch",
                smell = "The bucket smells damp"
            };

            var noticeboard = new RoomObject
            {
                name = "Village notice board",
                look = "A notice board has been hammered into the oak tree with only one piece of parchment attached",
                examine = "You take a closer look at the notice board and read the parchment attached <br />"
                + "Welcome to MIM <br /> This is the starting village. You can look, examine obviously. Move using N,E,south etc. look around and let me know what you think...",
                touch = "The notice board is wooden and smooth to touch",
                smell = "The notice board has no obvious smell "
            };

            /* Adding Items
             *  Name: of Item
             *  Conainer Items: is a list of Item
             *  contianer: true, means it's a container
             *  container size: how many items it can fit
             *  Can lock: true, means lockable/unlockable
             *  isvisible: can the player see it? This is good if you want items to be hidden unless a player examines say a stool and finds a lock pick under it.
             *  location: has to be room, if it's in a room. Inventory for if it's being carried, wield if it's wielded and worn if the player/mob is wearing it
             *  description: Look, exam etc same as room descriptions
             *  open: for doors and containers. false means shut.
             *  canOpen: Means it's a container that's openable
             *  locked: true = locked.
             *  Keyid: is a newGuid, and the generated ID is then given to a keyvalue on another item which is used to unlock the item
             *  keyvalue: = keyId if set
             */

            //add some gold to bucket
            var woodenChestObj = new Item.Item
            {

                name = "Wooden Chest",
                containerItems = new List<Item.Item>(),
                canLock = true,
                containerSize = 10,
                container = true,
                location = Item.Item.ItemLocation.Room,
                description = new Item.Description { look = "Small Chest by the well" },
                open = false,
                canOpen = true,
                locked = true,
                keyId = Guid.NewGuid().ToString(),
                stuck = true
            };

            woodenChestObj.keyValue = woodenChestObj.keyId;
            room.items.Add(woodenChestObj);


            var oddKey = new Item.Item
            {

                name = "Odd looking key",
                location = Item.Item.ItemLocation.Room,
                description = new Item.Description { look = "Odd looking Key" },
                keyValue = woodenChestObj.keyId
        };
            room.items.Add(oddKey);


            var bucketObj = new Item.Item();




            var bucketGold = new Item.Item();

            bucketObj.container = true;
            bucketObj.waterContainer = true;
            bucketObj.waterContainerSize = 15;
            bucketObj.containerItems = new List<Item.Item>();
            bucketObj.isHiddenInRoom = true;
            bucketObj.name = "bucket";

            bucketGold.count = 5;
            bucketGold.type = Item.Item.ItemType.Gold;
            bucketGold.name = "Gold Coins";

            bucketObj.containerItems.Add(bucketGold);



            var bench = new RoomObject
            {
                name = "Stone bench",
                look = "A stone bench sits under the conopy of the large oak tree",
                examine = "There is nothing more of detail to see",
                touch = "The stone fills rough to touch",
                smell = "The smell of flowers is smelt by the bench"
            };


            room.keywords.Add(signpost);
            room.keywords.Add(noticeboard);
            room.keywords.Add(bucket);
            room.keywords.Add(well);
            room.keywords.Add(bench);

            /*
             * 
             * name: "North", East, South, West. List must be added in that order. To have another exit suchas a portal or hidden crevice we need an enter commande: Enter portal for example
                area = "Anker", - The area the exit leads to
                region = "Anker", - The region the exit leads to
                areaId = 1, - THe room id the exit leads too
                keywords = new List<string>(), - this may be obsolete or should be used as description below does not work
                hidden = false, - is the exit hidden?
                locked = false, - is the exit locked?
                canLock = true, - can it be locked?
                canOpen = true, - is it openable?
                open = true, - is it open
                doorName = "wooden door", - name of door/exit
                description = new Item.Description - doesn't seem to work
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                },
             * 
             */

            // Create Exits
            var north = new Exit
            {
                name = "North",
                area = "Anker",
                region = "Anker",
                areaId = 1,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                canLock = true,
                canOpen = true,
                open = true,
                doorName = "wooden door",
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                },
               
            };

            

            //create items

            room.items.Add(bucketObj);

            room.exits.Add(north);

            //Create Mobs
            var cat = new Player
                          {
                NPCId = 0,
                Name = "Black and White cat", Type = Player.PlayerTypes.Mob, Description = "This black cat's fur looks in pristine condition despite being a stray.",
                              Strength = 12, Dexterity = 12, Constitution =12, Intelligence = 1, Wisdom = 1, Charisma = 1, MaxHitPoints = 50, HitPoints = 50, Level = 2, Status = Player.PlayerStatus.Standing, 
              Skills = new List<Skill>(),
              Inventory = new List<Item.Item>()

           
        };

            var cat2 = new Player
            {
                NPCId = 1,
                Name = "Black and White cat",
                Type = Player.PlayerTypes.Mob,
                Description = "This black cat's fur looks in pristine condition despite being a stray.",
                Strength = 12,
                Dexterity = 12,
                Constitution = 12,
                Intelligence = 1,
                Wisdom = 1,
                Charisma = 1,
                MaxHitPoints = 50,
                HitPoints = 50,
                Level = 2,
                Status = Player.PlayerStatus.Standing,
                Skills = new List<Skill>(),
                Inventory = new List<Item.Item>()


            };


            var dagger = new Item.Item
            {
                actions = new Item.Action(),
                name = "Blunt dagger",
                eqSlot = Item.Item.EqSlot.Wield,
                weaponType = Item.Item.WeaponType.ShortBlades,
                stats = new Item.Stats { damMin = 2, damMax = 4, minUsageLevel = 1 },
                type = Item.Item.ItemType.Weapon,
                equipable = true,
                attackType = Item.Item.AttackType.Pierce,
                slot = Item.Item.EqSlot.Wield,
                location = Item.Item.ItemLocation.Inventory
            };


            var dagger2 = new Item.Item
            {
                actions = new Item.Action(),
                name = "Flaming dagger",
                eqSlot = Item.Item.EqSlot.Wield,
                weaponType = Item.Item.WeaponType.ShortBlades,
                stats = new Item.Stats { damMin = 21, damMax = 44, minUsageLevel = 1 },
                type = Item.Item.ItemType.Weapon,
                equipable = true,
                attackType = Item.Item.AttackType.Pierce,
                slot = Item.Item.EqSlot.Wield,
                location = Item.Item.ItemLocation.Inventory
            };


            var dagger3 = new Item.Item
            {
                actions = new Item.Action(),
                name = "Gold dagger",
                eqSlot = Item.Item.EqSlot.Wield,
                weaponType = Item.Item.WeaponType.ShortBlades,
                stats = new Item.Stats { damMin = 1, damMax = 100, minUsageLevel = 1 },
                type = Item.Item.ItemType.Weapon,
                equipable = true,
                attackType = Item.Item.AttackType.Pierce,
                slot = Item.Item.EqSlot.Wield,
                location = Item.Item.ItemLocation.Inventory
            };


            room.items.Add(dagger2);
            room.items.Add(dagger3);

            cat.Inventory.Add(dagger);

            /* how to add skills but think this needs rethinking */
            //var h2h = Skill.Skills().Find(x => x.Name.Equals(Skill.HandToHand));

            //h2h.Proficiency = 1;

            //cat.Skills.Add(h2h);          

            var recall = new Recall
            {
                Area = room.area,
                AreaId = room.areaId,
                Region = room.region
            };


            cat.Recall = recall;
            cat2.Recall = recall;

            room.mobs.Add(cat);
            room.mobs.Add(cat);


            return room;
        }

        public static Room SquareWalkOutsideTavern()
        {
            var room = new Room
            {
                region = "Anker",
                area = "Anker",
                areaId = 1,
                title = "Square walk, outside the Red Lion",
                description = "<p>The Red Lion occupies the north western part of Square walk. It's large oval wooden door is kept closed keeping the warmth inside as well as the hustle and bustle hidden from the outside." +
                              "Large windows sit either side of the door to the black and white timber building. The inn carries on to the west where the stables reside. " +
                              "The dirt track of square walk continues west and east towards the general store.</p>",

                //Defaults
                exits = new List<Exit>(),
                items = new List<Item.Item>(),
                mobs = new List<Player>(),
                terrain = Room.Terrain.Field,
                keywords = new List<RoomObject>(),
                corpses = new List<Player>(),
                players = new List<Player>(),
                fighting = new List<string>(),
                clean = true

            };



            var trainer = new Player
            {
                NPCId = 0,
                Name = "Lance",
                Type = Player.PlayerTypes.Mob,
                Description = "The elder of the village anker",
                Strength = 15,
                Dexterity = 16,
                Constitution = 16,
                Intelligence = 12,
                Wisdom = 16,
                Charisma = 18,
                MaxHitPoints = 250,
                HitPoints = 250,
                Level = 15,
                Status = Player.PlayerStatus.Standing,
                Skills = new List<Skill>(),
                Inventory = new List<Item.Item>(),
                Trainer = true
            };




            #region exits


            // Create Exits
            var north = new Exit
            {
                name = "North",
                area = "Anker",
                region = "Anker",
                areaId = 2,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };

            // Create Exits
            var south = new Exit
            {
                name = "South",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };


            // Create Exits
            var east = new Exit
            {
                name = "East",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };


            // Create Exits
            var west = new Exit
            {
                name = "West",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };

            #endregion
            room.exits.Add(north);
            room.exits.Add(east);
            room.exits.Add(south);         
            room.exits.Add(west);

            room.mobs.Add(trainer);




            return room;
        }

        public static Room SquareWalkOutsideStables()
        {
            var room = new Room
            {
                region = "Anker",
                area = "Anker",
                areaId = 1,
                title = "Square walk, outside the stables of the Red Lion",
                description = "<p>This corner of Square walk gives access to the stables of the Red lion. Mainly used by travellers to house their mounts." +
                              "bits of hay and manure litter the northern entrance to the stables. Square walk continues south and east to the entrance of The Red Lion. </p>",

                //Defaults
                exits = new List<Exit>(),
                items = new List<Item.Item>(),
                mobs = new List<Player>(),
                terrain = Room.Terrain.Field,
                keywords = new List<RoomObject>(),
                corpses = new List<Player>(),
                players = new List<Player>(),
                fighting = new List<string>(),
                clean = true

            };



          


            #region exits


            // Create Exits
            var north = new Exit
            {
                name = "North",
                area = "Anker",
                region = "Anker",
                areaId = 2,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };

            // Create Exits
            var south = new Exit
            {
                name = "South",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };


            // Create Exits
            var east = new Exit
            {
                name = "East",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };


           

            #endregion
            room.exits.Add(north);
            room.exits.Add(east);
            room.exits.Add(south);



            return room;
        }

        public static Room SquareWalkWestOfCentre()
        {
            var room = new Room
            {
                region = "Anker",
                area = "Anker",
                areaId = 1,
                title = "Square walk, west of the centre",
                description = "<p></p>",

                //Defaults
                exits = new List<Exit>(),
                items = new List<Item.Item>(),
                mobs = new List<Player>(),
                terrain = Room.Terrain.Field,
                keywords = new List<RoomObject>(),
                corpses = new List<Player>(),
                players = new List<Player>(),
                fighting = new List<string>(),
                clean = true

            };






            #region exits


            // Create Exits
            var north = new Exit
            {
                name = "North",
                area = "Anker",
                region = "Anker",
                areaId = 2,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };

            // Create Exits
            var south = new Exit
            {
                name = "South",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };


            // Create Exits
            var east = new Exit
            {
                name = "East",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "To the north you see the inn of the drunken sailor.", //return mobs / players?
                    exam = "To the north you see the inn of the drunken sailor.",

                }
            };




            #endregion
            room.exits.Add(north);
            room.exits.Add(east);
            room.exits.Add(south);



            return room;
        }

        public static Room DrunkenSailor()
        {
            var room = new Room
            {
                region = "Anker",
                area = "Anker",
                areaId = 2,
                title = "The Drunken Sailor",
                description = "The inside of the tavern is a single, low-roofed room. Rancid oil lamps emit a gloomy light." +
                " Only a handful of people can be seen through the smoke-filled air. A small door to the west leads out to the stables." +
                " A bad-tempered looking barkeeper seems to be cleaning the counter. ",
      
                //Defaults
                exits = new List<Exit>(),
                items = new List<Item.Item>(),
                mobs = new List<Player>(),
                terrain = Room.Terrain.Inside,
                keywords = new List<RoomObject>(),
                corpses = new List<Player>(),
                players = new List<Player>(),
                fighting = new List<string>(),
                clean = true

            };


            var modo = new Player
            {
                NPCId = 0,
                Name = "Modo",
                Type = Player.PlayerTypes.Mob,
                Description = "The owner of the Drunken Sailor is a tall and intimidating appearance. This long-bearded man immediatly makes you feel uncomfortable. He does not seem to notice you.",
                Strength = 15,
                Dexterity = 16,
                Constitution = 16,
                Intelligence = 9,
                Wisdom = 11,
                Charisma = 8,
                MaxHitPoints = 100,
                HitPoints = 100,
                Level = 10,
                Status = Player.PlayerStatus.Standing,
                Skills = new List<Skill>(),
                Inventory = new List<Item.Item>()
            };

            var dyten = new Player
            {
                NPCId = 1,
                Name = "Dyten",
                Type = Player.PlayerTypes.Mob,
                Description = "This weathered old man probably never leaves this place. His cloudy eyes seem to seek something at the bottom of his glass.",
                Strength = 1,
                Dexterity = 2,
                Constitution = 2,
                Intelligence = 2,
                Wisdom = 5,
                Charisma = 1,
                MaxHitPoints = 100,
                HitPoints = 100,
                Level = 1,
                Status = Player.PlayerStatus.Busy,
                Skills = new List<Skill>(),
                Inventory = new List<Item.Item>()
            };

            var recall = new Recall
            {
                Area = room.area,
                AreaId = room.areaId,
                Region = room.region
            };

            modo.Recall = recall;
            dyten.Recall = recall;



            room.mobs.Add(modo);
            room.mobs.Add(dyten);
            #region exits
 

                // Create Exits
                var west = new Exit
            {
                name = "West",
                area = "Anker",
                region = "Anker",
                areaId = 0,
                keywords = new List<string>(),
                hidden = false,
                locked = false,
                description = new Item.Description
                {
                    look = "A small wooden door leads to the stables.", //return mobs / players?
                    exam = "The door seems closed. Maybe you can open it by using your hands.",

                }
            };

            #endregion
          
            room.exits.Add(west);

            var counter = new RoomObject
            {
                name = "Wooden Counter",
                look = "The surface is full of suspicious smudges. You better not touch it.",
                examine = "There is nothing more of detail to see.",
                touch = "The wood feels sticky.",
                smell = "It smells like endless nights of drinking and smoking."
            };

            var table = new RoomObject
            {
                name = "A sturdy table",
                look = "A small lamp is placed in its center. Scratches tell of wild nights in the past.",
                examine = "There is nothing more of detail to see.",
                touch = "The wood feels sticky.",
                smell = "It smells like endless nights of drinking and smoking."
            };


            room.keywords.Add(table);
            room.keywords.Add(counter);



            return room;
        }

       
    }
}