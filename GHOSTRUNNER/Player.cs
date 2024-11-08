using System.Linq.Expressions;

public delegate void Callback();
public class Player : Animacao
{
    public Player(Image A) : base(A)
    {
        for (int i =1; i<=; ++i)
            Animacao1.Add($" {i.ToString("D2")}.png");
        for (int i =1; i<=; ++i)
            Animacao2.Add($" {i.ToString("D2")}.png");
        
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
		Player()
	}
}