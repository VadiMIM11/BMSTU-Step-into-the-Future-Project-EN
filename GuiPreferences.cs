using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphProjectCSS
{
    static class GuiPreferences
    {
        static private string _font;
        static private int _fontSize;
        static private Color _defaultNodeColor = Color.LightGray;
        //static private Color color = Color.LightGray;
        static int _elipseDiameter = 30;
        static int _outlineDiameter = 2;
        static double _defaultNodeChance = 0.5;
        


        static public string Font
        {
            get => _font;
            set => _font = value;
        }
        static public int FontSize
        {
            get => _fontSize;
            set => _fontSize = value;
        }
        static public Color DefaultNodeColor
        {
            get => _defaultNodeColor;
            set => _defaultNodeColor = value;
        }

        static public int ElipseDiameter
        {
            get => _elipseDiameter;
            set => _elipseDiameter = value;
        }

        static public int OutlineDiameter
        {
            get => _outlineDiameter;
            set => _outlineDiameter = value;
        }

        static public double DefaultNodeChance
        {
            get => _defaultNodeChance;
            set => _defaultNodeChance = value;
        }

}
}
