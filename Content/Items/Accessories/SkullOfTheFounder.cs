using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SpiritcallerRoninMod.Content.Items.Weapons;


namespace SpiritcallerRoninMod.Content.Items.Accessories
{
    
    public class SkullOfTheFounder : ModItem
    {
        private float AdditiveDamageBonus = 40f;
        private int AdditiveMana = 200;

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 50);
        }

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AdditiveDamageBonus, AdditiveMana);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Increase Ronin damage by 5%
            player.GetModPlayer<GlobalPlayer>().SpiritCallerDamage += AdditiveDamageBonus /100f;
            
            // For attack speed, we need to modify the player's attackSpeed stat
            // Increase player's max mana
            player.statManaMax2 += AdditiveMana;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
				.AddIngredient<StratoshadeStaff>()
				.AddIngredient<OnryoScream>()
				.AddIngredient<MagmaGhoulStaff>()
				.AddIngredient<CryoWraithStaff>()
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}