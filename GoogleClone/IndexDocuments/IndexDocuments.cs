using System.Text.RegularExpressions;
using GoogleClone.Models;

namespace GoogleClone.IndexDocuments
{
    public class IndexDocuments : IIndexDocuments
    {
        public Document CreateDocument(int Id, string Titulo, string Autor, string Conteudo)
        {
            Document document = new();
            document.Id = Id;
            document.Titulo = Titulo;
            document.Autor = Autor;
            document.Conteudo = Conteudo;

            return document;
        }

        public string ParseAutor(string text)
        {
            string pattern = @"(?<=<autor>)(.*?)(?=<\/autor>)";

            Regex rg = new Regex(pattern);

            string? autor = (rg.Matches(text)).ToString();

            return autor;
        }

        public string ParseConteudo(string text)
        {
            
        }

        public List<Document> ParseCorpus(string path)
        {
            List<Document> documents = new();
            List<string> files = ParseFiles(path);

            foreach(string file in files)
            {
                List<string> texts = ParseTexts(file);
                foreach(string text in texts)
                {
                    int id = ParseId(text);
                    string titulo = ParseTitulo(text);
                    string autor = ParseAutor(text);
                    string conteudo = ParseConteudo(text);

                    documents.Add(CreateDocument(id, titulo, autor, conteudo));
                }
            }
            return documents;
        }

        private List<string> ParseFiles(string path)
        {
            List<string> files = new();

            int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            for(int i = 0; i < fCount; i++)
            {
                string fileName = "doc" + i;
                string text = File.ReadAllText(fileName);
                files.Add(text);
            }
            return files;
        }

        public int ParseId(string text)
        {
            string id = string.Empty;
            for(int i = 0; i < text.Length; i++)
            {
                char curr = text[i];
                if(curr == 'O')
                {
                    int j = 1;
                    while(Char.IsDigit(text[i + j]))
                    {
                        id = id + text[i].ToString();
                        ++j;
                    }
                    break;
                }
            }
            return Int16.Parse(id);
        }

        public List<string> ParseTexts(string file)
        {
            List<string> texts = new();
            int startOfText = 0;
            for(int i = 0; i < file.Length; i++)
            {
                char curr = file[i];
                if(curr == '<')
                {
                    string bodyTag = file[i].ToString();
                    for(int j = 1; j < 6; j++)
                    {
                        bodyTag = bodyTag + file[i + j];
                    }
                    if(bodyTag == "</body>")
                    {
                        int endOfText = i + 7;
                        texts.Add(file.Substring(startOfText, endOfText));
                        startOfText = endOfText + 1;
                    }
                }  
            }
            return texts;
        }

        public string ParseTitulo(string text)
        {
            string pattern = @"(?<=<título>)(.*?)(?=<\/título>)";

            Regex rg = new Regex(pattern);

            string? titulo = (rg.Matches(text)).ToString();

            return titulo;
        }
    }
}