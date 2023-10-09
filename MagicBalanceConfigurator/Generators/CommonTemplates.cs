
namespace MagicBalanceConfigurator.Generators
{
    public static class CommonTemplates
    {
        public static readonly char[] EndTrimChars = new[] { '\r', '\n' };

        public static string[] AmuletVisuals = new[] {
            "\"ItAm_Dex_01.3ds\"",
            "\"ItAm_Strg_01.3ds\"",
            "\"ItAm_Dex_Strg_01.3ds\"",
            "\"ItAm_Hp_01.3ds\"",
            "\"ItAm_Mana_01.3ds\"",
            "\"ItAm_Hp_Mana_01.3ds\"",
            "\"ItAm_Prot_Mage_01.3ds\"",
            "\"ItAm_Prot_Fire_01.3ds\"",
            "\"ItAm_Prot_Edge_01.3ds\"",
            "\"ItAm_Prot_Point_01.3ds\"",
            "\"ItAm_Prot_Total_01.3ds\"",
        };
        public static string[] RingVisuals = new[] {
            "\"ItRi_Prot_Fire_01.3ds\"",
            "\"ItRi_Prot_Point_01.3ds\"",
            "\"ItRi_Prot_Edge_01.3ds\"",
            "\"ItRi_Prot_Mage_01.3ds\"",
            "\"ItRi_Prot_Total_01.3ds\"",
            "\"ItRi_Dex_01.3ds\"",
            "\"ItRi_Str_01.3ds\"",
            "\"ItRi_Dex_Strg_01.3ds\"",
            "\"ItRi_Hp_Mana_01.3ds\"",
            "\"ItRi_Mana_02.3ds\"",
            "\"ItRi_Mana_01.3ds\"",
            "\"ItRi_Hp_01.3ds\"",
            "\"ItRi_Hp_02.3ds\"",
        };
        public static string[] BeltVisuals = new[] {
            "\"ItBe_Leather_01.3ds\"",
            "\"ItBe_NovMage_01.3ds\"",
            "\"ItBe_Mage_01.3ds\"",
            "\"ItBe_Sld_01.3ds\"",
            "\"ItBe_Sld_02.3ds\"",
            "\"ItBe_Mil_01.3ds\"",
            "\"ItBe_Mage_02.3ds\"",
            "\"ItBe_TPL_01.3ds\"",
            "\"ItBe_Mage_03.3ds\"",
            "\"ItBe_Gur_01.3ds\"",
            "\"ItBe_SecNov_01.3ds\"",
        };

        public const string Amulet_IdPrefix = "itam_stext_rnd_";
        public const string Ring_IdPrefix = "itri_stext_rnd_";        
        public const string Belt_IdPrefix = "itbe_stext_rnd_";

        public const string Amulet_RandSufix = "Aml";
        public const string Ring_RandSufix = "Rng";
        public const string Belt_RandSufix = "Blt";

        public const string TierPrefix_T4 = "T4_";
        public const string TierPrefix_T3 = "T3_";
        public const string TierPrefix_T2 = "T2_";
        public const string TierPrefix_T1 = "T1_";

        public const string ItemLootTableHeader =
@"func void StExt_GetRand_[ItemType]_[Tier]()
{
	var int rnd;
	rnd = hlp_random([ItemsCount]);";
        public const string ItemLootTableTemplateString = "else if (rnd == [ItemIndex]) { b_playerfinditem([ItemId], 1); }";
        public const string ItemNameTemplateString = "const string [StringName] = \"[StringValue]\";";
        public const string LootTableSectionEnd = @";
};";
        public const string ItemLootTableMock = @"func void StExt_GetRand_[Tier][ItemType]() { };";

        public const string ItemModTextString_Text = @"text[[Index]] = [ModText_[Index]];";
        public const string ItemModTextString_Value = @"count[[Index]] = [ModValue_[Index]];";
        public const string ItemModEquipString = @"[ModEquip_[Index]];";
        public const string ItemModUnEquipString = @"[ModUnEquip_[Index]];";

        public const string RandItemMetaString = @"const int StExt_RandSeed_[SchemaName] = [Seed];";
    }
}
