


using AutoEvent.Interfaces;

namespace BuckshotRoulette
{
    public class BuckshotConfig : EventConfig
    {
        public ItemType ItemOther { get; set; } = ItemType.KeycardZoneManager;
        public ItemType ItemSelf { get; set; } = ItemType.KeycardFacilityManager;
    }
}
