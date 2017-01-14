using System;
using System.Collections.Generic;
using System.Text;

namespace Binding
{
    class Color
    {
        public string name {get;set;}
        public Windows.UI.Color value {get;set;}

        static IEnumerable<Color> presets;

        internal static IEnumerable<Color> GetPresetColors()
        {
            if (presets == null)
            {
                presets = new List<Color>() {
                    new Color {name = "red", value = Windows.UI.Colors.Red}, 
                    new Color {name = "green", value = Windows.UI.Colors.Green}, 
                    new Color {name = "blue", value = Windows.UI.Colors.Blue}, 
                    new Color {name = "white", value = Windows.UI.Colors.White}, 
                    new Color {name = "gray", value = Windows.UI.Colors.Gray}, 
                    new Color {name = "pink", value = Windows.UI.Colors.Pink}, 
                    new Color {name = "yellow", value = Windows.UI.Colors.Yellow}, 
                    new Color {name = "aqua", value = Windows.UI.Colors.Aqua}, 
                    new Color {name = "gold", value = Windows.UI.Colors.Gold}
                };
            }
            return presets;
        }
    }
}
