using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Data
{
    [Flags()]
    public enum Align
    {
        None = 0,
        X = 1,
        Y = 2,
        XY = 3,
        YX = 3,
        Z = 4,
        ZX = 5,
        XZ = 5,
        ZY = 6,
        YZ = 6,
        XYZ = 7,
        XZY = 7,
        YXZ = 7,
        YZX = 7,
        ZXY = 7,
        ZYX = 7
    }

    public enum Anchor
    {
        Feet = 0,
        Eyes = 1
    }

    public enum SelectorType
    {
        None = 0,
        P = 1,
        R = 2,
        A = 3,
        E = 4,
        S = 5,
    }

    public enum CoordinateType : byte
    {
        Absolute = 0,
        Relative = 1,
        Local = 2
    }

    public enum Axis
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    public enum TargetSorting
    {
        Nearest = 0,
        Furthest = 1,
        Random = 2,
        Arbitrary = 3,
        None = 4
    }

    public enum Gamemode
    {
        Survival = 0,
        Creative = 1,
        Adventure = 2,
        Spectator = 3,
        None = 4
    }

    public enum EntityType
    {
        None,
        AreaEffectCloud,
        ArmorStand,
        Arrow,
        Bat,
        Bee,
        Blaze,
        Boat,
        Cat,
        CaveSpider,
        ChestMinecart,
        Chicken,
        Cod,
        CommandBlockMinecart,
        Cow,
        Creeper,
        Dolphin,
        Donkey,
        DragonFireball,
        Drowned,
        Egg,
        ElderGuardian,
        EndCrystal,
        EnderDragon,
        EnderPearl,
        Enderman,
        Endermite,
        Evoker,
        EvokerFangs,
        ExperienceBottle,
        ExperienceOrb,
        EyeOfEnder,
        FallingBlock,
        Fireball,
        FireworkRocket,
        Fox,
        FurnaceMinecart,
        Ghast,
        Giant,
        Guardian,
        Hoglin,
        HopperMinecart,
        Horse,
        Husk,
        Illusioner,
        IronGolem,
        Item,
        ItemFrame,
        LeashKnot,
        LightningBolt,
        Llama,
        LlamaSpit,
        MagmaCube,
        Minecart,
        Mooshroom,
        Mule,
        Ocelot,
        Painting,
        Panda,
        Parrot,
        Phantom,
        Pig,
        Piglin,
        PiglinBrute,
        Pillager,
        PolarBear,
        ThrownPotion,
        Pufferfish,
        Rabbit,
        Ravager,
        Salmon,
        Sheep,
        Shulker,
        ShulkerBullet,
        Silverfish,
        Skeleton,
        SkeletonHorse,
        Slime,
        SmallFireball,
        SnowGolem,
        Snowball,
        SpawnerMinecart,
        SpectralArrow,
        Spider,
        Squid,
        Stray,
        Strider,
        Tnt,
        TntMinecart,
        TraderLlama,
        Trident,
        TropicalFish,
        Turtle,
        Vex,
        Villager,
        Vindicator,
        WanderingTrader,
        Witch,
        Wither,
        WitherSkeleton,
        WitherSkull,
        Wolf,
        Zoglin,
        Zombie,
        ZombieHorse,
        ZombifiedPiglin,
        ZombieVillager
    }

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
    }
}
