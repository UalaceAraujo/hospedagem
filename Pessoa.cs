public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}