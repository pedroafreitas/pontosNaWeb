using GoogleClone.Models;

namespace GoogleClone.IndexDocuments
{
    public interface IIndexDocuments
    {
        //Recebe o local da pasta data (onde cada arquivo possui um ou mais textos)
        //e coloca todos os documentos em memória.
        //Retorna uma lista com cada document texto.
        List<Document> ParseCorpus(string path);

        //Recebe o conteúdo bruto do arquivo txt
        //Retorna um único texto do arquivo
        string ParseText(string rawTxtFile);

        //Recebe uma string com um Text.
        //Retorna o valor do Id
        int ParseId(string text);

        //Recebe um string com um Text
        //Retorna o Autor
        string ParseAutor(string text);

        //Recebe um string com um Text
        //Retorna o body
        string ParseBody(string body);

        //Recebe uma string com o body do texto.
        //Retorna o Titulo        
        string ParseTitulo(string body);

        //Recebe uma string com o body do texto.
        string ParseConteudo(string body);

        //Recebe o id, titulo, autor e conteudo para criar o objeto Document
        //Retorna o objeto criado
        Document CreateDocument(int Id, string Titulo, string Autor, string Conteudo);

    }
}