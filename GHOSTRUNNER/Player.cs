using Microsoft.Maui.Platform;
using FFImageLoading.Maui;

namespace GHOSTRUNNER;
public delegate void Callback();
public class Player : Animacao
{
    public Player(Image A) : base(A)
    {
        for (int i = 1; i <= 4; ++i)
            Animacao1.Add($"player{i.ToString("D2")}.png");
        for (int i = 1; i <= 6; ++i)
            Animacao2.Add($"playerdead{i.ToString("D2")}.png");
        
        SetAnimacaoAtiva(1);
    }

    public void Run()
	{
		Loop = true;
		SetAnimacaoAtiva(1);
		Play();
	}

    public void Die()
    {
        Loop = false;
        SetAnimacaoAtiva(2);
    }


    public void MoveY(int s)
    {
        ImageView.TranslationY += s;
    }

    public double GetY()
    {
        return ImageView.TranslationY;
    }

    public void SetY(double a)
    {
        ImageView.TranslationY = a;
    }
}