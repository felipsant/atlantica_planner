using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Atlantica.Crawler
{
    public class BasicCrawler
    {
        internal static void addItemToTable(ref DataTable table, string html, string tableNodes = "//table/tr", int tableType = 0)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes(tableNodes);

            for (int i = 0; i < nodes.Count; i++)
            {
                var auxNewRow = table.NewRow();
                string valorColuna = "";
                if (tableType == 0)//Tabela de Descricao, Primeiro filho contem Nome da Coluna, Último contém o valor.
                {
                    valorColuna = nodes[i].LastChild.InnerText;
                    auxNewRow[i] = valorColuna;
                }
                else if (tableType == 1)//Tabela Mesmo, na mesma linha, que nós estamos, tem varias colunas e estas precisam ser inseridas na linha.
                {
                    var docTR = new HtmlDocument();
                    docTR.LoadHtml(nodes[i].InnerHtml);
                    var tdNodes = docTR.DocumentNode.SelectNodes("/td");
                    int col = 0;

                    HtmlDocument docTD = new HtmlDocument();
                    docTD.LoadHtml(tdNodes[0].InnerHtml);
                    string href = docTD.DocumentNode.SelectNodes("//a")
                                      .Select(p => p.GetAttributeValue("href", "not found"))
                                      .FirstOrDefault().ToString();
                    int index = href.LastIndexOf('-');
                    string itemId = href.Substring(index + 1);
                    auxNewRow[col] = itemId;
                    col += 1;
                    auxNewRow[col] = href;
                    col += 1;

                    for (int x = 0; x < tdNodes.Count; x++)
                    {
                        docTD = new HtmlDocument();
                        docTD.LoadHtml(tdNodes[x].InnerText);
                        auxNewRow[col] = tdNodes[x].InnerText;
                        col += 1;
                    }
                }
                table.Rows.Add(auxNewRow);
            }
        }

        internal static DataTable createHtmlTable(string html, string tableName, string tableNodes = "//table/tr", int tableType = 0)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var table = new DataTable(tableName);
            var nodes = doc.DocumentNode.SelectNodes(tableNodes);
            if (tableType == 1)
            {
                //TODO: Fazer o for com o nodes, passando em array.
                table.Columns.Add("ID");
                table.Columns.Add("URL");
            }
            foreach (var node in nodes)
            {
                string nomeColuna = ScrubHtml(node.FirstChild.InnerText);
                table.Columns.Add(nomeColuna);
            }
            return table;
        }

        internal static HttpClient DefaultHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text / html,application / xhtml + xml,application / xml; q = 0.9,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla / 5.0(Windows NT 6.4; WOW64; rv: 35.0) Gecko / 20100101 Firefox / 35.0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
            return httpClient;
        }

        internal static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
        }

    }
}
