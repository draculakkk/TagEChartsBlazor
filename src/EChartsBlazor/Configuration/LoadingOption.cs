using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct LoadingOption
    {
        public LoadingOption(string text = "loading", string color = "#c23531", string textColor = "#000", string maskColor = "rgba(255, 255, 255, 0.8)", int zlevel = 0, int fontSize = 12, 
            bool showSpinner = true, int spinnerRadius = 10, int lineWidth = 5, string fontWeight = "normal", string fontStyle = "normal", string fontFamily = "sans-serif")
        {
            this.text = text;
            this.color = color;
            this.textColor = textColor;
            this.maskColor = maskColor;
            this.zlevel = zlevel;
            this.fontSize = fontSize;
            this.showSpinner = showSpinner;
            this.spinnerRadius = spinnerRadius;
            this.lineWidth = lineWidth;
            this.fontWeight = fontWeight;
            this.fontStyle = fontStyle;
            this.fontFamily = fontFamily;
        }

        public string text { get; }
        public string color { get; }
        public string textColor { get; }
        public string maskColor { get; }
        public int zlevel { get; }
        public int fontSize { get; }
        public bool showSpinner { get; }
        public int spinnerRadius { get; }
        public int lineWidth { get; }
        public string?fontWeight { get; }
        public string fontStyle { get; }
        public string fontFamily { get; }

    }
}
