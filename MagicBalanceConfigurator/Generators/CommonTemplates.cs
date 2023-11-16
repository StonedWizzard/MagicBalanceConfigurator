
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    public static class CommonTemplates
    {
        public static readonly char[] EndTrimChars = new[] { '\r', '\n' };

        public readonly static string[] AmuletVisuals = new[] {
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
        public readonly static string[] RingVisuals = new[] {
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
        public readonly static string[] BeltVisuals = new[] {
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

        public readonly static string[] PoitionsT1Visuals = new[] {
            "\"MMB_BlueVino.3ds\"",
            "\"MMB_BrownVino.3ds\"",
            "\"MMB_GreenVino.3ds\"",
            "\"MMB_LightBrownVino.3ds\"",
            "\"MMB_LilaVino.3ds\"",
            "\"MMB_RedVino.3ds\"",
            "\"MMB_RoseVino.3ds\"",
            "\"MMB_VioletVino.3ds\""
        };
        public readonly static string[] PoitionsT2Visuals = new[] {
            "\"MMB_BlueSphere.3ds\"",
            "\"MMB_BrownSphere.3ds\"",
            "\"MMB_GreenSphere.3ds\"",
            "\"MMB_LightBrownSphere.3ds\"",
            "\"MMB_LilaSphere.3ds\"",
            "\"MMB_RedSphere.3ds\"",
            "\"MMB_RoseSphere.3ds\"",
            "\"MMB_VioletSphere.3ds\""
        };
        public readonly static string[] PoitionsT3Visuals = new[] {
            "\"MMB_BlueAlchemy.3ds\"",
            "\"MMB_BrownAlchemy.3ds\"",
            "\"MMB_GreenAlchemy.3ds\"",
            "\"MMB_LightBrownAlchemy.3ds\"",
            "\"MMB_LilaAlchemy.3ds\"",
            "\"MMB_RedAlchemy.3ds\"",
            "\"MMB_RoseAlchemy.3ds\"",
            "\"MMB_VioletAlchemy.3ds\""
        };
        public readonly static string[] PoitionsT4Visuals = new[] {
            "\"MMB_BlueCaraf.3ds\"",
            "\"MMB_BrownCaraf.3ds\"",
            "\"MMB_GreenCaraf.3ds\"",
            "\"MMB_LightBrownCaraf.3ds\"",
            "\"MMB_LilaCaraf.3ds\"",
            "\"MMB_RedCaraf.3ds\"",
            "\"MMB_RoseCaraf.3ds\"",
            "\"MMB_VioletCaraf.3ds\""
        };

        public const string Amulet_IdPrefix = "itam_stext_rnd_";
        public const string Ring_IdPrefix = "itri_stext_rnd_";
        public const string Belt_IdPrefix = "itbe_stext_rnd_";
        public const string Poition_IdPrefix = "itpo_stext_rnd_";
        public const string Weapon_1h_IdPrefix = "itmw_1h_stext_rnd_";
        public const string Weapon_2h_IdPrefix = "itmw_2h_stext_rnd_";
        public const string Weapon_bow_IdPrefix = "itrw_bow_stext_rnd_";
        public const string Weapon_crossbow_IdPrefix = "itrw_crossbow_stext_rnd_";
        public const string Weapon_Staff_IdPrefix = "itmw_staff_stext_rnd_";
        public const string Weapon_MagicSword_IdPrefix = "itmw_magicsword_stext_rnd_";
        public const string Armor_Shield_IdPrefix = "itar_shield_stext_rnd_";
        public const string Armor_Helm_IdPrefix = "itar_helm_stext_rnd_";
        public const string Armor_Body_IdPrefix = "itar_body_stext_rnd_";
        
        public const string Amulet_RandSufix = "Aml";
        public const string Ring_RandSufix = "Rng";
        public const string Belt_RandSufix = "Blt";
        public const string Poition_RandSufix = "Pot";
        public const string Weapon_1h_RandSufix = "Weap_1h";
        public const string Weapon_2h_RandSufix = "Weap_2h";
        public const string Weapon_bow_RandSufix = "Bow";
        public const string Weapon_crossbow_RandSufix = "Crossbow";
        public const string Weapon_staff_RandSufix = "Staff";
        public const string Weapon_magicsword_RandSufix = "MagicSword";
        public const string Armor_shield_RandSufix = "Shield";
        public const string Armor_helm_RandSufix = "Helm";
        public const string Armor_body_RandSufix = "Body";

        public const string TierPrefix_T4 = "T4_";
        public const string TierPrefix_T3 = "T3_";
        public const string TierPrefix_T2 = "T2_";
        public const string TierPrefix_T1 = "T1_";

        public const string ItemLootTableHeader =
@"func void StExt_GetRand_[Tier]_[ItemType]()
{
	var int rnd;
	rnd = hlp_random([ItemsCount]);";
        public const string ItemLootTableHeader2 =
@"func int StExt_CreateRand_[Tier]_[ItemType]()
{
	var int rnd;
	rnd = hlp_random([ItemsCount]);";
        public const string ItemLootTableTemplateString = "else if (rnd == [ItemIndex]) { b_playerfinditem([ItemId], 1); }";
        public const string ItemLootTableTemplateString2 = "else if (rnd == [ItemIndex]) { return [ItemId]; }";
        public const string ItemNameTemplateString = "const string [StringName] = \"[StringValue]\";";
        public const string LootTableSectionEnd = @";
};";
        public const string ItemLootTableMock = @"func void StExt_GetRand_[Tier][ItemType]() { };";
        public const string ItemLootTableMock2 = @"func int StExt_CreateRand_[Tier][ItemType]() { };";

        public const string ItemModTextString_Text = @"text[[Index]] = [ModText_[Index]];";
        public const string ItemModTextString_Text2 = @"text[[Index]] = [ModText];";
        public const string ItemModTextString_Value = @"count[[Index]] = [ModValue_[Index]];";
        public const string ItemModTextString_Value2 = @"count[[Index]] = [ModValue];";
        public const string ItemModEquipString = @"[ModEquip_[Index]];";
        public const string ItemModUnEquipString = @"[ModUnEquip_[Index]];";

        public const string ItemCondString_Atr = "cond_atr[[Index]] = [AtrIndex];\r\n";
        public const string ItemCondString_Value = "cond_value[[Index]] = [CondAtrValue];\r\n";

        public const string ItemCondAtr_Mana = "atr_mana_max";
        public const string ItemCondAtr_Str = "atr_strength";
        public const string ItemCondAtr_Agi = "atr_dexterity";
        public const string ItemCondAtr_Hp = "atr_hitpoints_max";
        public const string ItemCondAtr_Stamina = "aivrx_npc_atr_stamina";
        public const string ItemCondAtr_Bow = "aivrx_npc_atr_bow";
        public const string ItemCondAtr_Crosbow = "aivrx_npc_atr_crossbow";
        public const string ItemCondAtr_Shield = "aivrx_npc_atr_shield";
        public readonly static string[] ItemCondAtributes = new string[] { ItemCondAtr_Mana, ItemCondAtr_Hp, ItemCondAtr_Str, ItemCondAtr_Agi, ItemCondAtr_Stamina, };

        public readonly static Dictionary<string, string> CondTextPair = new Dictionary<string, string>()
        {
            { ItemCondAtr_Mana, "StExt_Str_DisplayManaReq" },
            { ItemCondAtr_Str, "StExt_Str_DisplayStrReq" },
            { ItemCondAtr_Agi , "StExt_Str_DisplayAgiReq" },
            { ItemCondAtr_Hp , "StExt_Str_DisplayHpReq" },
            { ItemCondAtr_Stamina , "StExt_Str_DisplayStamReq" },
            { ItemCondAtr_Bow , "StExt_Str_DisplayBowReq" },
            { ItemCondAtr_Crosbow , "StExt_Str_DisplayCBowReq" },
            { ItemCondAtr_Shield , "StExt_Str_DisplayShieldReq" }
        };

        /// <summary>
        /// Value represent damage index in item damage array
        /// Key represent damagetype
        /// </summary>
        public readonly static Dictionary<string, string> WeaponDamagePair = new Dictionary<string, string>()
        {
            { "dam_blunt", "dam_index_blunt" },
            { "dam_edge", "dam_index_edge" },
            { "dam_fire" , "dam_index_fire" },
            { "dam_fly" , "dam_index_fly" },
            { "dam_magic" , "dam_index_magic" },
            { "dam_point" , "dam_index_point" }
        };
        public const string ArmorProtectionSectionTemplate = @"protection[1] = [ProtBlunt];
    protection[2] = [ProtEdge];
    protection[3] = [ProtFire];
    protection[5] = [ProtMagic];
    protection[6] = [ProtPoint];
    protection[4] = [ProtFly];";

        public const string WeaponDamageString = @"damage[[DamageIndex]] = [DamageValue];";
        public const string RandItemMetaString = @"const int StExt_RandSeed_[SchemaName] = [Seed];";

        public const string StExt_CreateRandomItemMock = @"func void StExt_CreateRandomItem(var c_npc slf, var int item, var int max, var int chest) { };";
        public const string StExt_ApplyPotionEffectMock = @"func void StExt_ApplyPotionEffect(var int effectId, var int power, var int duration) { };";
        public const string RndFileMetaBlock = @"META
{
    After = StExt_RndItems_Meta.d;
};";

        public const string EquipInfoTemplate = "ai_printbonus(concatstrings([EquipNameStr], inttostring([Value])))";


        public const string CrosbowTempalte = @"
instance [IdPrefix][Id](c_item) 
{
    name = [NameId];
[CondSection]
[DamageSection]
    damagetotal = [DamageTotal];
    damagetype = [DamageTotalType];
    description = [NameId];
    flags = [ItemType] | item_mission;
    inv_animate = 1;
    mainflag = item_kat_ff;
    material = mat_wood;
    visual = [Visual];
	on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    spell = [WeapModsData];
    munition = itrw_bolt;
    value = [Price];
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
	if(self.id == 0) 
	{
[ModsEquip]
	};
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
	if(self.id == 0) 
	{
[ModsUnEquip]
	};
};";


        public const string BowTempalte = @"
instance [IdPrefix][Id](c_item) 
{
    name = [NameId];
[CondSection]
[DamageSection]
    damagetotal = [DamageTotal];
    damagetype = [DamageTotalType];
    description = [NameId];
    flags = [ItemType] | item_mission;
    inv_animate = 1;
    mainflag = item_kat_ff;
    material = mat_wood;
    visual = [Visual];
	on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    spell = [WeapModsData];
    munition = itrw_arrow;
    value = [Price];
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
	if(self.id == 0) 
	{
[ModsEquip]
	};
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
	if(self.id == 0) 
	{
[ModsUnEquip]
	};
};";


        public const string WeaponTemplate = @"
instance [IdPrefix][Id](c_item) 
{
    name = [NameId];
[CondSection]
[DamageSection]
    damagetotal = [DamageTotal];
    damagetype = [DamageTotalType];
    description = [NameId];
    flags = [ItemType] | item_mission;
    inv_animate = 1;
    mainflag = item_kat_nf;
    material = mat_metal;
    visual = [Visual];
	on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    spell = [WeapModsData];
    range = [WeaponRange];
    value = [Price];
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
    [SpecialSection]
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
	if(self.id == 0) 
	{
[ModsEquip]
	};
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
	if(self.id == 0) 
	{
[ModsUnEquip]
	};
};";

        public const string StaffTemplate = @"
instance [IdPrefix][Id](c_item) 
{
    name = [NameId];
[CondSection]
[DamageSection]
    damagetotal = [DamageTotal];
    damagetype = [DamageTotalType];
    description = [NameId];
    flags = [ItemType] | item_mission;
    inv_animate = 1;
    mainflag = item_kat_nf;
    material = mat_wood;
    visual = [Visual];
	on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    spell = [WeapModsData];
    range = [WeaponRange];
    value = [Price];
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
	if(self.id == 0) 
	{
[ModsEquip]
	};
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
	if(self.id == 0) 
	{
[ModsUnEquip]
	};
};";


        public const string PotionTemplate = @"instance [IdPrefix][Id](c_item) 
{
    name = stext_itpo_rnd_name;
    mainflag = item_kat_potions;
    flags = item_multi;
    value = [Price];
    visual = [Visual];
    material = mat_glas;
    on_state = use[IdPrefix][Id];
    scemename = ""POTIONFAST"";
    wear = wear_effect;
    description = [NameId];
[ModsText]
    text[5] = name_value;
    count[5] = value;
    inv_animate = 1;
};
func void use[IdPrefix][Id]() 
{
    if(self.id == 0) 
	{
[ModsEquip]
	};
};
";


        public const string AmuletTemplate = @"instance [IdPrefix][Id](c_item) 
{
    name = name_amulett;
    mainflag = item_kat_magic;
    flags = item_amulet | item_mission;
    value = [Price];
    visual = [Visual];
    visual_skin = 0;
    material = mat_metal;
    on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    wear = wear_effect;
    description = [NameId];
[ModsText]
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = value;
    inv_zbias = invcam_entf_amulette_standard;
    inv_animate = 1;
};
func void equip_[IdPrefix][Id]()
{
    if(self.id == 0) 
	{
[ModsEquip]
    };
};
func void unequip_[IdPrefix][Id]()
{
    if(self.id == 0) 
	{
[ModsUnEquip]
    };
};";


        public const string RingTemplate = @"instance [IdPrefix][Id](c_item) 
{
    name = name_ring;
    mainflag = item_kat_magic;
    flags = item_ring | item_mission;
    value = [Price];
    visual = [Visual];
    visual_skin = 0;
    material = mat_metal;
    on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    wear = wear_effect;
    description = [NameId];
[ModsText]
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = value;
    inv_zbias = invcam_entf_ring_standard;
    inv_rotz = invcam_z_ring_standard;
    inv_rotx = invcam_x_ring_standard;
    inv_animate = 1;
};
func void equip_[IdPrefix][Id]()
{
    if(self.id == 0) 
	{
[ModsEquip]
    };
};
func void unequip_[IdPrefix][Id]()
{
    if(self.id == 0) 
	{
[ModsUnEquip]
    };
};";


        public const string BeltTemplate = @"instance [IdPrefix][Id](c_item) 
{
    name = stext_itbe_rnd_name;
    mainflag = item_kat_magic;
    flags = item_belt | item_mission | item_multi;
    value = [Price];
    visual = [Visual];
    visual_skin = 0;
    material = mat_metal;
    on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    description = [NameId];
[ModsText]
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = value;
    inv_animate = 0;
    inv_rotx = invcam_entf_misc2_standard;
    inv_zbias = invcam_entf_amulette_standard;
};
func void equip_[IdPrefix][Id]()
{
    if(self.id == 0) 
	{
[ModsEquip]
    };
};
func void unequip_[IdPrefix][Id]()
{
    if(self.id == 0) 
	{
[ModsUnEquip]
    };
};";


        public const string ShieldTemplate = @"instance [IdPrefix][Id](c_item) 
{
    name = [NameId];
[CondSection]
    flags = item_shield;
    inv_animate = 1;
    mainflag = item_kat_nf;
    material = mat_metal;
    munition = itrw_ass_2x2;
    visual_skin = 0;
    visual = [Visual];
	on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    [ProtectionSection]
    description = name;
    value = [Price];
[ShieldText]
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
    if(self.id == 0) 
	{
[ModsEquip]
    };
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
    if(self.id == 0) 
	{
[ModsUnEquip]
    };
};";


        public const string HelmTemplate = @"instance [IdPrefix][Id](c_item) {
    name = [NameId];
    description = name;
[CondSection]
    flags = item_mission;
    inv_animate = 0;
    inv_zbias = invcam_entf_helm;
    mainflag = item_kat_armor;
    material = mat_leather;
    visual = [Visual];
    visual_change = [Visual];
    visual_skin = 0;
    wear = wear_head;
	on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    [ProtectionSection]
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
    if(self.id == 0) 
	{
[ModsEquip]
    };
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
    if(self.id == 0) 
	{
[ModsUnEquip]
    };
};";


        public const string ArmorTemplate = @"instance [IdPrefix][Id](c_item) 
{
    name = [NameId];
    description = name;
[CondSection]
    [ProtectionSection]
    flags = item_mission;
    inv_animate = 0;
    mainflag = item_kat_armor;
    material = mat_leather;
    on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    value = [Price];
    visual = [Visual];
    visual_change = [VisualChange];
    visual_skin = 0;
    wear = wear_torso;
    text[5] = StExt_Enchanted_Name_Value;
    count[5] = [Price];
    [SpecialSection]
};
func void equip_[IdPrefix][Id]()
{
    [BaseOnEquipFunc]
    if(self.id == 0) 
	{
[ModsEquip]
    };
};
func void unequip_[IdPrefix][Id]()
{
    [BaseOnUnEquipFunc]
    if(self.id == 0) 
	{
[ModsUnEquip]
    };
};";
    }
}
