﻿using Microsoft.VisualBasic;
using FFImageLoading.Maui;

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
	const int ForcaGravidade = 6;
	bool EstaNoChao = true;
	bool EstaNoAr = false;
	int TempoPulando = 0;
	int TempoNoAr = 0;
	const int ForcaPulo = 8;
	const int MaxTempoPulando = 6;
	const int MaxTempoNoAr = 4;
	Player Player;


	public MainPage()
	{
		InitializeComponent();
		Player = new Player(ImagePlayer);
		Player.Run();
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
		foreach(var A in Layer1.Children)
			(A as Image).WidthRequest = w;
		foreach(var A in Layer2.Children)
			(A as Image).WidthRequest = w;
		foreach(var A in Layer3.Children)
			(A as Image).WidthRequest = w;

		Layer1.WidthRequest = w * 1.5;
		Layer2.WidthRequest = w * 1.5;
		Layer3.WidthRequest = w * 1.5;
	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(Layer1); 
		GerenciaCenarios(Layer2);
		GerenciaCenarios(Layer3); 
	}

	void MoveCenario()
	{
		Layer1.TranlationX -= Velocidade1;
		Layer2.TranlationY -= Velocidade2;
		Layer3.TranlationX -= Velocidade3;
	}

	void GerenciaCenarios(HorizontalStackLayout HorizontalStackLayout)
	{
		var view = (HorizontalStackLayout.Children.First() as Image);
		if (view.WidthRequest + HorizontalStackLayout.TranslationX < 0)
		{
			HorizontalStackLayout.Children.Remove(view);
			HorizontalStackLayout.Children.Add(view);
			HorizontalStackLayout.TranslationX = view.TranslationX;
		}
	}

	async Task Desenha()
	{
		if(!EstaPulando && !EstaNoAr)
		{
			AplicaGravidade();
			Player.Desenha();
		}
		else
			AplicaPulo();

		await Task.Delay(TempoEntreFrames);
	}

	void AplicaGravidade()
	{
		if(Player.GetY()<0)
			Player.MoveY(ForcaGravidade);
		else if(Player.GetY() >= 0)
		{
			Player.SetY(0);
			EstaNoChao = true;
		}
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }



	void AplicaPulo()
	{
		EstaNoChao = false;
		if(EstaPulando && TempoPulando >= MaxTempoPulando)
		{
			EstaPulando = false;
			EstaNoAr = true;
			TempoNoAr = 0;
		}
		else if(EstaNoAr && TempoNoAr >= MaxTempoNoAr)
		{
			EstaPulando = false;
			EstaNoAr = false;
			TempoPulando = 0;
			TempoNoAr = 0;
		}

		else if(EstaPulando && TempoPulando < MaxTempoPulando)
		{
			Player.MoveY(-ForcaPulo);
			TempoPulando++;
		}

		else if(EstaNoAr)
			TempoNoAr++;
	}

	void OnGridTapped(object o, TappedEventArgs a)
	{
		if(EstaNoChao)
			EstaPulando = true;
	}
	
}

