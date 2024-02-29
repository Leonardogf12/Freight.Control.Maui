using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace freight.control.maui.Controls.Animations;

public class ClickAnimation
{    
    const int DefaultScale = 1;    
    const double Scale = 0.95;
    const uint DurationOfAnimantion = 100;

    const double Fade = 0.5;
    const uint Length = 100;
    const int DefaultOpacit = 1;

    public async Task SetScaleOnElement(View element, double scale = Scale,uint durationOfAnimation = DurationOfAnimantion)
    {
        await element.ScaleTo(scale, durationOfAnimation, Easing.Linear);
        await element.ScaleTo(DefaultScale, durationOfAnimation, Easing.Linear);
    }

    public async Task SetFadeOnElement(View element, int delay = 100, double fade = Fade)
    {
        await element.FadeTo(fade, Length, Easing.SpringIn);      
        await Task.Delay(delay);      
        await element.FadeTo(DefaultOpacit, Length);
    }
}
