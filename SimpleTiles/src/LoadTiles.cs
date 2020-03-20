using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleTiles
{
    public static class LoadTiles
    {
        public static Texture2D[] Load(Texture2D sprite_sheet, int width, int height)
        {
            List<Texture2D> sprites = new List<Texture2D>();

            var texture_width = sprite_sheet.Width;
            var texture_height = sprite_sheet.Height;

            var width_parts = texture_width / width;
            var height_parts = texture_height / height;

            for (int y = 0; y < height_parts; y++)
            {
                for (int x = 0; x < width_parts; x++)
                {
                    var source = new Rectangle(x * width, y * height, width, height);
                    Texture2D croppedTexture2d = new Texture2D(sprite_sheet.GraphicsDevice, width, height);
                    Color[] data_destination = new Color[width * height];
                    sprite_sheet.GetData(0, source, data_destination, 0, data_destination.Length);
                    croppedTexture2d.SetData(data_destination);
                    sprites.Add(croppedTexture2d);
                }
            }

            return sprites.ToArray();
        }
    }
}
