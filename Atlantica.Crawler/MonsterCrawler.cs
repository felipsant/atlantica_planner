using Atlantica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Atlantica.Crawler
{
    public class MonsterCrawler : BasicCrawler
    {

        public static async System.Threading.Tasks.Task<List<Monster>> ReadMonsters()
        {
            DataTable dtMonster = await FillDataTableMonster();
            List<Monster> result = new List<Monster>();
            //DataTable monsterBasicInfo = await FillDataTableMonsterBasicInfo(monster);
            for (int i = 0; i < dtMonster.Rows.Count; i++)
            {
                try
                {
                    Monster auxMonster = new Monster()
                    {
                        AtlanticaDBId = Convert.ToInt32(dtMonster.Rows[i]["ID"]),
                        Experience = String.IsNullOrWhiteSpace(dtMonster.Rows[i]["Experience"].ToString()) ? 0 : Convert.ToInt32(dtMonster.Rows[i]["Experience"].ToString().Replace(",", "")),
                        Level = Convert.ToInt32(dtMonster.Rows[i]["Level"]),
                        Name = dtMonster.Rows[i]["Name"].ToString(),
                        URL = dtMonster.Rows[i]["URL"].ToString(),
                        Weapon = 0//dtMonster.Rows[i]["URL"],
                    };
                    result.Add(auxMonster);
                }
                catch (Exception e)
                {

                }
            }
            return result;
        }

        private static async System.Threading.Tasks.Task<DataTable> FillDataTableMonster()
        {
            DataTable result = null;
            string adbURL = "http://www.atlantica-db.com/";
            string url = adbURL + "monster/";
            HttpClient httpClient = DefaultHttpClient();
            var response = await httpClient.GetAsync(url);
            string responseText = "";
            int start, end;

            response.EnsureSuccessStatusCode();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(decompressedStream))
            {
                responseText = HttpUtility.HtmlDecode(reader.ReadToEnd());
                start = responseText.IndexOf("<table class=\"tblInfo sortable\"");
                end = responseText.IndexOf("</tbody></table>", start) + 16;
                responseText = responseText.Substring(start, (end - start));
                if (result == null)
                {
                    result = createHtmlTable(responseText, "Monster", "//thead//tr/th", 1);
                }
                addItemToTable(ref result, responseText, "//tbody/tr", 1);
            }
            return result;
        }

        private static async System.Threading.Tasks.Task<DataTable> FillDataTableMonsterBasicInfo(DataTable monster)
        {
            /*
            DataTable result = null;
            string adbURL = "http://www.atlantica-db.com/";
            string url = adbURL + "monster/";
            HttpClient httpClient = DefaultHttpClient();
            var response = await httpClient.GetStreamAsync(url);

            return result;

            foreach (string auxMonsterURL in monster.Rows)
            {
                httpClient = DefaultHttpClient();
                response = await httpClient.GetStreamAsync(adbURL + auxMonsterURL);
                responseText = "";
                DataTable resultMonsterBasicInfo = null;
                using (var reader = new StreamReader(response))
                {
                    responseText = HttpUtility.HtmlDecode(reader.ReadToEnd());
                    start = responseText.IndexOf("<table class=\"tblInfo\" class=\"tblInfo\">");
                    end = responseText.IndexOf("</td></tr></table>", start) + 18;
                    responseText = responseText.Substring(start, (end - start));
                    if (resultMonsterBasicInfo == null)
                    {
                        resultMonsterBasicInfo = createHtmlTable(responseText, "Monster");
                    }
                    addItemToTable(ref resultMonsterBasicInfo, responseText);
                }
            }
             * */
            return null;
        }
    }
}
