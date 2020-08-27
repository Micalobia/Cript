using System;

namespace Cript.Data
{
    public static class EnumExtensions
    {
        public static string Prefex(this CoordinateType type)
        {
            switch (type)
            {
                case CoordinateType.Relative: return "~";
                case CoordinateType.Local: return "^";
                default: return "";
            }
        }
        public static string Prefex(this RotationType type) => type == RotationType.Relative ? "~" : "";
        public static string Prefex(this SelectorType type)
        {
            switch (type)
            {
                case SelectorType.S: return "@s";
                case SelectorType.R: return "@r";
                case SelectorType.E: return "@e";
                case SelectorType.A: return "@a";
                case SelectorType.P: return "@p";
                case SelectorType.None:
                default: return "";
            }
        }
        public static string Namespaced(this EntityType type)
        {
            switch(type)
            {
                case EntityType.AreaEffectCloud: return "minecraft:area_effect_cloud";
                case EntityType.ArmorStand: return "minecraft:armor_stand";
                case EntityType.Arrow: return "minecraft:arrow";
                case EntityType.Bat: return "minecraft:bat";
                case EntityType.Bee: return "minecraft:bee";
                case EntityType.Blaze: return "minecraft:blaze";
                case EntityType.Boat: return "minecraft:boat";
                case EntityType.Cat: return "minecraft:cat";
                case EntityType.CaveSpider: return "minecraft:cave_spider";
                case EntityType.ChestMinecart: return "minecraft:chest_minecart";
                case EntityType.Chicken: return "minecraft:chicken";
                case EntityType.Cod: return "minecraft:cod";
                case EntityType.CommandBlockMinecart: return "minecraft:command_block_minecart";
                case EntityType.Cow: return "minecraft:cow";
                case EntityType.Creeper: return "minecraft:creeper";
                case EntityType.Dolphin: return "minecraft:dolphin";
                case EntityType.Donkey: return "minecraft:donkey";
                case EntityType.DragonFireball: return "minecraft:dragon_fireball";
                case EntityType.Drowned: return "minecraft:drowned";
                case EntityType.Egg: return "minecraft:egg";
                case EntityType.ElderGuardian: return "minecraft:elder_guardian";
                case EntityType.EndCrystal: return "minecraft:end_crystal";
                case EntityType.EnderDragon: return "minecraft:ender_dragon";
                case EntityType.Enderman: return "minecraft:enderman";
                case EntityType.Endermite: return "minecraft:endermite";
                case EntityType.EnderPearl: return "minecraft:ender_pearl";
                case EntityType.Evoker: return "minecraft:evoker";
                case EntityType.EvokerFangs: return "minecraft:evoker_fangs";
                case EntityType.ExperienceBottle: return "minecraft:experience_bottle";
                case EntityType.ExperienceOrb: return "minecraft:experience_orb";
                case EntityType.EyeOfEnder: return "minecraft:eye_of_ender";
                case EntityType.FallingBlock: return "minecraft:falling_blocks";
                case EntityType.Fireball: return "minecraft:fireball";
                case EntityType.FireworkRocket: return "minecraft:firework_rocket";
                case EntityType.Fox: return "minecraft:fox";
                case EntityType.FurnaceMinecart: return "minecraft:furnace_minecart";
                case EntityType.Ghast: return "minecraft:ghast";
                case EntityType.Giant: return "minecraft:giant";
                case EntityType.Guardian: return "minecraft:guardian";
                case EntityType.Hoglin: return "minecraft:hoglin";
                case EntityType.HopperMinecart: return "minecraft:hopper_minecart";
                case EntityType.Horse: return "minecraft:horse";
                case EntityType.Husk: return "minecraft:husk";
                case EntityType.Illusioner: return "minecraft:illusioner";
                case EntityType.IronGolem: return "minecraft:iron_golem";
                case EntityType.Item: return "minecart:item";
                case EntityType.ItemFrame: return "minecraft:item_frame";
                case EntityType.LeashKnot: return "minecraft:lease_know";
                case EntityType.LightningBolt: return "minecraft:lightning_bolt";
                case EntityType.Llama: return "minecraft:llama";
                case EntityType.LlamaSpit: return "minecraft:llama_spit";
                case EntityType.MagmaCube: return "minecraft:magma_cube";
                case EntityType.Minecart: return "minecraft:minecart";
                case EntityType.Mooshroom: return "minecraft:mooshroom";
                case EntityType.Mule: return "minecraft:mule";
                case EntityType.None: return null;
                case EntityType.Ocelot: return "minecraft:ocelot";
                case EntityType.Painting: return "minecraft:painting";
                case EntityType.Panda: return "minecraft:panda";
                case EntityType.Parrot: return "minecraft:parrot";
                case EntityType.Phantom: return "minecraft:phantom";
                case EntityType.Pig: return "minecraft:pig";
                case EntityType.Piglin: return "minecraft:piglin";
                case EntityType.PiglinBrute: return "minecraft:piglin_brute";
                case EntityType.Pillager: return "minecraft:pillager";
                case EntityType.PolarBear: return "minecraft:polar_bear";
                case EntityType.Pufferfish: return "minecraft:pufferfish";
                case EntityType.Rabbit: return "minecraft:rabbit";
                case EntityType.Ravager: return "minecraft:ravager";
                case EntityType.Salmon: return "minecraft:salmon";
                case EntityType.Sheep: return "minecraft:sheep";
                case EntityType.Shulker: return "minecraft:shulker";
                case EntityType.ShulkerBullet: return "minecraft:shulker_bullet";
                case EntityType.Silverfish: return "minecraft:silverfish";
                case EntityType.Skeleton: return "minecraft:skeleton";
                case EntityType.SkeletonHorse: return "minecraft:skeleton_horse";
                case EntityType.Slime: return "minecraft:slime";
                case EntityType.SmallFireball: return "minecraft:small_fireball";
                case EntityType.Snowball: return "minecraft:snowball";
                case EntityType.SnowGolem: return "minecraft:snow_golem";
                case EntityType.SpawnerMinecart: return "minecraft:spawner_minecart";
                case EntityType.SpectralArrow: return "minecraft:spectral_arrow";
                case EntityType.Spider: return "minecraft:spider";
                case EntityType.Squid: return "minecraft:squid";
                case EntityType.Stray: return "minecraft:stray";
                case EntityType.Strider: return "minecraft:strider";
                case EntityType.ThrownPotion: return "minecraft:thrown_potion";
                case EntityType.Tnt: return "minecraft:tnt";
                case EntityType.TntMinecart: return "minecraft:tnt_minecart";
                case EntityType.TraderLlama: return "minecraft:trader_llama";
                case EntityType.Trident: return "minecraft:trident";
                case EntityType.TropicalFish: return "minecraft:tropical_fish";
                case EntityType.Turtle: return "minecraft:turtle";
                case EntityType.Vex: return "minecraft:vex";
                case EntityType.Villager: return "minecraft:villager";
                case EntityType.Vindicator: return "minecraft:vindicator";
                case EntityType.WanderingTrader: return "minecraft:wandering_trader";
                case EntityType.Witch: return "minecraft:witch";
                case EntityType.Wither: return "minecraft:wither";
                case EntityType.WitherSkeleton: return "minecraft:wither_skeleton";
                case EntityType.WitherSkull: return "minecraft:wither_skull";
                case EntityType.Wolf: return "minecraft:wolf";
                case EntityType.Zoglin: return "minecraft:zoglin";
                case EntityType.Zombie: return "minecraft:zombie";
                case EntityType.ZombieHorse: return "minecraft:zombie_horse";
                case EntityType.ZombieVillager: return "minecraft:zombie_villager";
                case EntityType.ZombifiedPiglin: return "minecraft:zombified_piglin";
                default: throw new ArgumentOutOfRangeException("That's not a valid entity");
            }
        }
    }
}
