using Microsoft.Maui.Platform;

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

    public void Die()
    {
        Loop = false;
        SetAnimacaoAtiva(2);
    }

    	public void Run()
	{
		Loop = true;
		SetAnimacaoAtiva(1);
		Play();
	}

    public void MoveY(int s)
    {
        imageView.TranslationY += s;
    }

    public double GetY()
    {
        return imageView.TranslationY;
    }

    public void SetY(double a)
    {
        imageView.TranslationY = a;
    }
}