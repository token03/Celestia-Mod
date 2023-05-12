using Celestia.Content.Buffs.Elements;
using Celestia.Content.Projectiles;
using Celestia.Helper;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Weapons
{
	public class DendroSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("a"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("This is a basic modded sword.");
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<LightningBolt>();
			Item.shootSpeed = 40f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!ReactionHelper.dendroDetect(target, player, hit.Damage))
            {
                target.AddBuff(ModContent.BuffType<Dendro>(), 1800);
            }
        }

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// Using the shoot function, we override the swing projectile to set ai[0] (which attack it is)
			Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<LightningBolt>(), damage, knockback, Main.myPlayer, ai1: 0);
			return false;
		}


		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}