﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Buffs.Reactions
{
    public class Superconduct : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Electro Debuff"); // Buff display name
            // Description.SetDefault("Losing life"); // Buff description
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
            BuffID.Sets.LongerExpertDebuff[Type] = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<SuperconductNPC>().Superconduct = true;
			npc.defense *= Convert.ToInt32(npc.defense * .6);
		}

		public class SuperconductNPC : GlobalNPC
		{
			// This is required to store information on entities that isn't shared between them.
			public override bool InstancePerEntity => true;

			public bool Superconduct { get; set; }

			public override void ResetEffects(NPC npc)
			{
				Superconduct = false;
			}

			public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
			{

			}
		}
	}
}
