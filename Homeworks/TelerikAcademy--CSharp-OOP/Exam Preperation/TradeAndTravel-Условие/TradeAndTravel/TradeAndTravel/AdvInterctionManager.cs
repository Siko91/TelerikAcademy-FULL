using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class AdvInteractionManager : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected void HandleGatherInteraction(string[] commandWords, Person actor) 
        {
            var location = actor.Location as IGatheringLocation;
            if (location == null)
            {
                return;
            }
            if (!actor.ListInventory().Any(item => item.ItemType == location.RequiredItem))
            {
                return;
            }

            Item itemToAdd = location.ProduceItem(commandWords[2]);
            actor.AddToInventory(itemToAdd);
        }
        protected void HandleCraftInteraction(string[] commandWords, Person actor) 
        {
            switch (commandWords[2])
            {
                case "weapon":
                    if (CheckCraftingRequirements(Weapon.GetComposingItems(), actor))
                    {
                        Item itemToAdd = new Weapon(commandWords[3]);
                        actor.AddToInventory(itemToAdd);
                    }
                    break;
                case "armor":
                    if (CheckCraftingRequirements(Armor.GetComposingItems(), actor))
                    {
                        Item itemToAdd = new Armor(commandWords[3]);
                        actor.AddToInventory(itemToAdd);
                    }
                    break;
                default:
                    return;
            }
        }

        protected bool CheckCraftingRequirements(List<ItemType> requiredItems, Person actor)
        {
            bool requirementsCovered = true;
            foreach (ItemType req in requiredItems)
            {
                if (!(actor.ListInventory().Any(item => item.ItemType == req)))
                {
                    requirementsCovered = false;
                }
            }
            return requirementsCovered;
        }
    }
}
