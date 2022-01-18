using GoogleClone.Models;

namespace GoogleClone.IndexDocuments
{
    public class IndexDocuments : IIndexDocuments
    {
        public Document CreateDocument(int Id, string Titulo, string Autor, string Conteudo)
        {
            throw new NotImplementedException();
        }

        public string ParseAutor(string text)
        {
            throw new NotImplementedException();
        }

        public string ParseBody(string body)
        {
            throw new NotImplementedException();
        }

        public string ParseConteudo(string body)
        {
            throw new NotImplementedException();
        }

        public List<string> ParseCorpus(string path)
        {
            List<string> documentsTexts;

            int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            for(int i = 0; i < fCount; i++)
            {
                string fileName = "doc" + i;
                string text = File.ReadAllText(fileName);
                documentsTexts.Add(text);
            }
            return documentsTexts;
        }

        public int ParseId(string text)
        {
            throw new NotImplementedException();
        }

        public string ParseText(string rawTxtFile)
        {
            throw new NotImplementedException();
        }

        public string ParseTitulo(string body)
        {
            throw new NotImplementedException();
        }
    }
}