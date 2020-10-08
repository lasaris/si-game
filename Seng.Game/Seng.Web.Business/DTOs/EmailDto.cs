using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class EmailDto : ComponentBaseDto
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string ContentHeader { get; set; }
        public string ContentFooter { get; set; }
        public bool Actiove { get; set; }
        public IEnumerable<string> EmailParagraphs { get; set; } = new List<string>();
    }
}
