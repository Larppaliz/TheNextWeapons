using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Dusts
{
	public class VoidDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.velocity.Y *= 1f;
			dust.velocity.X *= 1f;
			dust.scale *= 1f;
		}

		public override bool MidUpdate(Dust dust) {
			dust.scale *= 0.99999999f;
			if (!dust.noGravity) {
			}

			if (dust.noLight) {
				return false;
			}

			float strength = dust.scale * 1.2f;
			if (strength > 1f) {
				strength = 1f;
			}
			Lighting.AddLight(dust.position, 0.35f * strength, 0.1f * strength, 0.5f * strength);
			return false;
		}

		public override Color? GetAlpha(Dust dust, Color lightColor) 
			=> new Color(175, 100, 255, 20);
	}
}