﻿using MagicBalanceConfigurator.Generators;
using MagicBalanceConfigurator.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator
{
    public static class Extensions
    {
        private static char[] SplitSeparator = { ',' };
        private static Random Random = new Random();
        private static int RandomSeed;

        private static int GetRandomSeed()
        {
            Task.Delay(1);
            RandomSeed += 1;
            int result = new Random(RandomSeed).Next();
            RandomSeed += Random.Next() + result + (int)DateTime.Now.Ticks;
            if (RandomSeed >= Int32.MaxValue) RandomSeed /= 2;
            if (RandomSeed < 0)
                RandomSeed *= -1;         
            return result;
        }

        public static string GetRandomElement(this string[] strings)
        {
            if (strings == null || strings?.Length == 0) return string.Empty;
            int index = new Random(GetRandomSeed()).Next(strings.Count());
            return strings[index];
        }
        public static object GetRandomObj(this IEnumerable<object> array)
        {
            if (array == null || array?.Count() == 0) 
                throw new IndexOutOfRangeException();
            int index = new Random(GetRandomSeed()).Next(array.Count());
            return array.ElementAt(index);
        }
        public static string[] ParseStringToArray(this string str) => 
            str?.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);

        public static string ParseArrayToString(this string[] strings)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in strings)
            {
                stringBuilder.Append(str);
                stringBuilder.Append(SplitSeparator);
            }
            return stringBuilder.ToString();
        }

        public static string[] GetData(this BaseGenerator generator)
        {
            string condPower = (generator as BaseItemGenerator)?.ItemCondMultiplier.ToString();
            string damPower = (generator as BaseWeaponGenerator)?.WeaponDamageMult.ToString();
            string rangePower = (generator as BaseWeaponGenerator)?.WeaponRangeMult.ToString();
            string protPower = (generator as BaseArmorGenerator)?.ArmorProtectionMult.ToString();
            string potPower = (generator as BasePotionGenerator)?.PotionDurationMult.ToString();
            var result = new string[] {
                generator.IsActive.ToString(),
                generator.GeneratorSchemaName,
                generator.ItemsCount.ToString(),
                generator.ModsCountMin.ToString(),
                generator.ModsCountMax.ToString(),
                generator.ModPower.ToString(),
                condPower,
                damPower,
                rangePower,
                protPower,
                potPower,
                generator.ItemsPrice.ToString(),
                generator.ItemName,
                generator.UseUniqName.ToString(),
                generator.Seed.ToString()
            };
            return result;
        }

        public static string[] GetData(this PackageInfo package) =>
            new string[] {
                package.IsEnabled.ToString(),
                package.LoadOrder.ToString(),
                package.Name,
                package.Version,
                package.Author,
                package.Description
            };

        public static string[] GetData(this ItemMod mod) =>
            new string[] {
                mod.ModName,
                mod.ValueMin.ToString(),
                mod.ValueMax.ToString(),
                mod.ModRarity.ToString(),
                mod.IsEnabled.ToString(),
            };
    }
}
