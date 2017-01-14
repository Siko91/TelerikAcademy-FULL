using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.XmlQueries
{
    public class QueryReader
    {
        public IEnumerable<IQuery> ReadQueries(string filePath)
        {
            List<IQuery> queries = new List<IQuery>();
            XElement file = XElement.Load(filePath);
            foreach (var query in file.Elements("query"))
            {
                var attr = query.Attributes().FirstOrDefault(at => at.Name == "type");
                if (attr.Value == "by-period")
                {
                    queries.Add(new DateRangeQuery()
                    {
                        DateFrom = DateTime.ParseExact(query.Element("start-date").Value, "d-MMM-yyyy", CultureInfo.InvariantCulture),
                        DateTo = DateTime.ParseExact(query.Element("end-date").Value, "d-MMM-yyyy", CultureInfo.InvariantCulture)
                    });
                }
                else if (attr.Value == "by-author")
                {
                    queries.Add(new AuthorQuery()
                    {
                        AuthorName = query.Element("author-name").Value
                    });
                }
                else
                {
                    throw new UnknownQueryException();
                }
            }

            return queries;
        }
    }
}