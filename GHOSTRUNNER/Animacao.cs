namespace GHOSTRUNNER;
using FFImageLoading.Maui;

public class Animacao
{
    protected List<String> Animacao1 = new List<String>();
    protected List<String> Animacao2 = new List<String>();
    protected List<String> Animacao3 = new List<String>();
    protected bool Loop = true;
    protected int AnimacaoAtiva = 1;
    bool Parado = true;
    int FrameAtual = 1;
    protected Image compImage;
    public Animacao(Image a)
    {
        compImage = a;
    }
    public void Stop()
    {
        Parado = true;
    }
    public void Play()
    {
        Parado = false;
    }
    public void SetAnimacaoAtiva(int a)
    {
        AnimacaoAtiva = a;
    }
    public void Desenha()
    {
        if (Parado)
            return;
        string NomeArquivo = "";
        int TamanhoAnimacao = 0;
        if (AnimacaoAtiva == 1)
        {
            NomeArquivo = Animacao1[FrameAtual];
            TamanhoAnimacao = Animacao1.Count;
        }
        else if (AnimacaoAtiva == 2)
        {
            NomeArquivo = Animacao2[FrameAtual];
            TamanhoAnimacao = Animacao2.Count;
        }
        else if (AnimacaoAtiva == 3)
        {
            NomeArquivo = Animacao3[FrameAtual];
            TamanhoAnimacao = Animacao3.Count;
        }
        compImage.Source = ImageSource.FromFile(NomeArquivo);
        FrameAtual++;
        if (FrameAtual >= TamanhoAnimacao)
        {
            if (Loop)
                FrameAtual = 0;
            else
            {
                Parado = true;
                QuandoParar();
            }
        }

    }
    public virtual void QuandoParar()
    {

    }

}