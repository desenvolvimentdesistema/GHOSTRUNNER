using Microsoft.Maui.Platform;
using Microsoft.VisualBasic;

namespace GHOSTRUNNER;

public partial class MainPage : ContentPage
{
	bool EstaMorto = false;
	bool EstaPulando = false;
	const int TempoEntreFrames = 25;
	int Velocidade1 = 0;
	int Velocidade2 = 0;
	int Velocidade3 = 0;
	int Velocidade = 0;
	int LarguraJanela = 0;
	int AlturaJanela = 0;


	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);	
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
	}

	void CalculaVelocidade(double w)
	{
		Velocidade1 = (int)(w * 0.001);
		Velocidade2 = (int)(w * 0.004);
		Velocidade3 = (int)(w * 0.008);
		Velocidade = (int)(w * 0.01);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach(var A in Layer1.Chidren)
		(A as Image).WidthRequest = w;
		foreach(var A in Layer2.Chidren)
		(A as Image).WidthRequest = w;
		foreach(var A in Layer3.Chidren)
		(A as Image).WidthRequest = w;

		Layer1.WidthRequest = w * 1.5;
		Layer2.WidthRequest = w * 1.5;
		Layer3.WidthRequest = w * 1.5;
	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(HSLayer1); 
		GerenciaCenarios(HSLayer2);
		GerenciaCenarios(HSLayer3);
		GerenciaCenarios(HSLayerChao); 
	}

	void MoveCenario()
	{
		HSLayer1.TranlationX -= Velocidade1;
		HSLayer2.TranlationY -= Velocidade2;
		HSLayer3.TranlationX -= Velocidade3;
		HSLayerChao.TranlationX -= Velocidade;
	}

	void GerenciaCenarios(HorizontalStackLayout HSL)
	{
		var view = (HSL.Chidren.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}

	async TaskDesenha()
	{
		while(!EstaMorto)
		{
			GerenciaCenarios()
			await Task.Delay(TempoEntreFrames);
		}
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }
}

